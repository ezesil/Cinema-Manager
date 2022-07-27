using BaseServices.Services;
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
        private SplitterPanel? _userControlContainer;

        //private UserControl? _currentNavMenuControl;
        private SplitterPanel? _currentNavMenuContainer;

        private SplitterPanel? _currentHeaderContainer;
        private GenericHeader? _currentHeader;

        private Home _currentForm;

        private List<Button>? _currentButtons;

        public delegate void OnNavigatedEvent();
        public event OnNavigatedEvent OnNavigated;

        public delegate void BeforeNavigatingEvent();
        public event BeforeNavigatingEvent BeforeNavigating;

        private SessionService _sessionService;

        public NavigationManager Setup(Home currentform, SplitterPanel navMenuContainer, SplitterPanel userControlContainer, SessionService sessionService = null, UserControl? currentPanel = null)
        {
            _userControlContainer = userControlContainer;
            _currentUserControl = currentPanel;
            _currentForm = currentform;
            _currentButtons = new List<Button>();
            _currentNavMenuContainer = navMenuContainer;

            _currentNavMenuContainer.AutoScroll = true;
            _currentNavMenuContainer.VerticalScroll.Visible = false;
            _currentNavMenuContainer.HorizontalScroll.Enabled = false;
            _currentNavMenuContainer.HorizontalScroll.Visible = false;

            _sessionService = sessionService;

            return this;
        }

        public void SetHeaderContainer(SplitterPanel headerContainer)
        {
            _currentHeaderContainer = headerContainer;
            _currentHeader = new GenericHeader();
            headerContainer.Controls.Clear();
            _currentHeader.Dock = DockStyle.Fill;
            headerContainer.Controls.Add(_currentHeader);
        }

        public void SetHeaderTitle(string name)
        {
            if (_currentHeaderContainer == null || _currentHeader == null)
                return;

            _currentHeader.SetHeaderTitle(name);
        }

        public T? NavigateTo<T>(object? args) where T : UserControl
        {
            return NavigateTo<T>(null, args);
        }

        public T? NavigateTo<T>(Func<SessionService, bool> canNavigateVerifier = null, object? args = null) where T : UserControl
        {
            if(canNavigateVerifier != null && _sessionService != null)
            {
                if (!canNavigateVerifier.Invoke(_sessionService))
                {
                    NavigateTo<MainPage>();
                    throw new Exception("El verificador especificado no arrojó un resultado positivo.");
                }
            }


            var userControl = DependencyService.Get<T>();

            if (_currentUserControl == userControl
                || _userControlContainer == null
                || _currentHeaderContainer == null
                || _currentHeader == null)
                return null;

            userControl.Dock = DockStyle.Fill;
            userControl.Show();
            userControl.Focus();


            _userControlContainer.Invoke((MethodInvoker)delegate
            {

                _userControlContainer.Controls.Clear();

                _currentUserControl = userControl;
                SetHeaderTitle(_currentUserControl.Name);
                _currentUserControl.Visible = true;

                _userControlContainer.Controls.Add(userControl);
            });

            OnNavigated?.Invoke();

            return userControl;
        }

        private void SetSelectedButton(object sender, EventArgs? e)
        {
            if (_currentButtons == null || sender == null)
                return;

            var currentbutton = (Button)sender;

            foreach (var button in _currentButtons)
            {
                if (button != currentbutton)
                    EnableButton(button);

                else
                    DisableButton(button);
            }
        }

        public void EnableButton(Button button)
        {
            // Color de texto ~violeta/gris
            //button.ForeColor = Color.FromArgb(114, 137, 218);
            // Color de fondo gris oscuro
            button.BackColor = Color.FromArgb(30, 33, 36);
            button.ForeColor = Color.Silver;
            button.Enabled = true;
        }

        public void DisableButton(Button button)
        {
            button.BackColor = Color.FromArgb(33, 150, 243);
            button.ForeColor = Color.Silver;
            button.Enabled = false;
        }

        public async Task NavigateToAsync<T>() where T : UserControl
        {
            await Task.Run(() => NavigateTo<T>());
        }

        public Button CreateButton(EventHandler handler, string name, string buttontag = "", Color? colorOverride = null)
        {
            if (_currentButtons == null || _currentButtons.Count == 0)
            {
                var button = GetNavigationButton(_currentButtons.Count);
                button.Tag = buttontag;
                button.Text = buttontag;
                button.Name = name;
                button.Click += handler;
                button.Click += SetSelectedButton;
                DisableButton(button);
                _currentButtons.Add(button);
                button.Visible = true;
                button.Enabled = true;
                _currentNavMenuContainer.Controls.Add(button);
                _currentNavMenuContainer.Show();
                button.Show();
                button.BringToFront();
                if (colorOverride != null)
                    button.BackColor = (Color)colorOverride;
                return button;

            }
            else
            {
                var button = GetNavigationButton(_currentButtons.Count);
                button.Tag = buttontag;
                button.Text = buttontag;
                button.Name = name;
                button.Click += handler;
                button.Click += SetSelectedButton;
                _currentButtons.Add(button);
                button.Visible = true;
                button.Enabled = true;
                _currentNavMenuContainer.Controls.Add(button);
                _currentNavMenuContainer.Show();
                button.Show();
                button.BringToFront();
                if (colorOverride != null)
                    button.BackColor = (Color)colorOverride;
                return button;
            }
        }

        private Button GetNavigationButton(int position = 0)
        {
            Button button = new Button();
            button.Location = new Point(-2, 0 + (position * 50));
            button.ForeColor = Color.Silver;
            button.Enabled = true;
            button.Size = new Size(162, 50);
            button.TextAlign = ContentAlignment.MiddleLeft;

            button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            button.BackColor = Color.FromArgb(30, 33, 36);
            button.FlatAppearance.BorderColor = Color.FromArgb(30, 33, 36);
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 190, 255);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(33, 150, 243);
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button.UseVisualStyleBackColor = false;

            return button;
        }

        public void ClearNavigationButtons()
        {
            foreach (var button in _currentButtons)
            {
                _currentNavMenuContainer.Controls.Remove(button);
            }
            _currentButtons.Clear();
        }

        public void MenuOnLogin()
        {
            _currentForm.MenuOnLogin();
        }
    }
}
