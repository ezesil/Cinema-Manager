namespace Cinema.UI.Views
{
    partial class LoginPage
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUserEmail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(30, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 37);
            this.label3.TabIndex = 9;
            this.label3.Tag = "text_enter";
            this.label3.Text = "Entrar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 8;
            this.label2.Tag = "text_username";
            this.label2.Text = "Nombre de usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 7;
            this.label1.Tag = "text_password";
            this.label1.Text = "Contraseña";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(30, 174);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(263, 23);
            this.TxtPassword.TabIndex = 6;
            this.TxtPassword.Text = "administrador";
            // 
            // TxtUserEmail
            // 
            this.TxtUserEmail.Location = new System.Drawing.Point(30, 122);
            this.TxtUserEmail.Name = "TxtUserEmail";
            this.TxtUserEmail.Size = new System.Drawing.Size(263, 23);
            this.TxtUserEmail.TabIndex = 5;
            this.TxtUserEmail.Text = "admin";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(30, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 39);
            this.button1.TabIndex = 10;
            this.button1.Tag = "text_signin";
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(304, 15);
            this.label4.TabIndex = 11;
            this.label4.Tag = "text_noaccount_contact_manager";
            this.label4.Text = "Si no posee una cuenta, contacte con su gerente a cargo";
            // 
            // TxtError
            // 
            this.TxtError.AutoSize = true;
            this.TxtError.BackColor = System.Drawing.SystemColors.Control;
            this.TxtError.ForeColor = System.Drawing.Color.Red;
            this.TxtError.Location = new System.Drawing.Point(30, 256);
            this.TxtError.Name = "TxtError";
            this.TxtError.Size = new System.Drawing.Size(242, 15);
            this.TxtError.TabIndex = 12;
            this.TxtError.Tag = "text_username";
            this.TxtError.Text = "Nombre de usuario o contraseña incorrectos";
            this.TxtError.Visible = false;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUserEmail);
            this.Name = "LoginPage";
            this.Size = new System.Drawing.Size(331, 303);
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox TxtUserEmail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label TxtError;
    }
}
