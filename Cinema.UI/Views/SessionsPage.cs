using BaseServices.Services;
using Cinema.Business;
using Cinema.Domain;
using Cinema.UI.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.Views
{
    public partial class SessionsPage : UserControl
    {
        private LanguageService _languageService;
        private Session selectedSession;
        private Room currentRoom;
        private Movie currentMovie;
        public SessionsPage(LanguageService languageService)
        {
            InitializeComponent();
            _languageService = languageService;
            this.Name = "text_sessions";
        }

        private void SessionsPage_Load(object sender, EventArgs e)
        {
            GridPrincipal.SetupBehaviour(CellClick);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            GridPrincipal.Clear();
            SessionsBLL.Current.GetAllSessions().ForEach(session => GridPrincipal.Add(session));
            GridPrincipal.UpdateNames<Session>(x => _languageService.TranslateCode(x));
        }

        private void CellClick(object sender, EventArgs e)
        {
            try
            {
                selectedSession = GridPrincipal.GetCellValues<Session>();
                currentMovie = MoviesBLL.Current.GetMovie(selectedSession.MovieId);
                currentRoom = RoomsBLL.Current.GetRoom(selectedSession.RoomId);

                pickerCambiarFecha.Value = selectedSession.Date;
                txtHora.Text = selectedSession.Date.ToShortTimeString();

                comboCambiarPelicula.Items.Clear();
                if(comboCambiarPelicula.Items.Cast<Movie>().Where(x => x.Id == currentMovie.Id).Count() >= 1)
                    comboCambiarPelicula.Items.Add(currentMovie);

                comboCambiarPelicula.SelectedItem = currentMovie;
                comboCambiarPelicula.Text = currentMovie.Name;

                comboCambiarSala.Items.Clear();
                if (comboCambiarSala.Items.Cast<Room>().Where(x => x.Id == currentRoom.Id).Count() >= 1)
                    comboCambiarSala.Items.Add(currentRoom);
                comboCambiarSala.SelectedItem = currentRoom;
                comboCambiarSala.Text = currentRoom.Identifier;
            }
            catch (Exception ex)
            {

            }
        }

        private void comboBuscarPelicula_DropDown(object sender, EventArgs e)
        {
            comboBuscarPelicula.Items.Clear();
            MoviesBLL.Current.GetAllMovies().ForEach(movie => comboBuscarPelicula.Items.Add(movie));
        }

        private void comboCambiarPelicula_DropDown(object sender, EventArgs e)
        {
            comboCambiarPelicula.Items.Clear();
            MoviesBLL.Current.GetAllMovies().ForEach(movie => comboCambiarPelicula.Items.Add(movie));
        }


        private void BtnModificar_Click(object sender, EventArgs e)
        {
            var session = new Session()
            {
                Id = selectedSession.Id,
                Date = pickerCambiarFecha.Value.Date.Add(TimeSpan.Parse(txtHora.Text)),
                MovieId = (comboCambiarPelicula.SelectedItem as Movie) == null ? currentMovie.Id : (comboCambiarPelicula.SelectedItem as Movie).Id,
                RoomId = (comboCambiarSala.SelectedItem as Room) == null ? currentRoom.Id : (comboCambiarSala.SelectedItem as Room).Id
            };

            SessionsBLL.Current.UpdateSession(session);

            BtnBuscar.PerformClick();
        }
        private void comboCambiarSala_DropDown(object sender, EventArgs e)
        {
            comboCambiarSala.Items.Clear();
            RoomsBLL.Current.GetAllRooms().ForEach(room => comboCambiarSala.Items.Add(room));
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            var session = new Session()
            {
                Id = Guid.NewGuid(),
                Date = pickerCambiarFecha.Value.Date.Add(TimeSpan.Parse(txtHora.Text)),
                MovieId = (comboCambiarPelicula.SelectedItem as Movie).Id,
                RoomId = (comboCambiarSala.SelectedItem as Room).Id
            };

            SessionsBLL.Current.CreateSession(session);
            BtnBuscar.PerformClick();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            SessionsBLL.Current.DeleteSession(selectedSession.Id);
            BtnBuscar.PerformClick();
        }

    }
}
