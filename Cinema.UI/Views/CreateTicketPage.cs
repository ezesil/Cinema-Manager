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

namespace Cinema.UI.Views
{
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
            if (e.RowIndex > seats.RowsCount || e.ColumnIndex > seats.ColumnsCount || e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            CurrentSeat = seats.Items[e.RowIndex][e.ColumnIndex];
            CanSubmit();
        }

        private void PaginaInicio_Load(object sender, EventArgs e)
        {

        }

        private void ComboPeliculas_DropDown(object sender, EventArgs e)
        {
            ComboPeliculas.Items.Clear();

            CurrentPeliculas = MoviesBLL.Current.GetAllMovies();
            ComboPeliculas.Items.AddRange(CurrentPeliculas.ToArray());
            
        }

        private void ComboDiaSesion_DropDown(object sender, EventArgs e)
        {
            ComboDiaSesion.Items.Clear();

            var sessions = SessionsBLL.Current.GetAllCompleteSessions();
            ComboDiaSesion.Items.AddRange(sessions.Where(x => x.MovieId == CurrentPelicula.Id).ToArray());
        }

        public void ClearAll()
        {
            ClearPeliculas();
            ClearDias();
            ClearAsientos();
            BtnCrearTicket.Enabled = false;       
        }
        public void ClearPeliculas()
        {
            ComboPeliculas.Items.Clear();
            ComboPeliculas.SelectedIndex = -1;
            ComboPeliculas.ResetText();
            ComboPeliculas.Text = "";
            BtnCrearTicket.Enabled = false;
        }
        public void ClearDias()
        {
            ComboDiaSesion.Items.Clear();
            ComboDiaSesion.SelectedIndex = -1;
            ComboDiaSesion.ResetText();
            ComboDiaSesion.Text = "";
            BtnCrearTicket.Enabled = false;
        }
        public void ClearAsientos()
        {
            seats.ClearOccupied();
            GridAsientos.DataSource = seats.ToDataTable();
            BtnCrearTicket.Enabled = false;
        }


        private void ComboPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearDias();
                ClearAsientos();

                CurrentPelicula = ComboPeliculas.GetSelectedObject<Movie>();

                CanSubmit();
            }
            catch (Exception ex)
            {

                _exhandler.Handle(ex);
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
                _exhandler.Handle(ex);
            }
        }

        private void BtnLimpiarCampos_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void BtnCrearTicket_Click(object sender, EventArgs e)
        {

            var tickets = TicketsBLL.Current.GetAllTickets();

            if (tickets.Where(x => x.SeatNumber == CurrentSeat.SeatNumber && x.Row == CurrentSeat.Row && x.SessionId == CurrentSession.Id).Any())
                MessageBox.Show(_languageService.TranslateCode("text_error_seat_occupied"));

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

        private void ActualizarGrid()
        {
            ClearAsientos();
           
            var tickets = TicketsBLL.Current.GetAllTickets().Where(x => x.SessionId == CurrentSession.Id).ToList();

            tickets.ForEach(x => seats.Items[x.Row][x.SeatNumber] = new Seat(x.Row, x.SeatNumber, true));

            GridAsientos.DataSource = seats.ToDataTable();

            tickets.ForEach(x => GridAsientos.Rows[x.Row].Cells[x.SeatNumber].Style.BackColor = Color.Green);

            GridAsientos.ClearSelection();
        }
    }
}
