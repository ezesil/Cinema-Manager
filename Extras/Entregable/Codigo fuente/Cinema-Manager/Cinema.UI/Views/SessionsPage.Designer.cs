namespace Cinema.UI.Views
{
    partial class SessionsPage
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.datePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.comboBuscarPelicula = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCambiarSala = new System.Windows.Forms.ComboBox();
            this.comboCambiarPelicula = new System.Windows.Forms.ComboBox();
            this.pickerCambiarFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEliminar.Location = new System.Drawing.Point(615, 301);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(288, 23);
            this.BtnEliminar.TabIndex = 40;
            this.BtnEliminar.Text = "Eliminar seleccionado";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnModificar.Location = new System.Drawing.Point(764, 272);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(139, 23);
            this.BtnModificar.TabIndex = 39;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Pelicula:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Fecha:";
            // 
            // BtnCrear
            // 
            this.BtnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCrear.Location = new System.Drawing.Point(615, 272);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(143, 23);
            this.BtnCrear.TabIndex = 31;
            this.BtnCrear.Text = "Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPrincipal.Location = new System.Drawing.Point(3, 159);
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.RowTemplate.Height = 25;
            this.GridPrincipal.Size = new System.Drawing.Size(599, 283);
            this.GridPrincipal.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Hasta:";
            // 
            // datePickerHasta
            // 
            this.datePickerHasta.Location = new System.Drawing.Point(60, 105);
            this.datePickerHasta.Name = "datePickerHasta";
            this.datePickerHasta.Size = new System.Drawing.Size(227, 23);
            this.datePickerHasta.TabIndex = 44;
            // 
            // datePickerDesde
            // 
            this.datePickerDesde.Location = new System.Drawing.Point(60, 76);
            this.datePickerDesde.Name = "datePickerDesde";
            this.datePickerDesde.Size = new System.Drawing.Size(227, 23);
            this.datePickerDesde.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Desde:";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.Location = new System.Drawing.Point(3, 134);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(599, 23);
            this.BtnBuscar.TabIndex = 41;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // comboBuscarPelicula
            // 
            this.comboBuscarPelicula.FormattingEnabled = true;
            this.comboBuscarPelicula.Location = new System.Drawing.Point(60, 46);
            this.comboBuscarPelicula.Name = "comboBuscarPelicula";
            this.comboBuscarPelicula.Size = new System.Drawing.Size(227, 23);
            this.comboBuscarPelicula.TabIndex = 46;
            this.comboBuscarPelicula.DropDown += new System.EventHandler(this.comboBuscarPelicula_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 47;
            this.label6.Text = "Pelicula:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 48;
            this.label4.Text = "Sala:";
            // 
            // comboCambiarSala
            // 
            this.comboCambiarSala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCambiarSala.FormattingEnabled = true;
            this.comboCambiarSala.Location = new System.Drawing.Point(672, 243);
            this.comboCambiarSala.Name = "comboCambiarSala";
            this.comboCambiarSala.Size = new System.Drawing.Size(231, 23);
            this.comboCambiarSala.TabIndex = 50;
            this.comboCambiarSala.DropDown += new System.EventHandler(this.comboCambiarSala_DropDown);
            // 
            // comboCambiarPelicula
            // 
            this.comboCambiarPelicula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCambiarPelicula.FormattingEnabled = true;
            this.comboCambiarPelicula.Location = new System.Drawing.Point(672, 214);
            this.comboCambiarPelicula.Name = "comboCambiarPelicula";
            this.comboCambiarPelicula.Size = new System.Drawing.Size(231, 23);
            this.comboCambiarPelicula.TabIndex = 51;
            this.comboCambiarPelicula.DropDown += new System.EventHandler(this.comboCambiarPelicula_DropDown);
            // 
            // pickerCambiarFecha
            // 
            this.pickerCambiarFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickerCambiarFecha.Location = new System.Drawing.Point(672, 156);
            this.pickerCambiarFecha.Name = "pickerCambiarFecha";
            this.pickerCambiarFecha.Size = new System.Drawing.Size(231, 23);
            this.pickerCambiarFecha.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(615, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 53;
            this.label7.Text = "Hora:";
            // 
            // txtHora
            // 
            this.txtHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHora.Location = new System.Drawing.Point(672, 185);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(231, 23);
            this.txtHora.TabIndex = 54;
            // 
            // SessionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pickerCambiarFecha);
            this.Controls.Add(this.comboCambiarPelicula);
            this.Controls.Add(this.comboCambiarSala);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBuscarPelicula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePickerHasta);
            this.Controls.Add(this.datePickerDesde);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.GridPrincipal);
            this.Name = "SessionsPage";
            this.Size = new System.Drawing.Size(925, 445);
            this.Tag = "text_sessionspage";
            this.Load += new System.EventHandler(this.SessionsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.DataGridView GridPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerHasta;
        private System.Windows.Forms.DateTimePicker datePickerDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.ComboBox comboBuscarPelicula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboCambiarSala;
        private System.Windows.Forms.ComboBox comboCambiarPelicula;
        private System.Windows.Forms.DateTimePicker pickerCambiarFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHora;
    }
}
