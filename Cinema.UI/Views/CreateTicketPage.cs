using BaseServices.Services;
using Cinema.Business;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.UI.Extensions;
using BaseServices.Services.Extensions;
using Cinema.UI.Exceptions;

namespace Cinema.UI.Views
{
    /// <summary>
    /// Pagina de generacion de tickets para una sesion de una pelicula.
    /// </summary>
    public partial class CreateTicketPage : UserControl
    {
        private Logger _logger;
        private ExceptionHandler _exhandler;
        private LanguageService _languageService;
        private SessionService _sessionService;

        private List<Movie> CurrentPeliculas;
        private List<Session> CurrentSessions;

        private Movie CurrentPelicula;
        private Session CurrentSession;

        SeatMatrix seats;
        Seat CurrentSeat;

        /// <summary>
        /// Constructor con los servicios necesarios para operar.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exmanager"></param>
        /// <param name="languageService"></param>
        /// <param name="sessionService"></param>
        public CreateTicketPage(Logger logger,
            ExceptionHandler exmanager,
            LanguageService languageService,
            SessionService sessionService)
        {
            InitializeComponent();

            this.Name = "text_ticket_creation";

            _logger = logger;
            _exhandler = exmanager;
            _languageService = languageService;
            _sessionService = sessionService;

            GridAsientos.SetupBehaviour(GridAsientosCellClick, x => 
            {
                for (int i = 0; i < x.Columns.Count - 1; i++)
                {
                    x.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                x.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                return x;
            });

            GridAsientos.ColumnHeadersVisible = false;
            GridAsientos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GridAsientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridAsientos.MultiSelect = false;

            seats = new SeatMatrix(10, 10);

            ComboDiaSesion.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboPeliculas.DropDownStyle = ComboBoxStyle.DropDownList;

            ClearAll();
        }

        /// <summary>
        /// Verificar si se puede proceder con la generacion del ticket. Si es correcto, el boton de creacion se habilitará.
        /// </summary>
        public void CanSubmit()
        {
            if (ComboPeliculas.SelectedIndex != -1 && ComboDiaSesion.SelectedIndex != -1 && GridAsientos.SelectedCells.Count > 0)
            {
                BtnCrearTicket.Enabled = true;
            }
            else
                BtnCrearTicket.Enabled = false;
        }

        private void GridAsientosCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > seats.RowsCount || e.ColumnIndex > seats.ColumnsCount || e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                CurrentSeat = seats.Items[e.RowIndex][e.ColumnIndex];
                CanSubmit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void PaginaInicio_Load(object sender, EventArgs e)
        {

        }

        private void ComboPeliculas_DropDown(object sender, EventArgs e)
        {
            try
            {
                ComboPeliculas.Items.Clear();

                CurrentPeliculas = MoviesBLL.Current.GetAllMovies();
                ComboPeliculas.Items.AddRange(CurrentPeliculas.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
            
        }

        private void ComboDiaSesion_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (ComboPeliculas.SelectedIndex == -1)
                    return;
                ComboDiaSesion.Items.Clear();

                var sessions = SessionsBLL.Current.GetAllCompleteSessions();
                ComboDiaSesion.Items.AddRange(sessions.Where(x => x.MovieId == CurrentPelicula.Id).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        /// <summary>
        /// Devuelve todos los controles a su estado inicial.
        /// </summary>
        public void ClearAll()
        {
            ClearPeliculas();
            ClearDias();
            ClearAsientos();
            BtnCrearTicket.Enabled = false;       
        }


        /// <summary>
        /// Devuelve los controles relacionados con las peliculas a su estado inicial.
        /// </summary>
        public void ClearPeliculas()
        {
            ComboPeliculas.Items.Clear();
            ComboPeliculas.SelectedIndex = -1;
            ComboPeliculas.ResetText();
            ComboPeliculas.Text = "";
            BtnCrearTicket.Enabled = false;
        }

        /// <summary>
        /// Devuelve los controles relacionados con la fecha de la sesión a su estado inicial.
        /// </summary>
        public void ClearDias()
        {
            try
            {
                ComboDiaSesion.Items.Clear();
                ComboDiaSesion.SelectedIndex = -1;
                ComboDiaSesion.ResetText();
                ComboDiaSesion.Text = "";
                BtnCrearTicket.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        /// <summary>
        /// Devuelve los asientos en pantalla a su estado inicial.
        /// </summary>
        public void ClearAsientos()
        {
            try
            {
                seats.ClearOccupied();
                GridAsientos.DataSource = seats.ToDataTable();
                BtnCrearTicket.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }


        private void ComboPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearDias();
                ClearAsientos();

                CurrentPelicula = ComboPeliculas.GetSelectedObject<Movie>();

                ComboDiaSesion.Enabled = CurrentPelicula == null ? false : true;

                CanSubmit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void ComboDiaSesion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentSession = ComboDiaSesion.GetSelectedObject<Session>();

                ActualizarGrid();

                CanSubmit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnLimpiarCampos_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void BtnCrearTicket_Click(object sender, EventArgs e)
        {

            try
            {
                var tickets = TicketsBLL.Current.GetAllTickets();

                if (tickets.Where(x => x.SeatNumber == CurrentSeat.SeatNumber && x.Row == CurrentSeat.Row && x.SessionId == CurrentSession.Id).Any())
                    throw new SeatOccupiedException();

                var ticket = new Ticket()
                {
                    SeatNumber = CurrentSeat.SeatNumber,
                    Row = CurrentSeat.Row,
                    Id = Guid.NewGuid(),
                    CreationTime = DateTime.Now,
                    SessionId = CurrentSession.Id,
                    CreatorUserId = _sessionService.CurrentUserGuid
                };

                TicketsBLL.Current.CreateTicket(ticket);

                ActualizarGrid();

                MessageBox.Show(_languageService.TranslateCode("text_ok_ticket_created"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void ActualizarGrid()
        {
            try
            {
                ClearAsientos();

                var tickets = TicketsBLL.Current.GetAllTickets().Where(x => x.SessionId == CurrentSession.Id).ToList();

                tickets.ForEach(x => seats.Items[x.Row][x.SeatNumber] = new Seat(x.Row, x.SeatNumber, true));

                GridAsientos.DataSource = seats.ToDataTable();

                tickets.ForEach(x => GridAsientos.Rows[x.Row].Cells[x.SeatNumber].Style.BackColor = Color.Green);

                GridAsientos.ClearSelection();
            }
            catch (Exception ex)
            {
                throw _exhandler.Handle(ex);
            }
        }
    }
}
