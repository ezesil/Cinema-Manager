namespace Cinema.UI.Views
{
    partial class RoomsPage
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
            this.BtnLimpiarCampos = new System.Windows.Forms.Button();
            this.ComboActivo = new System.Windows.Forms.ComboBox();
            this.TxtIdentificador = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
            this.Combo3D = new System.Windows.Forms.ComboBox();
            this.ComboPantallaGigante = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLimpiarCampos
            // 
            this.BtnLimpiarCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLimpiarCampos.Location = new System.Drawing.Point(623, 252);
            this.BtnLimpiarCampos.Name = "BtnLimpiarCampos";
            this.BtnLimpiarCampos.Size = new System.Drawing.Size(332, 23);
            this.BtnLimpiarCampos.TabIndex = 99;
            this.BtnLimpiarCampos.Text = "Limpiar campos";
            this.BtnLimpiarCampos.UseVisualStyleBackColor = true;
            this.BtnLimpiarCampos.Click += new System.EventHandler(this.LimpiarCampos_Click);
            // 
            // ComboActivo
            // 
            this.ComboActivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboActivo.FormattingEnabled = true;
            this.ComboActivo.Items.AddRange(new object[] {
            "False",
            "True"});
            this.ComboActivo.Location = new System.Drawing.Point(723, 203);
            this.ComboActivo.Name = "ComboActivo";
            this.ComboActivo.Size = new System.Drawing.Size(232, 23);
            this.ComboActivo.TabIndex = 98;
            // 
            // TxtIdentificador
            // 
            this.TxtIdentificador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtIdentificador.Location = new System.Drawing.Point(723, 116);
            this.TxtIdentificador.Name = "TxtIdentificador";
            this.TxtIdentificador.Size = new System.Drawing.Size(232, 23);
            this.TxtIdentificador.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(622, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 92;
            this.label7.Text = "Pantalla gigante:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(622, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 91;
            this.label4.Text = "Activo:";
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnActualizar.Location = new System.Drawing.Point(622, 66);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(333, 23);
            this.BtnActualizar.TabIndex = 90;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEliminar.Location = new System.Drawing.Point(623, 310);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(332, 23);
            this.BtnEliminar.TabIndex = 89;
            this.BtnEliminar.Text = "Eliminar seleccionado";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnModificar.Location = new System.Drawing.Point(793, 281);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(162, 23);
            this.BtnModificar.TabIndex = 88;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 87;
            this.label3.Text = "3D:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 86;
            this.label2.Text = "Identificador:";
            // 
            // BtnCrear
            // 
            this.BtnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCrear.Location = new System.Drawing.Point(623, 281);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(164, 23);
            this.BtnCrear.TabIndex = 85;
            this.BtnCrear.Text = "Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.Crear_Click);
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.AllowUserToOrderColumns = true;
            this.GridPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPrincipal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPrincipal.Location = new System.Drawing.Point(23, 26);
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.RowTemplate.Height = 25;
            this.GridPrincipal.Size = new System.Drawing.Size(582, 377);
            this.GridPrincipal.TabIndex = 84;
            // 
            // Combo3D
            // 
            this.Combo3D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo3D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo3D.FormattingEnabled = true;
            this.Combo3D.Items.AddRange(new object[] {
            "False",
            "True"});
            this.Combo3D.Location = new System.Drawing.Point(723, 174);
            this.Combo3D.Name = "Combo3D";
            this.Combo3D.Size = new System.Drawing.Size(232, 23);
            this.Combo3D.TabIndex = 100;
            // 
            // ComboPantallaGigante
            // 
            this.ComboPantallaGigante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboPantallaGigante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboPantallaGigante.FormattingEnabled = true;
            this.ComboPantallaGigante.Items.AddRange(new object[] {
            "False",
            "True"});
            this.ComboPantallaGigante.Location = new System.Drawing.Point(723, 145);
            this.ComboPantallaGigante.Name = "ComboPantallaGigante";
            this.ComboPantallaGigante.Size = new System.Drawing.Size(232, 23);
            this.ComboPantallaGigante.TabIndex = 101;
            // 
            // RoomsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComboPantallaGigante);
            this.Controls.Add(this.Combo3D);
            this.Controls.Add(this.BtnLimpiarCampos);
            this.Controls.Add(this.ComboActivo);
            this.Controls.Add(this.TxtIdentificador);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.GridPrincipal);
            this.Name = "RoomsPage";
            this.Size = new System.Drawing.Size(980, 428);
            this.Tag = "text_roompage";
            this.Load += new System.EventHandler(this.RoomsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLimpiarCampos;
        private System.Windows.Forms.ComboBox ComboActivo;
        private System.Windows.Forms.TextBox TxtIdentificador;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.DataGridView GridPrincipal;
        private System.Windows.Forms.ComboBox Combo3D;
        private System.Windows.Forms.ComboBox ComboPantallaGigante;
    }
}
