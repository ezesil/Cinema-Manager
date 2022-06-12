using Cinema.UI.Headers;
using Cinema.UI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.Services
{
    public class ContentService
    {
        private UserControl? _currentUserControl;
        private SplitterPanel? _currentContainer;

        private SplitterPanel? _currentHeaderContainer;
        private GenericHeader? _currentHeader;
        
        private List<Button>? _currentButtons;

        public delegate void ButtonDisable(Button button);
        public ButtonDisable? ButtonDisabler;
        
        public EventHandler? ButtonPainter;

        public ContentService Setup(SplitterPanel container, List<Button> buttons, UserControl? currentPanel = null)
        {
            ButtonDisabler += DisableButton;
            ButtonPainter += Button_EnabledChanged;

            foreach (var button in buttons)
            {
                button.EnabledChanged += ButtonPainter;
            }

            _currentContainer = container;
            _currentUserControl = currentPanel;
            _currentButtons = buttons;
            return this;
        }

        public void SetHeaderContainer(SplitterPanel headerContainer)
        {          
            _currentHeaderContainer = headerContainer;
            _currentHeader = new GenericHeader();
            headerContainer.Controls.Clear();
            headerContainer.Controls.Add(_currentHeader);         
        }

        public void SetHeaderTitle(string name)
        {
            if (_currentHeaderContainer == null || _currentHeader == null)
                return;

            _currentHeader.SetHeaderTitle(name);
        }

        public T? NavigateTo<T>(object? args = null) where T : UserControl
        {
            var userControl = DependencyService.Get<T>();

            if(_currentUserControl == userControl 
                || _currentContainer == null 
                || _currentHeaderContainer == null 
                || _currentHeader == null)
                return null;

            _currentContainer.Invoke((MethodInvoker)delegate {

                _currentContainer.Controls.Clear();

                _currentUserControl = userControl;
                SetHeaderTitle(_currentUserControl.Name);
                _currentUserControl.Visible = true;

                _currentContainer.Controls.Add(userControl);
            });

            userControl.Invoke((MethodInvoker)delegate
            {
                userControl.Dock = DockStyle.Fill;
                userControl.Show();
            });
         
            return userControl;
        }

        private void DisableButton(Button currentButton)
        {
            if (_currentButtons == null)
                return;

            foreach(var button in _currentButtons)
            {
                if(button != currentButton)
                    button.Enabled = true;

                else
                    button.Enabled = false;
            }
        }

        private void Button_EnabledChanged(object sender, EventArgs e)
        {           
            var button = (Button)sender;
            if (button.Enabled)
            {
                button.ForeColor = Color.FromArgb(114, 137, 218);
                button.BackColor = Color.FromArgb(30, 33, 36); ;
            }
            else
            {
                button.ForeColor = Color.Black;
                button.BackColor = Color.DarkGray;
            }
        }

        public async Task NavigateToAsync<T>() where T : UserControl
        {
            await Task.Run(() => NavigateTo<T>());
        }
    }
}
