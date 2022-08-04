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
    /// <summary>
    /// Pagina de salas.
    /// </summary>
    public partial class RoomsPage : UserControl
    {
        private Guid? currentRoomGuid;
        private LanguageService _languageService;

        /// <summary>
        /// Constructor por defecto con los lenguajes necesarios para operar. Hecho para contenedor de inyeccion de dependencia.
        /// </summary>
        /// <param name="languageService"></param>
        public RoomsPage(LanguageService languageService)
        {
            InitializeComponent();
            _languageService = languageService;
            this.Name = "text_rooms";
        }

        private void RoomsPage_Load(object sender, EventArgs e)
        {
            GridPrincipal.SetupBehaviour(GridCellClick);
            ComboActivo.Items.Add("No");
            ComboActivo.Items.Add("Si");
        }

        private void GridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var room = GridPrincipal.GetCellValues<Room>();

                currentRoomGuid = room.Id;
                TxtIdentificador.Text = room.Identifier;
                ComboPantallaGigante.SelectedIndex = room.HasBigScreen ? 1 : 0;
                Combo3D.SelectedIndex = room.Has3D ? 1 : 0;
                ComboActivo.SelectedIndex = room.IsActive ? 1 : 0;
            }
            catch (Exception ex)
            {

            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            GridPrincipal.Clear();
            RoomsBLL.Current.GetAllRooms().ForEach(x => GridPrincipal.Add(x));
            GridPrincipal.UpdateNames<Room>(x => _languageService.TranslateCode(x));


            GridPrincipal.Add(new object());
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
