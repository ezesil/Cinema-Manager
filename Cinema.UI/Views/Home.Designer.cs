namespace Cinema.UI.Views
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnAdministracion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPeliculas = new System.Windows.Forms.Button();
            this.BtnSesiones = new System.Windows.Forms.Button();
            this.BtnTickets = new System.Windows.Forms.Button();
            this.BtnGenerarTicket = new System.Windows.Forms.Button();
            this.BotonInicio = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.splitContainer1.Panel1.Controls.Add(this.BtnAdministracion);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.BtnPeliculas);
            this.splitContainer1.Panel1.Controls.Add(this.BtnSesiones);
            this.splitContainer1.Panel1.Controls.Add(this.BtnTickets);
            this.splitContainer1.Panel1.Controls.Add(this.BtnGenerarTicket);
            this.splitContainer1.Panel1.Controls.Add(this.BotonInicio);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 136;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // BtnAdministracion
            // 
            this.BtnAdministracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.BtnAdministracion.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAdministracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdministracion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAdministracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.BtnAdministracion.Location = new System.Drawing.Point(5, 317);
            this.BtnAdministracion.Name = "BtnAdministracion";
            this.BtnAdministracion.Size = new System.Drawing.Size(126, 31);
            this.BtnAdministracion.TabIndex = 7;
            this.BtnAdministracion.Text = "Administración";
            this.BtnAdministracion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdministracion.UseVisualStyleBackColor = false;
            this.BtnAdministracion.Click += new System.EventHandler(this.BtnAdministracion_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 119);
            this.panel1.TabIndex = 6;
            // 
            // BtnPeliculas
            // 
            this.BtnPeliculas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.BtnPeliculas.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnPeliculas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPeliculas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnPeliculas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.BtnPeliculas.Location = new System.Drawing.Point(5, 280);
            this.BtnPeliculas.Name = "BtnPeliculas";
            this.BtnPeliculas.Size = new System.Drawing.Size(126, 31);
            this.BtnPeliculas.TabIndex = 3;
            this.BtnPeliculas.Text = "Peliculas";
            this.BtnPeliculas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPeliculas.UseVisualStyleBackColor = false;
            this.BtnPeliculas.Click += new System.EventHandler(this.BtnPeliculas_Click);
            // 
            // BtnSesiones
            // 
            this.BtnSesiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.BtnSesiones.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnSesiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSesiones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSesiones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.BtnSesiones.Location = new System.Drawing.Point(5, 243);
            this.BtnSesiones.Name = "BtnSesiones";
            this.BtnSesiones.Size = new System.Drawing.Size(126, 31);
            this.BtnSesiones.TabIndex = 2;
            this.BtnSesiones.Text = "Sesiones";
            this.BtnSesiones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSesiones.UseVisualStyleBackColor = false;
            this.BtnSesiones.Click += new System.EventHandler(this.BtnSesiones_Click);
            // 
            // BtnTickets
            // 
            this.BtnTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.BtnTickets.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTickets.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnTickets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.BtnTickets.Location = new System.Drawing.Point(5, 206);
            this.BtnTickets.Name = "BtnTickets";
            this.BtnTickets.Size = new System.Drawing.Size(126, 31);
            this.BtnTickets.TabIndex = 1;
            this.BtnTickets.Text = "Tickets";
            this.BtnTickets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTickets.UseVisualStyleBackColor = false;
            this.BtnTickets.Click += new System.EventHandler(this.BtnTickets_Click);
            // 
            // BtnGenerarTicket
            // 
            this.BtnGenerarTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.BtnGenerarTicket.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnGenerarTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarTicket.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerarTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.BtnGenerarTicket.Location = new System.Drawing.Point(5, 169);
            this.BtnGenerarTicket.Name = "BtnGenerarTicket";
            this.BtnGenerarTicket.Size = new System.Drawing.Size(126, 31);
            this.BtnGenerarTicket.TabIndex = 1;
            this.BtnGenerarTicket.Text = "Generar ticket";
            this.BtnGenerarTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGenerarTicket.UseVisualStyleBackColor = false;
            this.BtnGenerarTicket.Click += new System.EventHandler(this.BtnGenerarTicket_Click);
            // 
            // BotonInicio
            // 
            this.BotonInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.BotonInicio.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.BotonInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonInicio.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BotonInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.BotonInicio.Location = new System.Drawing.Point(5, 132);
            this.BotonInicio.Name = "BotonInicio";
            this.BotonInicio.Size = new System.Drawing.Size(126, 31);
            this.BotonInicio.TabIndex = 0;
            this.BotonInicio.Tag = "main_button";
            this.BotonInicio.Text = "Inicio";
            this.BotonInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BotonInicio.UseVisualStyleBackColor = false;
            this.BotonInicio.Click += new System.EventHandler(this.BotonInicio_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.splitContainer2.Size = new System.Drawing.Size(647, 561);
            this.splitContainer2.SplitterDistance = 118;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BotonInicio;
        private System.Windows.Forms.Button BtnTickets;
        private System.Windows.Forms.Button BtnGenerarTicket;
        private System.Windows.Forms.Button BtnPeliculas;
        private System.Windows.Forms.Button BtnSesiones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button BtnAdministracion;
    }
}