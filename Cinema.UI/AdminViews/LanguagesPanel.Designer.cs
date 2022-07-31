namespace Cinema.UI.AdminViews
{
    partial class LanguagesPanel
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
            this.GridLenguajes = new System.Windows.Forms.DataGridView();
            this.BtnAgregarTraduccion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtAbreviacion = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.BtnEliminarTraduccion = new System.Windows.Forms.Button();
            this.BtnGuardarCambiosTraducciones = new System.Windows.Forms.Button();
            this.GridTraducciones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnGuardarCambiosLenguaje = new System.Windows.Forms.Button();
            this.BtnEliminarLenguaje = new System.Windows.Forms.Button();
            this.BtnAgregarLenguaje = new System.Windows.Forms.Button();
            this.TxtGuardarTodoYActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridLenguajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // GridLenguajes
            // 
            this.GridLenguajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridLenguajes.Location = new System.Drawing.Point(278, 47);
            this.GridLenguajes.Name = "GridLenguajes";
            this.GridLenguajes.RowTemplate.Height = 25;
            this.GridLenguajes.Size = new System.Drawing.Size(132, 354);
            this.GridLenguajes.TabIndex = 0;
            // 
            // BtnAgregarTraduccion
            // 
            this.BtnAgregarTraduccion.Location = new System.Drawing.Point(718, 115);
            this.BtnAgregarTraduccion.Name = "BtnAgregarTraduccion";
            this.BtnAgregarTraduccion.Size = new System.Drawing.Size(199, 23);
            this.BtnAgregarTraduccion.TabIndex = 3;
            this.BtnAgregarTraduccion.Text = "Agregar traducción";
            this.BtnAgregarTraduccion.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Abreviacion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nombre:";
            // 
            // TxtAbreviacion
            // 
            this.TxtAbreviacion.Location = new System.Drawing.Point(80, 47);
            this.TxtAbreviacion.Name = "TxtAbreviacion";
            this.TxtAbreviacion.Size = new System.Drawing.Size(192, 23);
            this.TxtAbreviacion.TabIndex = 11;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(80, 77);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(192, 23);
            this.TxtNombre.TabIndex = 12;
            // 
            // BtnEliminarTraduccion
            // 
            this.BtnEliminarTraduccion.Location = new System.Drawing.Point(718, 144);
            this.BtnEliminarTraduccion.Name = "BtnEliminarTraduccion";
            this.BtnEliminarTraduccion.Size = new System.Drawing.Size(199, 23);
            this.BtnEliminarTraduccion.TabIndex = 13;
            this.BtnEliminarTraduccion.Text = "Eliminar traduccion seleccionada";
            this.BtnEliminarTraduccion.UseVisualStyleBackColor = true;
            // 
            // BtnGuardarCambiosTraducciones
            // 
            this.BtnGuardarCambiosTraducciones.Location = new System.Drawing.Point(718, 173);
            this.BtnGuardarCambiosTraducciones.Name = "BtnGuardarCambiosTraducciones";
            this.BtnGuardarCambiosTraducciones.Size = new System.Drawing.Size(199, 23);
            this.BtnGuardarCambiosTraducciones.TabIndex = 14;
            this.BtnGuardarCambiosTraducciones.Text = "Guardar cambios de traducciones";
            this.BtnGuardarCambiosTraducciones.UseVisualStyleBackColor = true;
            // 
            // GridTraducciones
            // 
            this.GridTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTraducciones.Location = new System.Drawing.Point(416, 47);
            this.GridTraducciones.Name = "GridTraducciones";
            this.GridTraducciones.RowTemplate.Height = 25;
            this.GridTraducciones.Size = new System.Drawing.Size(296, 354);
            this.GridTraducciones.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(307, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Idiomas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(511, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Traducciones";
            // 
            // BtnGuardarCambiosLenguaje
            // 
            this.BtnGuardarCambiosLenguaje.Location = new System.Drawing.Point(80, 173);
            this.BtnGuardarCambiosLenguaje.Name = "BtnGuardarCambiosLenguaje";
            this.BtnGuardarCambiosLenguaje.Size = new System.Drawing.Size(192, 23);
            this.BtnGuardarCambiosLenguaje.TabIndex = 20;
            this.BtnGuardarCambiosLenguaje.Text = "Guardar cambios de idiomas";
            this.BtnGuardarCambiosLenguaje.UseVisualStyleBackColor = true;
            // 
            // BtnEliminarLenguaje
            // 
            this.BtnEliminarLenguaje.Location = new System.Drawing.Point(80, 144);
            this.BtnEliminarLenguaje.Name = "BtnEliminarLenguaje";
            this.BtnEliminarLenguaje.Size = new System.Drawing.Size(192, 23);
            this.BtnEliminarLenguaje.TabIndex = 19;
            this.BtnEliminarLenguaje.Text = "Eliminar lenguaje seleccionado";
            this.BtnEliminarLenguaje.UseVisualStyleBackColor = true;
            // 
            // BtnAgregarLenguaje
            // 
            this.BtnAgregarLenguaje.Location = new System.Drawing.Point(80, 106);
            this.BtnAgregarLenguaje.Name = "BtnAgregarLenguaje";
            this.BtnAgregarLenguaje.Size = new System.Drawing.Size(192, 23);
            this.BtnAgregarLenguaje.TabIndex = 18;
            this.BtnAgregarLenguaje.Text = "Agregar lenguaje";
            this.BtnAgregarLenguaje.UseVisualStyleBackColor = true;
            // 
            // TxtGuardarTodoYActualizar
            // 
            this.TxtGuardarTodoYActualizar.Location = new System.Drawing.Point(278, 407);
            this.TxtGuardarTodoYActualizar.Name = "TxtGuardarTodoYActualizar";
            this.TxtGuardarTodoYActualizar.Size = new System.Drawing.Size(434, 23);
            this.TxtGuardarTodoYActualizar.TabIndex = 21;
            this.TxtGuardarTodoYActualizar.Text = "Guardar todo y actualizar textos de la aplicacion";
            this.TxtGuardarTodoYActualizar.UseVisualStyleBackColor = true;
            // 
            // LanguagesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtGuardarTodoYActualizar);
            this.Controls.Add(this.BtnGuardarCambiosLenguaje);
            this.Controls.Add(this.BtnEliminarLenguaje);
            this.Controls.Add(this.BtnAgregarLenguaje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridTraducciones);
            this.Controls.Add(this.BtnGuardarCambiosTraducciones);
            this.Controls.Add(this.BtnEliminarTraduccion);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.TxtAbreviacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnAgregarTraduccion);
            this.Controls.Add(this.GridLenguajes);
            this.Name = "LanguagesPanel";
            this.Size = new System.Drawing.Size(933, 464);
            this.Load += new System.EventHandler(this.LanguagesPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridLenguajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridTraducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridLenguajes;
        private System.Windows.Forms.Button BtnAgregarTraduccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtAbreviacion;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Button BtnEliminarTraduccion;
        private System.Windows.Forms.Button BtnGuardarCambiosTraducciones;
        private System.Windows.Forms.DataGridView GridTraducciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnGuardarCambiosLenguaje;
        private System.Windows.Forms.Button BtnEliminarLenguaje;
        private System.Windows.Forms.Button BtnAgregarLenguaje;
        private System.Windows.Forms.Button TxtGuardarTodoYActualizar;
    }
}
