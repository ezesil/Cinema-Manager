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
        private SplitContainer? _currentContainer;
        private UserControl? _currentUserControl;
        private List<Button>? _currentButtons;
        public event EventHandler<UserControl>? CurrentFormChanged;

        public ContentService Setup(SplitContainer container, List<Button> buttons, UserControl? currentPanel = null)
        {
            _currentContainer = container;
            _currentUserControl = currentPanel;
            _currentButtons = buttons;
            return this;
        }

        public void NavigateTo<T>() where T : UserControl
        {
            var userControl = DependencyService.Get<T>();

            if(_currentUserControl == userControl || _currentContainer == null)
                return;

            _currentContainer.Panel2.Controls.Clear();

            _currentUserControl = userControl;
            _currentUserControl.Visible = true;           
            userControl.Show();
            _currentContainer.Panel2.Controls.Add(userControl);
            _currentUserControl.Focus();

            CurrentFormChanged?.Invoke(this, userControl);
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
