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
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
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
            this.DateTimeHasta.Value = new System.DateTime(2100, 7, 31, 0, 0, 0, 0);
            // 
            // DateTimeDesde
            // 
            this.DateTimeDesde.Location = new System.Drawing.Point(66, 21);
            this.DateTimeDesde.Name = "DateTimeDesde";
            this.DateTimeDesde.Size = new System.Drawing.Size(227, 23);
            this.DateTimeDesde.TabIndex = 17;
            this.DateTimeDesde.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
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
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(580, 21);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(253, 23);
            this.BtnBuscar.TabIndex = 90;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPrincipal.Location = new System.Drawing.Point(13, 50);
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.RowTemplate.Height = 25;
            this.GridPrincipal.Size = new System.Drawing.Size(997, 423);
            this.GridPrincipal.TabIndex = 84;
            // 
            // TicketsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.GridPrincipal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DateTimeHasta);
            this.Controls.Add(this.DateTimeDesde);
            this.Controls.Add(this.label3);
            this.Name = "TicketsPage";
            this.Size = new System.Drawing.Size(1013, 486);
            this.Load += new System.EventHandler(this.TicketsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DateTimeHasta;
        private System.Windows.Forms.DateTimePicker DateTimeDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.DataGridView GridPrincipal;
    }
}
