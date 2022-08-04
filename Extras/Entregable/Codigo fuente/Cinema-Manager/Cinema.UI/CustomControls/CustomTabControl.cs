using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Cinema.UI.CustomControls
{
    /// <summary>
    /// Summary description for TabControl.
    /// </summary>
    public class CustomTabControl : System.Windows.Forms.TabControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public CustomTabControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        #region Interop

        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public IntPtr HWND;
            public uint idFrom;
            public int code;
            public override String ToString()
            {
                return String.Format("Hwnd: {0}, ControlID: {1}, Code: {2}", HWND, idFrom, code);
            }
        }

        private const int TCN_FIRST = 0 - 550;
        private const int TCN_SELCHANGING = (TCN_FIRST - 2);

        private const int WM_USER = 0x400;
        private const int WM_NOTIFY = 0x4E;
        private const int WM_REFLECT = WM_USER + 0x1C00;

        #endregion

        #region BackColor Manipulation

        //As well as exposing the property to the Designer we want it to behave just like any other 
        //controls BackColor property so we need some clever manipulation.

        private Color m_Backcolor = Color.Empty;

        /// <summary>
        /// Color de fondo
        /// </summary>
        [Browsable(true), Description("The background color used to display text and graphics in a control.")]
        public override Color BackColor
        {
            get
            {
                if (m_Backcolor.Equals(Color.Empty))
                {
                    if (Parent == null)
                        return Control.DefaultBackColor;
                    else
                        return Parent.BackColor;
                }
                return m_Backcolor;
            }
            set
            {
                if (m_Backcolor.Equals(value)) return;
                m_Backcolor = value;
                Invalidate();
                //Let the Tabpages know that the backcolor has changed.
                base.OnBackColorChanged(EventArgs.Empty);
            }
        }
        /// <summary>
        /// Revisa el color de fondo. Si se puede serializar, devuelve true. Sino, false.
        /// </summary>
        public bool ShouldSerializeBackColor()
        {
            return !m_Backcolor.Equals(Color.Empty);
        }

        /// <summary>
        /// Reinicia el color de fondo;
        /// </summary>
        public override void ResetBackColor()
        {
            m_Backcolor = Color.Empty;
            Invalidate();
        }

        #endregion
        /// <summary>
        /// Evento en caso de que el color del parent cambie.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }

        /// <summary>
        /// Evento en cambio de indice.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Invalidate();
        }

        /// <summary>
        /// Evento de dibujado.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            Rectangle r = ClientRectangle;
            if (TabCount <= 0) return;
            //Draw a custom background for Transparent TabPages
            r = SelectedTab.Bounds;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Font DrawFont = new Font(Font.FontFamily, 24, FontStyle.Regular, GraphicsUnit.Pixel);
            ControlPaint.DrawStringDisabled(e.Graphics, "Micks Ownerdraw TabControl", DrawFont, BackColor, (RectangleF)r, sf);
            DrawFont.Dispose();
            //Draw a border around TabPage
            r.Inflate(3, 3);
            TabPage tp = TabPages[SelectedIndex];
            SolidBrush PaintBrush = new SolidBrush(tp.BackColor);
            e.Graphics.FillRectangle(PaintBrush, r);
            ControlPaint.DrawBorder(e.Graphics, r, PaintBrush.Color, ButtonBorderStyle.Outset);
            //Draw the Tabs
            for (int index = 0; index <= TabCount - 1; index++)
            {
                tp = TabPages[index];
                r = GetTabRect(index);
                ButtonBorderStyle bs = ButtonBorderStyle.Outset;
                if (index == SelectedIndex) bs = ButtonBorderStyle.Inset;
                PaintBrush.Color = tp.BackColor;
                e.Graphics.FillRectangle(PaintBrush, r);
                ControlPaint.DrawBorder(e.Graphics, r, PaintBrush.Color, bs);
                PaintBrush.Color = tp.ForeColor;

                //Set up rotation for left and right aligned tabs
                if (Alignment == TabAlignment.Left || Alignment == TabAlignment.Right)
                {
                    float RotateAngle = 90;
                    if (Alignment == TabAlignment.Left) RotateAngle = 270;
                    PointF cp = new PointF(r.Left + (r.Width >> 1), r.Top + (r.Height >> 1));
                    e.Graphics.TranslateTransform(cp.X, cp.Y);
                    e.Graphics.RotateTransform(RotateAngle);
                    r = new Rectangle(-(r.Height >> 1), -(r.Width >> 1), r.Height, r.Width);
                }
                //Draw the Tab Text
                if (tp.Enabled)
                    e.Graphics.DrawString(tp.Text, Font, PaintBrush, (RectangleF)r, sf);
                else
                    ControlPaint.DrawStringDisabled(e.Graphics, tp.Text, Font, tp.BackColor, (RectangleF)r, sf);

                e.Graphics.ResetTransform();
            }

            PaintBrush.Dispose();

        }

        /// <summary>
        /// Occurs as a tab is being changed.
        /// </summary>
        [Description("Occurs as a tab is being changed.")]
        public event SelectedTabPageChangeEventHandler SelectedIndexChanging;

        /// <summary>
        /// Procesa mensajes de windows.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_NOTIFY))
            {
                NMHDR hdr = (NMHDR)(Marshal.PtrToStructure(m.LParam, typeof(NMHDR)));
                if (hdr.code == TCN_SELCHANGING)
                {
                    TabPage tp = TestTab(PointToClient(Cursor.Position));
                    if (tp != null)
                    {
                        TabPageChangeEventArgs e = new TabPageChangeEventArgs(SelectedTab, tp);
                        if (SelectedIndexChanging != null)
                            SelectedIndexChanging(this, e);
                        if (e.Cancel || tp.Enabled == false)
                        {
                            m.Result = new IntPtr(1);
                            return;
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }


        private TabPage TestTab(Point pt)
        {
            for (int index = 0; index <= TabCount - 1; index++)
            {
                if (GetTabRect(index).Contains(pt.X, pt.Y))
                    return TabPages[index];
            }
            return null;
        }

    }

    /// <summary>
    /// Argumentos de evento de cambio de pagina.
    /// </summary>
    public class TabPageChangeEventArgs : EventArgs
    {
        private TabPage _Selected = null;
        private TabPage _PreSelected = null;

        /// <summary>
        /// Indica si se canceló la navegacion.
        /// </summary>
        public bool Cancel { get; set; } = false;

        /// <summary>
        /// Pagina actual.
        /// </summary>
        public TabPage CurrentTab
        {
            get
            {
                return _Selected;
            }
        }

        /// <summary>
        /// Proxima pagina.
        /// </summary>
        public TabPage NextTab
        {
            get
            {
                return _PreSelected;
            }
        }

        /// <summary>
        /// Constructor para CustomTabControl.
        /// </summary>
        /// <param name="CurrentTab"></param>
        /// <param name="NextTab"></param>
        public TabPageChangeEventArgs(TabPage CurrentTab, TabPage NextTab)
        {
            _Selected = CurrentTab;
            _PreSelected = NextTab;
        }


    }

    /// <summary>
    /// Delegado invocado cuando la pagina cambia.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void SelectedTabPageChangeEventHandler(Object sender, TabPageChangeEventArgs e);

}
