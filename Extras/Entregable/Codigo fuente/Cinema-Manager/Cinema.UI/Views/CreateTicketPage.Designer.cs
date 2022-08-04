namespace Cinema.UI.Views
{
    partial class CreateTicketPage
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
            this.ComboPeliculas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnLimpiarCampos = new System.Windows.Forms.Button();
            this.ComboDiaSesion = new System.Windows.Forms.ComboBox();
            this.GridAsientos = new System.Windows.Forms.DataGridView();
            this.BtnCrearTicket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridAsientos)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboPeliculas
            // 
            this.ComboPeliculas.FormattingEnabled = true;
            this.ComboPeliculas.Location = new System.Drawing.Point(81, 28);
            this.ComboPeliculas.MaxDropDownItems = 80;
            this.ComboPeliculas.Name = "ComboPeliculas";
            this.ComboPeliculas.Size = new System.Drawing.Size(357, 23);
            this.ComboPeliculas.Sorted = true;
            this.ComboPeliculas.TabIndex = 0;
            this.ComboPeliculas.DropDown += new System.EventHandler(this.ComboPeliculas_DropDown);
            this.ComboPeliculas.SelectedIndexChanged += new System.EventHandler(this.ComboPeliculas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 4;
            this.label2.Tag = "text_movie";
            this.label2.Text = "Pelicula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 7;
            this.label4.Tag = "text_day";
            this.label4.Text = "Fecha:";
            // 
            // BtnLimpiarCampos
            // 
            this.BtnLimpiarCampos.BackColor = System.Drawing.Color.White;
            this.BtnLimpiarCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiarCampos.Location = new System.Drawing.Point(444, 27);
            this.BtnLimpiarCampos.Name = "BtnLimpiarCampos";
            this.BtnLimpiarCampos.Size = new System.Drawing.Size(308, 23);
            this.BtnLimpiarCampos.TabIndex = 10;
            this.BtnLimpiarCampos.Tag = "text_clear_fields";
            this.BtnLimpiarCampos.Text = "Limpiar campos";
            this.BtnLimpiarCampos.UseVisualStyleBackColor = false;
            this.BtnLimpiarCampos.Click += new System.EventHandler(this.BtnLimpiarCampos_Click);
            // 
            // ComboDiaSesion
            // 
            this.ComboDiaSesion.FormatString = "f";
            this.ComboDiaSesion.FormattingEnabled = true;
            this.ComboDiaSesion.Location = new System.Drawing.Point(81, 57);
            this.ComboDiaSesion.Name = "ComboDiaSesion";
            this.ComboDiaSesion.Size = new System.Drawing.Size(357, 23);
            this.ComboDiaSesion.TabIndex = 12;
            this.ComboDiaSesion.DropDown += new System.EventHandler(this.ComboDiaSesion_DropDown);
            this.ComboDiaSesion.SelectedIndexChanged += new System.EventHandler(this.ComboDiaSesion_SelectedIndexChanged);
            // 
            // GridAsientos
            // 
            this.GridAsientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAsientos.Location = new System.Drawing.Point(3, 100);
            this.GridAsientos.Name = "GridAsientos";
            this.GridAsientos.RowTemplate.Height = 25;
            this.GridAsientos.Size = new System.Drawing.Size(880, 402);
            this.GridAsientos.TabIndex = 13;
            // 
            // BtnCrearTicket
            // 
            this.BtnCrearTicket.BackColor = System.Drawing.Color.White;
            this.BtnCrearTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearTicket.Location = new System.Drawing.Point(444, 56);
            this.BtnCrearTicket.Name = "BtnCrearTicket";
            this.BtnCrearTicket.Size = new System.Drawing.Size(308, 23);
            this.BtnCrearTicket.TabIndex = 14;
            this.BtnCrearTicket.Tag = "text_createticket";
            this.BtnCrearTicket.Text = "CrearTicket";
            this.BtnCrearTicket.UseVisualStyleBackColor = false;
            this.BtnCrearTicket.Click += new System.EventHandler(this.BtnCrearTicket_Click);
            // 
            // CreateTicketPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnCrearTicket);
            this.Controls.Add(this.GridAsientos);
            this.Controls.Add(this.ComboDiaSesion);
            this.Controls.Add(this.BtnLimpiarCampos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboPeliculas);
            this.Name = "CreateTicketPage";
            this.Size = new System.Drawing.Size(886, 505);
            this.Tag = "text_createticketpage";
            this.Load += new System.EventHandler(this.PaginaInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridAsientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox ComboPeliculas;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button BtnLimpiarCampos;
        private System.Windows.Forms.ComboBox ComboDiaSesion;
        private System.Windows.Forms.DataGridView GridAsientos;
        private System.Windows.Forms.Button BtnCrearTicket;
    }
}
