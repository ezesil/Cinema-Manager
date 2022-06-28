namespace Cinema.UI.Views
{
    partial class TicketsPage
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
            this.label4 = new System.Windows.Forms.Label();
            this.DateTimeHasta = new System.Windows.Forms.DateTimePicker();
            this.DateTimeDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFecha = new System.Windows.Forms.TextBox();
            this.TxtSala = new System.Windows.Forms.TextBox();
            this.TxtAsiento = new System.Windows.Forms.TextBox();
            this.TxtFila = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
            this.TxtPelicula = new System.Windows.Forms.TextBox();
            this.TxtFechaCreacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Hasta:";
            // 
            // DateTimeHasta
            // 
            this.DateTimeHasta.Location = new System.Drawing.Point(347, 21);
            this.DateTimeHasta.Name = "DateTimeHasta";
            this.DateTimeHasta.Size = new System.Drawing.Size(227, 23);
            this.DateTimeHasta.TabIndex = 18;
            // 
            // DateTimeDesde
            // 
            this.DateTimeDesde.Location = new System.Drawing.Point(66, 21);
            this.DateTimeDesde.Name = "DateTimeDesde";
            this.DateTimeDesde.Size = new System.Drawing.Size(227, 23);
            this.DateTimeDesde.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Desde:";
            // 
            // TxtFecha
            // 
            this.TxtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFecha.Location = new System.Drawing.Point(777, 166);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.Size = new System.Drawing.Size(212, 23);
            this.TxtFecha.TabIndex = 97;
            // 
            // TxtSala
            // 
            this.TxtSala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSala.Location = new System.Drawing.Point(777, 224);
            this.TxtSala.Name = "TxtSala";
            this.TxtSala.Size = new System.Drawing.Size(212, 23);
            this.TxtSala.TabIndex = 96;
            // 
            // TxtAsiento
            // 
            this.TxtAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAsiento.Location = new System.Drawing.Point(777, 137);
            this.TxtAsiento.Name = "TxtAsiento";
            this.TxtAsiento.Size = new System.Drawing.Size(212, 23);
            this.TxtAsiento.TabIndex = 95;
            // 
            // TxtFila
            // 
            this.TxtFila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFila.Location = new System.Drawing.Point(777, 108);
            this.TxtFila.Name = "TxtFila";
            this.TxtFila.Size = new System.Drawing.Size(212, 23);
            this.TxtFila.TabIndex = 94;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(682, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 93;
            this.label2.Text = "Sala:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(682, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 92;
            this.label7.Text = "Asiento:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 91;
            this.label5.Text = "Pelicula:";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.Location = new System.Drawing.Point(166, 50);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(308, 23);
            this.BtnBuscar.TabIndex = 90;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(682, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 87;
            this.label6.Text = "Fecha:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(682, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 86;
            this.label8.Text = "Fila:";
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPrincipal.Location = new System.Drawing.Point(13, 79);
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.RowTemplate.Height = 25;
            this.GridPrincipal.Size = new System.Drawing.Size(647, 394);
            this.GridPrincipal.TabIndex = 84;
            // 
            // TxtPelicula
            // 
            this.TxtPelicula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPelicula.Location = new System.Drawing.Point(777, 195);
            this.TxtPelicula.Name = "TxtPelicula";
            this.TxtPelicula.Size = new System.Drawing.Size(212, 23);
            this.TxtPelicula.TabIndex = 102;
            // 
            // TxtFechaCreacion
            // 
            this.TxtFechaCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFechaCreacion.Location = new System.Drawing.Point(777, 79);
            this.TxtFechaCreacion.Name = "TxtFechaCreacion";
            this.TxtFechaCreacion.Size = new System.Drawing.Size(212, 23);
            this.TxtFechaCreacion.TabIndex = 104;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(682, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 103;
            this.label9.Text = "Fecha creacion:";
            // 
            // TicketsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtFechaCreacion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtPelicula);
            this.Controls.Add(this.TxtFecha);
            this.Controls.Add(this.TxtSala);
            this.Controls.Add(this.TxtAsiento);
            this.Controls.Add(this.TxtFila);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GridPrincipal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DateTimeHasta);
            this.Controls.Add(this.DateTimeDesde);
            this.Controls.Add(this.label3);
            this.Name = "TicketsPage";
            this.Size = new System.Drawing.Size(1013, 486);
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DateTimeHasta;
        private System.Windows.Forms.DateTimePicker DateTimeDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFecha;
        private System.Windows.Forms.TextBox TxtSala;
        private System.Windows.Forms.TextBox TxtAsiento;
        private System.Windows.Forms.TextBox TxtFila;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView GridPrincipal;
        private System.Windows.Forms.TextBox TxtPelicula;
        private System.Windows.Forms.TextBox TxtFechaCreacion;
        private System.Windows.Forms.Label label9;
    }
}
