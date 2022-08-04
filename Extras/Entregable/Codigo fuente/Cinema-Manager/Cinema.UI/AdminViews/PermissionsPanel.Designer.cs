namespace Cinema.UI.AdminViews
{
    partial class PermissionsPanel
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
            this.ComboPermisos = new System.Windows.Forms.ComboBox();
            this.BtnEliminarRelacion = new System.Windows.Forms.Button();
            this.BtnAgregarRelacion = new System.Windows.Forms.Button();
            this.GridRelaciones = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridRelaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboPermisos
            // 
            this.ComboPermisos.FormattingEnabled = true;
            this.ComboPermisos.Location = new System.Drawing.Point(419, 50);
            this.ComboPermisos.Name = "ComboPermisos";
            this.ComboPermisos.Size = new System.Drawing.Size(199, 23);
            this.ComboPermisos.TabIndex = 50;
            // 
            // BtnEliminarRelacion
            // 
            this.BtnEliminarRelacion.Location = new System.Drawing.Point(624, 79);
            this.BtnEliminarRelacion.Name = "BtnEliminarRelacion";
            this.BtnEliminarRelacion.Size = new System.Drawing.Size(199, 23);
            this.BtnEliminarRelacion.TabIndex = 49;
            this.BtnEliminarRelacion.Text = "Eliminar seleccionado";
            this.BtnEliminarRelacion.UseVisualStyleBackColor = true;
            // 
            // BtnAgregarRelacion
            // 
            this.BtnAgregarRelacion.Location = new System.Drawing.Point(419, 79);
            this.BtnAgregarRelacion.Name = "BtnAgregarRelacion";
            this.BtnAgregarRelacion.Size = new System.Drawing.Size(199, 23);
            this.BtnAgregarRelacion.TabIndex = 48;
            this.BtnAgregarRelacion.Text = "Agregar";
            this.BtnAgregarRelacion.UseVisualStyleBackColor = true;
            // 
            // GridRelaciones
            // 
            this.GridRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRelaciones.Location = new System.Drawing.Point(419, 108);
            this.GridRelaciones.Name = "GridRelaciones";
            this.GridRelaciones.RowTemplate.Height = 25;
            this.GridRelaciones.Size = new System.Drawing.Size(404, 256);
            this.GridRelaciones.TabIndex = 47;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(404, 256);
            this.dataGridView1.TabIndex = 51;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(9, 79);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(404, 23);
            this.BtnBuscar.TabIndex = 52;
            this.BtnBuscar.Tag = "text_search";
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // PermissionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ComboPermisos);
            this.Controls.Add(this.BtnEliminarRelacion);
            this.Controls.Add(this.BtnAgregarRelacion);
            this.Controls.Add(this.GridRelaciones);
            this.Name = "PermissionsPanel";
            this.Size = new System.Drawing.Size(838, 488);
            ((System.ComponentModel.ISupportInitialize)(this.GridRelaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboPermisos;
        private System.Windows.Forms.Button BtnEliminarRelacion;
        private System.Windows.Forms.Button BtnAgregarRelacion;
        private System.Windows.Forms.DataGridView GridRelaciones;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnBuscar;
    }
}
