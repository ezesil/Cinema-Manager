using BaseServices.Domain.Control_de_acceso;
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
        private SplitterPanel? _currentContainer;

        private SplitterPanel? _currentHeaderContainer;
        private GenericHeader? _currentHeader;

        private Home _currentForm;

        private List<Button>? _currentButtons;

        private event EventHandler<EventArgs> OnNavigate; 

        public NavigationManager Setup(Home currentform, SplitterPanel container, UserControl? currentPanel = null)
        {          
            _currentContainer = container;
            _currentUserControl = currentPanel;
            _currentForm = currentform;
            _currentButtons = new List<Button>();
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

        public T? NavigateTo<T>(object? args = null) where T : UserControl
        {
            var userControl = DependencyService.Get<T>();

            if (_currentUserControl == userControl
                || _currentContainer == null
                || _currentHeaderContainer == null
                || _currentHeader == null)
                return null;

            userControl.Dock = DockStyle.Fill;
            userControl.Show();
            userControl.Focus();


            _currentContainer.Invoke((MethodInvoker)delegate
            {

                _currentContainer.Controls.Clear();

                _currentUserControl = userControl;
                SetHeaderTitle(_currentUserControl.Name);
                _currentUserControl.Visible = true;

                _currentContainer.Controls.Add(userControl);
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

        public Button CreateButton(EventHandler handler, string name, string buttontag = "Boton")
        {        
            //List<Button>? buttons = _currentContainer?.Controls?.OfType<Button>().ToList();
            if(_currentButtons == null || _currentButtons.Count == 0)
            {
                var button = GetNavigationButton();
                button.Tag = buttontag;
                button.Text = buttontag;
                button.Name = name;
                button.Click += handler;
                button.Click += SetSelectedButton;
                DisableButton(button);             
                _currentButtons.Add(button);
                button.Visible = true;
                button.Enabled = true;
                _currentForm.Controls.Add(button);
                //_currentContainer.Controls.Add(button);
                button.Show();
                button.BringToFront();
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
                _currentForm.Controls.Add(button);
                //_currentContainer.Controls.Add(button);
                button.Show();
                button.BringToFront();
                return button;
            }
        }

        private Button GetNavigationButton(int position = 0)
        {
            Button button = new Button();
            button.Location = new Point(-2, 0 + (position * 50) + 90);
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
            foreach(var button in _currentButtons)
            {
                _currentForm.Controls.Remove(button);
            }
            _currentButtons.Clear();
        }

        public void MenuOnLogin()
        {
            _currentForm.MenuOnLogin();
        }
    }
}
