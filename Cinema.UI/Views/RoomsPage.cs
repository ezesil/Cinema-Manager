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
    public partial class RoomsPage : UserControl
    {
        private Guid? currentRoomGuid;

        public RoomsPage()
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
            ComboActivo.Items.Add("No");
            ComboActivo.Items.Add("Si");
        }

        private string GetCellValue(object sender, int index)
        {
            return (sender as DataGridView).SelectedRows[0]?.Cells[index]?.Value?.ToString();
        }

        private void GridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currentRoomGuid = Guid.Parse(GetCellValue(sender, 0));
                TxtIdentificador.Text = GetCellValue(sender, 1);
                ComboPantallaGigante.SelectedIndex = bool.Parse(GetCellValue(sender, 2).ToString()) ? 1 : 0;
                Combo3D.SelectedIndex = bool.Parse(GetCellValue(sender, 3).ToString()) ? 1 : 0;
                ComboActivo.SelectedIndex = bool.Parse(GetCellValue(sender, 4).ToString()) ? 1 : 0;
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

        private void Actualizar_Click(object sender, EventArgs e)
        {
            LoadData(GridViewAdapters.Adapt(RoomsBLL.Current.GetAllRooms()));
        }

        private void LimpiarCampos_Click(object sender, EventArgs e)
        {
            currentRoomGuid = null;
            TxtIdentificador.Text = "";
            ComboPantallaGigante.SelectedIndex = 0;
            Combo3D.SelectedIndex = 0;
            ComboActivo.SelectedIndex = 0;
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            Room room = new Room()
            {
                Id = currentRoomGuid,
                Identifier = TxtIdentificador.Text,
                HasBigScreen = ComboPantallaGigante.SelectedIndex == 1 ? true : false,
                Has3D = Combo3D.SelectedIndex == 1 ? true : false,
                IsActive = ComboActivo.SelectedIndex == 1 ? true : false,
            };
            RoomsBLL.Current.CreateRoom(room);
            BtnActualizar.PerformClick();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Room room = new Room()
            {
                Id = currentRoomGuid,
                Identifier = TxtIdentificador.Text,
                HasBigScreen = ComboPantallaGigante.SelectedIndex == 1 ? true : false,
                Has3D = Combo3D.SelectedIndex == 1 ? true : false,
                IsActive = ComboActivo.SelectedIndex == 1 ? true : false,
            };

            RoomsBLL.Current.UpdateRoom(room);
            BtnActualizar.PerformClick();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            RoomsBLL.Current.DeleteRoom(currentRoomGuid);
            BtnActualizar.PerformClick();
        }

    }
}
