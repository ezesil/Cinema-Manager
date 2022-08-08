namespace Cinema.UI.AdminViews
{
    partial class RolesPanel
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
            this.BtnEliminarRol = new System.Windows.Forms.Button();
            this.BtnModificarRol = new System.Windows.Forms.Button();
            this.TxtNombreRol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIdRol = new System.Windows.Forms.TextBox();
            this.BtnCrearRol = new System.Windows.Forms.Button();
            this.BtnBuscarRoles = new System.Windows.Forms.Button();
            this.GridRoles = new System.Windows.Forms.DataGridView();
            this.GridRelaciones = new System.Windows.Forms.DataGridView();
            this.BtnEliminarRelacion = new System.Windows.Forms.Button();
            this.BtnEliminarPermiso = new System.Windows.Forms.Button();
            this.BtnModificarPermiso = new System.Windows.Forms.Button();
            this.TxtCodigoPermiso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtIdPermiso = new System.Windows.Forms.TextBox();
            this.BtnCrearPermiso = new System.Windows.Forms.Button();
            this.BtnBuscarPermisos = new System.Windows.Forms.Button();
            this.GridPermisos = new System.Windows.Forms.DataGridView();
            this.BtnAgregarRelacion = new System.Windows.Forms.Button();
            this.ComboPermisos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRelaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEliminarRol
            // 
            this.BtnEliminarRol.Location = new System.Drawing.Point(303, 100);
            this.BtnEliminarRol.Name = "BtnEliminarRol";
            this.BtnEliminarRol.Size = new System.Drawing.Size(280, 23);
            this.BtnEliminarRol.TabIndex = 27;
            this.BtnEliminarRol.Text = "Eliminar seleccionado";
            this.BtnEliminarRol.UseVisualStyleBackColor = true;
            this.BtnEliminarRol.Click += new System.EventHandler(this.BtnEliminarRol_Click);
            // 
            // BtnModificarRol
            // 
            this.BtnModificarRol.Location = new System.Drawing.Point(303, 70);
            this.BtnModificarRol.Name = "BtnModificarRol";
            this.BtnModificarRol.Size = new System.Drawing.Size(134, 23);
            this.BtnModificarRol.TabIndex = 26;
            this.BtnModificarRol.Text = "Modificar";
            this.BtnModificarRol.UseVisualStyleBackColor = true;
            this.BtnModificarRol.Click += new System.EventHandler(this.BtnModificarRol_Click);
            // 
            // TxtNombreRol
            // 
            this.TxtNombreRol.Location = new System.Drawing.Point(180, 41);
            this.TxtNombreRol.Name = "TxtNombreRol";
            this.TxtNombreRol.Size = new System.Drawing.Size(257, 23);
            this.TxtNombreRol.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "ID rol:";
            // 
            // TxtIdRol
            // 
            this.TxtIdRol.Enabled = false;
            this.TxtIdRol.Location = new System.Drawing.Point(180, 12);
            this.TxtIdRol.Name = "TxtIdRol";
            this.TxtIdRol.Size = new System.Drawing.Size(257, 23);
            this.TxtIdRol.TabIndex = 20;
            // 
            // BtnCrearRol
            // 
            this.BtnCrearRol.Location = new System.Drawing.Point(180, 70);
            this.BtnCrearRol.Name = "BtnCrearRol";
            this.BtnCrearRol.Size = new System.Drawing.Size(117, 23);
            this.BtnCrearRol.TabIndex = 18;
            this.BtnCrearRol.Text = "Crear";
            this.BtnCrearRol.UseVisualStyleBackColor = true;
            this.BtnCrearRol.Click += new System.EventHandler(this.BtnCrearRol_Click);
            // 
            // BtnBuscarRoles
            // 
            this.BtnBuscarRoles.Location = new System.Drawing.Point(17, 100);
            this.BtnBuscarRoles.Name = "BtnBuscarRoles";
            this.BtnBuscarRoles.Size = new System.Drawing.Size(280, 23);
            this.BtnBuscarRoles.TabIndex = 17;
            this.BtnBuscarRoles.Text = "Buscar";
            this.BtnBuscarRoles.UseVisualStyleBackColor = true;
            this.BtnBuscarRoles.Click += new System.EventHandler(this.BtnBuscarRoles_Click);
            // 
            // GridRoles
            // 
            this.GridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRoles.Location = new System.Drawing.Point(17, 129);
            this.GridRoles.Name = "GridRoles";
            this.GridRoles.RowTemplate.Height = 25;
            this.GridRoles.Size = new System.Drawing.Size(566, 256);
            this.GridRoles.TabIndex = 16;
            // 
            // GridRelaciones
            // 
            this.GridRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRelaciones.Location = new System.Drawing.Point(605, 129);
            this.GridRelaciones.Name = "GridRelaciones";
            this.GridRelaciones.RowTemplate.Height = 25;
            this.GridRelaciones.Size = new System.Drawing.Size(524, 256);
            this.GridRelaciones.TabIndex = 28;
            // 
            // BtnEliminarRelacion
            // 
            this.BtnEliminarRelacion.Location = new System.Drawing.Point(870, 100);
            this.BtnEliminarRelacion.Name = "BtnEliminarRelacion";
            this.BtnEliminarRelacion.Size = new System.Drawing.Size(259, 23);
            this.BtnEliminarRelacion.TabIndex = 36;
            this.BtnEliminarRelacion.Text = "Eliminar seleccionado";
            this.BtnEliminarRelacion.UseVisualStyleBackColor = true;
            this.BtnEliminarRelacion.Click += new System.EventHandler(this.BtnEliminarRelacion_Click);
            // 
            // BtnEliminarPermiso
            // 
            this.BtnEliminarPermiso.Location = new System.Drawing.Point(303, 404);
            this.BtnEliminarPermiso.Name = "BtnEliminarPermiso";
            this.BtnEliminarPermiso.Size = new System.Drawing.Size(280, 23);
            this.BtnEliminarPermiso.TabIndex = 45;
            this.BtnEliminarPermiso.Text = "Eliminar permiso seleccionado";
            this.BtnEliminarPermiso.UseVisualStyleBackColor = true;
            this.BtnEliminarPermiso.Click += new System.EventHandler(this.BtnEliminarPermiso_Click);
            // 
            // BtnModificarPermiso
            // 
            this.BtnModificarPermiso.Location = new System.Drawing.Point(820, 500);
            this.BtnModificarPermiso.Name = "BtnModificarPermiso";
            this.BtnModificarPermiso.Size = new System.Drawing.Size(136, 23);
            this.BtnModificarPermiso.TabIndex = 44;
            this.BtnModificarPermiso.Text = "Modificar permiso";
            this.BtnModificarPermiso.UseVisualStyleBackColor = true;
            this.BtnModificarPermiso.Click += new System.EventHandler(this.BtnModificarPermiso_Click);
            // 
            // TxtCodigoPermiso
            // 
            this.TxtCodigoPermiso.Location = new System.Drawing.Point(678, 462);
            this.TxtCodigoPermiso.Name = "TxtCodigoPermiso";
            this.TxtCodigoPermiso.Size = new System.Drawing.Size(278, 23);
            this.TxtCodigoPermiso.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(623, 465);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Codigo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(605, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 41;
            this.label6.Text = "ID permiso:";
            // 
            // TxtIdPermiso
            // 
            this.TxtIdPermiso.Enabled = false;
            this.TxtIdPermiso.Location = new System.Drawing.Point(678, 433);
            this.TxtIdPermiso.Name = "TxtIdPermiso";
            this.TxtIdPermiso.Size = new System.Drawing.Size(278, 23);
            this.TxtIdPermiso.TabIndex = 40;
            // 
            // BtnCrearPermiso
            // 
            this.BtnCrearPermiso.Location = new System.Drawing.Point(678, 500);
            this.BtnCrearPermiso.Name = "BtnCrearPermiso";
            this.BtnCrearPermiso.Size = new System.Drawing.Size(136, 23);
            this.BtnCrearPermiso.TabIndex = 39;
            this.BtnCrearPermiso.Text = "Crear permiso";
            this.BtnCrearPermiso.UseVisualStyleBackColor = true;
            this.BtnCrearPermiso.Click += new System.EventHandler(this.BtnCrearPermiso_Click);
            // 
            // BtnBuscarPermisos
            // 
            this.BtnBuscarPermisos.Location = new System.Drawing.Point(17, 404);
            this.BtnBuscarPermisos.Name = "BtnBuscarPermisos";
            this.BtnBuscarPermisos.Size = new System.Drawing.Size(280, 23);
            this.BtnBuscarPermisos.TabIndex = 38;
            this.BtnBuscarPermisos.Text = "Buscar permisos";
            this.BtnBuscarPermisos.UseVisualStyleBackColor = true;
            this.BtnBuscarPermisos.Click += new System.EventHandler(this.BtnBuscarPermisos_Click);
            // 
            // GridPermisos
            // 
            this.GridPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPermisos.Location = new System.Drawing.Point(17, 433);
            this.GridPermisos.Name = "GridPermisos";
            this.GridPermisos.RowTemplate.Height = 25;
            this.GridPermisos.Size = new System.Drawing.Size(566, 236);
            this.GridPermisos.TabIndex = 37;
            // 
            // BtnAgregarRelacion
            // 
            this.BtnAgregarRelacion.Location = new System.Drawing.Point(605, 100);
            this.BtnAgregarRelacion.Name = "BtnAgregarRelacion";
            this.BtnAgregarRelacion.Size = new System.Drawing.Size(259, 23);
            this.BtnAgregarRelacion.TabIndex = 30;
            this.BtnAgregarRelacion.Text = "Agregar";
            this.BtnAgregarRelacion.UseVisualStyleBackColor = true;
            this.BtnAgregarRelacion.Click += new System.EventHandler(this.BtnAgregarRelacion_Click);
            // 
            // ComboPermisos
            // 
            this.ComboPermisos.FormattingEnabled = true;
            this.ComboPermisos.Location = new System.Drawing.Point(605, 71);
            this.ComboPermisos.Name = "ComboPermisos";
            this.ComboPermisos.Size = new System.Drawing.Size(259, 23);
            this.ComboPermisos.TabIndex = 46;
            this.ComboPermisos.DropDown += new System.EventHandler(this.ComboPermisos_DropDown);
            this.ComboPermisos.SelectedIndexChanged += new System.EventHandler(this.ComboPermisos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(605, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Permiso:";
            // 
            // RolesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboPermisos);
            this.Controls.Add(this.BtnEliminarPermiso);
            this.Controls.Add(this.BtnModificarPermiso);
            this.Controls.Add(this.TxtCodigoPermiso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtIdPermiso);
            this.Controls.Add(this.BtnCrearPermiso);
            this.Controls.Add(this.BtnBuscarPermisos);
            this.Controls.Add(this.GridPermisos);
            this.Controls.Add(this.BtnEliminarRelacion);
            this.Controls.Add(this.BtnAgregarRelacion);
            this.Controls.Add(this.GridRelaciones);
            this.Controls.Add(this.BtnEliminarRol);
            this.Controls.Add(this.BtnModificarRol);
            this.Controls.Add(this.TxtNombreRol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtIdRol);
            this.Controls.Add(this.BtnCrearRol);
            this.Controls.Add(this.BtnBuscarRoles);
            this.Controls.Add(this.GridRoles);
            this.Name = "RolesPanel";
            this.Size = new System.Drawing.Size(1153, 686);
            ((System.ComponentModel.ISupportInitialize)(this.GridRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRelaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnEliminarRol;
        private System.Windows.Forms.Button BtnModificarRol;
        private System.Windows.Forms.TextBox TxtNombreRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtIdRol;
        private System.Windows.Forms.Button BtnCrearRol;
        private System.Windows.Forms.Button BtnBuscarRoles;
        private System.Windows.Forms.DataGridView GridRoles;
        private System.Windows.Forms.DataGridView GridRelaciones;
        private System.Windows.Forms.Button BtnEliminarRelacion;
        private System.Windows.Forms.Button BtnEliminarPermiso;
        private System.Windows.Forms.Button BtnModificarPermiso;
        private System.Windows.Forms.TextBox TxtCodigoPermiso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtIdPermiso;
        private System.Windows.Forms.Button BtnCrearPermiso;
        private System.Windows.Forms.Button BtnBuscarPermisos;
        private System.Windows.Forms.DataGridView GridPermisos;
        private System.Windows.Forms.Button BtnAgregarRelacion;
        private System.Windows.Forms.ComboBox ComboPermisos;
        private System.Windows.Forms.Label label1;
    }
}
