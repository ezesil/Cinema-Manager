namespace Cinema.UI.AdminViews
{
    partial class CheckerDigitPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIdEntidad = new System.Windows.Forms.TextBox();
            this.BtnRecalcularEntidad = new System.Windows.Forms.Button();
            this.BtnRecalcularUsuario = new System.Windows.Forms.Button();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 15);
            this.label1.TabIndex = 0;
            this.label1.Tag = "text_recalculate_dvv";
            this.label1.Text = "Recalcular Digito Verificador Vertical";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 1;
            this.label2.Tag = "text_entity_id";
            this.label2.Text = "ID Entidad";
            // 
            // TxtIdEntidad
            // 
            this.TxtIdEntidad.Location = new System.Drawing.Point(54, 68);
            this.TxtIdEntidad.Name = "TxtIdEntidad";
            this.TxtIdEntidad.Size = new System.Drawing.Size(100, 23);
            this.TxtIdEntidad.TabIndex = 2;
            // 
            // BtnRecalcularEntidad
            // 
            this.BtnRecalcularEntidad.Location = new System.Drawing.Point(163, 68);
            this.BtnRecalcularEntidad.Name = "BtnRecalcularEntidad";
            this.BtnRecalcularEntidad.Size = new System.Drawing.Size(75, 23);
            this.BtnRecalcularEntidad.TabIndex = 3;
            this.BtnRecalcularEntidad.Tag = "text_recalculate";
            this.BtnRecalcularEntidad.Text = "Recalcular";
            this.BtnRecalcularEntidad.UseVisualStyleBackColor = true;
            this.BtnRecalcularEntidad.Click += new System.EventHandler(this.BtnRecalcularEntidad_Click);
            // 
            // BtnRecalcularUsuario
            // 
            this.BtnRecalcularUsuario.Location = new System.Drawing.Point(308, 169);
            this.BtnRecalcularUsuario.Name = "BtnRecalcularUsuario";
            this.BtnRecalcularUsuario.Size = new System.Drawing.Size(75, 23);
            this.BtnRecalcularUsuario.TabIndex = 7;
            this.BtnRecalcularUsuario.Tag = "text_recalculate";
            this.BtnRecalcularUsuario.Text = "Recalcular";
            this.BtnRecalcularUsuario.UseVisualStyleBackColor = true;
            this.BtnRecalcularUsuario.Click += new System.EventHandler(this.BtnRecalcularUsuario_Click);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(54, 169);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(248, 23);
            this.TxtUsuario.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 5;
            this.label3.Tag = "text_user";
            this.label3.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 15);
            this.label4.TabIndex = 4;
            this.label4.Tag = "text_recalculate_dvh";
            this.label4.Text = "Recalcular Digito Verificador Horizontal";
            // 
            // CheckerDigitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnRecalcularUsuario);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnRecalcularEntidad);
            this.Controls.Add(this.TxtIdEntidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CheckerDigitPanel";
            this.Size = new System.Drawing.Size(760, 318);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtIdEntidad;
        private System.Windows.Forms.Button BtnRecalcularEntidad;
        private System.Windows.Forms.Button BtnRecalcularUsuario;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
