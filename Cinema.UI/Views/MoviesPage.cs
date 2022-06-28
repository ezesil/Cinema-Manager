using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.Business;
using Cinema.Domain;
using Cinema.UI.Extensions;

namespace Cinema.UI.Views
{
    public partial class MoviesPage : UserControl
    {

        private Guid? currentMovieGuid;
        
        public MoviesPage()
        {
            InitializeComponent();
            this.Name = "Peliculas";
        }

        private void MoviesPage_Load(object sender, EventArgs e)
        {
            GridPrincipal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridPrincipal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridPrincipal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridPrincipal.ReadOnly = true;
            GridPrincipal.CellClick += GridCellClick;
            TxtActivo.Items.Add("No");
            TxtActivo.Items.Add("Si");
        }

        private string GetCellValue(object sender, int index)
        {
            return (sender as DataGridView).SelectedRows[0]?.Cells[index]?.Value?.ToString();
        }

        private void GridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currentMovieGuid = Guid.Parse(GetCellValue(sender, 0));
                TxtNombre.Text = GetCellValue(sender, 1);
                TxtIdioma.Text = GetCellValue(sender, 2);
                TxtSubtitulos.Text = GetCellValue(sender, 3);
                TxtActivo.SelectedIndex = bool.Parse(GetCellValue(sender, 4).ToString()) ? 1 : 0;
                TxtDuracion.Text = GetCellValue(sender, 5);                   
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadData(DataTable dt)
        {
            this.GridPrincipal.DataSource = null;
            this.GridPrincipal.DataSource = dt;
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            LoadData(GridViewAdapters.Adapt(MoviesBLL.Current.GetAllMovies()));
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
