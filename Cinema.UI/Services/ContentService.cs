using Cinema.UI.Headers;
using Cinema.UI.Views;
using System;
using System.Collections.Generic;
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
        public event EventHandler<UserControl>? CurrentFormChanged;

        public ContentService Setup(SplitterPanel container, List<Button> buttons, UserControl? currentPanel = null)
        {
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

            _currentContainer.Controls.Clear();

            _currentUserControl = userControl;
            SetHeaderTitle(_currentUserControl.Name);
            _currentUserControl.Visible = true;    
            userControl.Dock = DockStyle.Fill;
            userControl.Show();
            _currentContainer.Controls.Add(userControl);
            _currentUserControl.Focus();


            CurrentFormChanged?.Invoke(this, userControl);

            return userControl;
        }

        public void DisableButton(Button currentButton)
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

        public async Task NavigateToAsync<T>() where T : UserControl
        {
            await Task.Run(() => NavigateTo<T>());
        }
    }
}
