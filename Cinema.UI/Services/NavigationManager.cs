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
    public class NavigationManager
    {
        private UserControl? _currentUserControl;
        private SplitterPanel? _currentContainer;

        private SplitterPanel? _currentHeaderContainer;
        private GenericHeader? _currentHeader;

        private List<Button>? _currentButtons;

        private event EventHandler<EventArgs> OnNavigate;

        public NavigationManager Setup(SplitterPanel container, List<Button> buttons, UserControl? currentPanel = null)
        {
            var firstbutton = true;
            foreach (var button in buttons)
            {
                if (firstbutton)
                {
                    firstbutton = false;
                    DisableButton(button);
                }
                button.Click += SetSelectedButton;
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

            if (_currentUserControl == userControl
                || _currentContainer == null
                || _currentHeaderContainer == null
                || _currentHeader == null)
                return null;

            _currentContainer.Invoke((MethodInvoker)delegate
            {

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
                userControl.Focus();
            });

            return userControl;
        }

        private void SetSelectedButton(object sender, EventArgs? e)
        {
            if (_currentButtons == null || sender == null)
                return;

            var currentbutton = (Button)sender;

            foreach (var button in _currentButtons)
            {
                button.Invoke((MethodInvoker)delegate
                {
                    if (button != currentbutton)
                        EnableButton(button);

                    else
                        DisableButton(button);
                });
            }
        }

        public void EnableButton(Button button)
        {
            // Color de texto ~violeta/gris
            button.ForeColor = Color.FromArgb(114, 137, 218);
            // Color de fondo gris oscuro
            button.BackColor = Color.FromArgb(30, 33, 36); ;
            button.Enabled = true;
        }

        public void DisableButton(Button button)
        {
            button.ForeColor = Color.Black;
            button.BackColor = Color.DarkGray;
            button.Enabled = false;
        }

        public async Task NavigateToAsync<T>() where T : UserControl
        {
            await Task.Run(() => NavigateTo<T>());
        }
    }
}
