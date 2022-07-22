using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseServices.Services;
using Cinema.Business;
using Cinema.Domain;
using Cinema.UI.Extensions;

namespace Cinema.UI.Views
{
    public partial class MoviesPage : UserControl
    {
        private Guid? currentMovieGuid;
        private LanguageService _languageService;

        public MoviesPage(LanguageService languageService)
        {
            InitializeComponent();
            _languageService = languageService;
            this.Name = "text_movies";
        }

        private void MoviesPage_Load(object sender, EventArgs e)
        {
            GridPrincipal.SetupBehaviour(GridCellClick);
            TxtActivo.Items.Add("No");
            TxtActivo.Items.Add("Si");
        }

        private void GridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var movie = new Movie();
                

                (
                var MovieGuid,
                var Nombre,
                var Idioma,
                var Subtitulos,
                var Activo,
                var Duracion
                ) = GridPrincipal.GetCellValues<(Guid, string, string, string, bool, string)>();

                
               var test = GridPrincipal.GetCellValues<Movie>();

                currentMovieGuid = MovieGuid;
                TxtNombre.Text = Nombre;
                TxtIdioma.Text = Idioma;
                TxtSubtitulos.Text = Subtitulos;
                TxtActivo.SelectedIndex = Activo ? 1 : 0;
                TxtDuracion.Text = Duracion;
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            GridPrincipal.Clear();
            MoviesBLL.Current.GetAllMovies().ForEach(x => GridPrincipal.Add(x));
            GridPrincipal.UpdateNames<Movie>(x => _languageService.TranslateCode(x));
        }

        private void LimpiarCampos_Click(object sender, EventArgs e)
        {
            currentMovieGuid = null;
            TxtNombre.Text = "";
            TxtIdioma.Text = "";
            TxtSubtitulos.Text = "";
            TxtActivo.SelectedIndex = -1;
            TxtDuracion.Text = "";
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie()
            {
                Id = currentMovieGuid,
                Name = TxtNombre.Text,
                Language = TxtIdioma.Text,
                SubtitleLanguage = TxtSubtitulos.Text,
                IsActive = TxtActivo.SelectedIndex == 1 ? true
                            : TxtActivo.SelectedIndex == 0 ? false
                            : throw new Exception("No se seleccionó un estado de la pelicula."),
                Duration = int.Parse(TxtDuracion.Text)
            };
            MoviesBLL.Current.CreateMovie(movie);
            BtnActualizar.PerformClick();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie()
            {
                Id = currentMovieGuid,
                Name = TxtNombre.Text,
                Language = TxtIdioma.Text,
                SubtitleLanguage = TxtSubtitulos.Text,
                IsActive = TxtActivo.SelectedIndex == 1 ? true
                            : TxtActivo.SelectedIndex == 0 ? false
                            : throw new Exception("No se seleccionó un estado de la pelicula."),
                Duration = int.Parse(TxtDuracion.Text)
            };

            MoviesBLL.Current.UpdateMovie(movie);
            BtnActualizar.PerformClick();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            MoviesBLL.Current.DeleteMovie(currentMovieGuid);
            BtnActualizar.PerformClick();
        }
    }
}
