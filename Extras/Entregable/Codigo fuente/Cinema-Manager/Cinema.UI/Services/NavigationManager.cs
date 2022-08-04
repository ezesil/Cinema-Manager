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
    /// <summary>
    /// Clase para la gestion de navegadocion en un formulario.
    /// </summary>
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

        /// <summary>
        /// Delegado despues de navegar.
        /// </summary>
        public delegate void OnNavigatedEvent();

        /// <summary>
        /// Evento despues de navegar.
        /// </summary>
        public event OnNavigatedEvent OnNavigated;

        /// <summary>
        /// Delegado antes de navegar.
        /// </summary>
        public delegate void BeforeNavigatingEvent();

        /// <summary>
        /// Evento antes de navegar.
        /// </summary>
        public event BeforeNavigatingEvent BeforeNavigating;

        /// <summary>
        /// Servicio de sessiones.
        /// </summary>
        private SessionService _sessionService;

        /// <summary>
        /// Inicializa el servicio de gestion de navegacion con todos los parametros necesarios.
        /// </summary>
        /// <param name="currentform"></param>
        /// <param name="navMenuContainer"></param>
        /// <param name="userControlContainer"></param>
        /// <param name="sessionService"></param>
        /// <param name="currentPanel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Setea el container que va a utilizarse como header del formulario.
        /// </summary>
        /// <param name="headerContainer"></param>
        public void SetHeaderContainer(SplitterPanel headerContainer)
        {
            _currentHeaderContainer = headerContainer;
            _currentHeader = new GenericHeader();
            headerContainer.Controls.Clear();
            _currentHeader.Dock = DockStyle.Fill;
            headerContainer.Controls.Add(_currentHeader);
        }

        /// <summary>
        /// Setea el titulo del header de paginas.
        /// </summary>
        /// <param name="name"></param>
        public void SetHeaderTitle(string name)
        {
            if (_currentHeaderContainer == null || _currentHeader == null)
                return;

            _currentHeader.SetHeaderTitle(name);
        }

        /// <summary>
        /// Navega a la pagina especificada en su tipo generico.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public T? NavigateTo<T>(object? args) where T : UserControl
        {
            return NavigateTo<T>(null, args);
        }

        /// <summary>
        /// Navega a la pagina especificada en su tipo generico.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="canNavigateVerifier"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Activa un boton.
        /// </summary>
        /// <param name="button"></param>
        public void EnableButton(Button button)
        {
            // Color de texto ~violeta/gris
            //button.ForeColor = Color.FromArgb(114, 137, 218);
            // Color de fondo gris oscuro
            button.BackColor = Color.FromArgb(30, 33, 36);
            button.ForeColor = Color.Silver;
            button.Enabled = true;
        }

        /// <summary>
        /// Desactiva un boton.
        /// </summary>
        /// <param name="button"></param>
        public void DisableButton(Button button)
        {
            button.BackColor = Color.FromArgb(33, 150, 243);
            button.ForeColor = Color.Silver;
            button.Enabled = false;
        }

        /// <summary>
        /// Navegacion asincronica.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task NavigateToAsync<T>() where T : UserControl
        {
            await Task.Run(() => NavigateTo<T>());
        }

        /// <summary>
        /// Crea un boton con las acciones por defecto del controlador.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="name"></param>
        /// <param name="buttontag"></param>
        /// <param name="colorOverride"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtiene un boton de navegacion.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Borra todos los botones de un menu.
        /// </summary>
        public void ClearNavigationButtons()
        {
            foreach (var button in _currentButtons)
            {
                _currentNavMenuContainer.Controls.Remove(button);
            }
            _currentButtons.Clear();
        }

        /// <summary>
        /// Metodo que indica que la 
        /// </summary>
        public void MenuOnLogin()
        {
            _currentForm.MenuOnLogin();
        }
    }
}
