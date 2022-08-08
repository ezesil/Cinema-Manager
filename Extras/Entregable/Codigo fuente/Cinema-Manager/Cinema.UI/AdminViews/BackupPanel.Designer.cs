namespace Cinema.UI.AdminViews
{
    partial class BackupPanel
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
            this.label3 = new System.Windows.Forms.Label();
            this.ComboDb = new System.Windows.Forms.ComboBox();
            this.TxtBackup = new System.Windows.Forms.TextBox();
            this.BtnExaminarBackup = new System.Windows.Forms.Button();
            this.BtnExaminarRestore = new System.Windows.Forms.Button();
            this.TxtRestore = new System.Windows.Forms.TextBox();
            this.BtnRestore = new System.Windows.Forms.Button();
            this.BtnBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(60, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Tag = "text_database";
            this.label1.Text = "Base de datos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(60, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 1;
            this.label2.Tag = "text_make_backup";
            this.label2.Text = "Realizar backup";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(60, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 2;
            this.label3.Tag = "text_restore_backup";
            this.label3.Text = "Restaurar backup";
            // 
            // ComboDb
            // 
            this.ComboDb.ForeColor = System.Drawing.Color.Black;
            this.ComboDb.FormattingEnabled = true;
            this.ComboDb.Items.AddRange(new object[] {
            "CinemaDB",
            "LogDB"});
            this.ComboDb.Location = new System.Drawing.Point(148, 52);
            this.ComboDb.Name = "ComboDb";
            this.ComboDb.Size = new System.Drawing.Size(281, 23);
            this.ComboDb.TabIndex = 3;
            this.ComboDb.SelectedIndexChanged += new System.EventHandler(this.ComboDb_SelectedIndexChanged);
            // 
            // TxtBackup
            // 
            this.TxtBackup.Enabled = false;
            this.TxtBackup.ForeColor = System.Drawing.Color.Black;
            this.TxtBackup.Location = new System.Drawing.Point(60, 114);
            this.TxtBackup.Name = "TxtBackup";
            this.TxtBackup.Size = new System.Drawing.Size(288, 23);
            this.TxtBackup.TabIndex = 4;
            // 
            // BtnExaminarBackup
            // 
            this.BtnExaminarBackup.Enabled = false;
            this.BtnExaminarBackup.ForeColor = System.Drawing.Color.Black;
            this.BtnExaminarBackup.Location = new System.Drawing.Point(354, 114);
            this.BtnExaminarBackup.Name = "BtnExaminarBackup";
            this.BtnExaminarBackup.Size = new System.Drawing.Size(75, 23);
            this.BtnExaminarBackup.TabIndex = 5;
            this.BtnExaminarBackup.Tag = "text_examine";
            this.BtnExaminarBackup.Text = "Examinar...";
            this.BtnExaminarBackup.UseVisualStyleBackColor = true;
            this.BtnExaminarBackup.Click += new System.EventHandler(this.BtnExaminarBackup_Click);
            // 
            // BtnExaminarRestore
            // 
            this.BtnExaminarRestore.Enabled = false;
            this.BtnExaminarRestore.ForeColor = System.Drawing.Color.Black;
            this.BtnExaminarRestore.Location = new System.Drawing.Point(354, 208);
            this.BtnExaminarRestore.Name = "BtnExaminarRestore";
            this.BtnExaminarRestore.Size = new System.Drawing.Size(75, 23);
            this.BtnExaminarRestore.TabIndex = 7;
            this.BtnExaminarRestore.Tag = "text_examine";
            this.BtnExaminarRestore.Text = "Examinar...";
            this.BtnExaminarRestore.UseVisualStyleBackColor = true;
            this.BtnExaminarRestore.Click += new System.EventHandler(this.BtnExaminarRestore_Click);
            // 
            // TxtRestore
            // 
            this.TxtRestore.Enabled = false;
            this.TxtRestore.ForeColor = System.Drawing.Color.Black;
            this.TxtRestore.Location = new System.Drawing.Point(60, 208);
            this.TxtRestore.Name = "TxtRestore";
            this.TxtRestore.Size = new System.Drawing.Size(288, 23);
            this.TxtRestore.TabIndex = 6;
            // 
            // BtnRestore
            // 
            this.BtnRestore.Enabled = false;
            this.BtnRestore.ForeColor = System.Drawing.Color.Black;
            this.BtnRestore.Location = new System.Drawing.Point(60, 237);
            this.BtnRestore.Name = "BtnRestore";
            this.BtnRestore.Size = new System.Drawing.Size(171, 23);
            this.BtnRestore.TabIndex = 8;
            this.BtnRestore.Tag = "text_restore_backup";
            this.BtnRestore.Text = "Restaurar backup";
            this.BtnRestore.UseVisualStyleBackColor = true;
            this.BtnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // BtnBackup
            // 
            this.BtnBackup.Enabled = false;
            this.BtnBackup.ForeColor = System.Drawing.Color.Black;
            this.BtnBackup.Location = new System.Drawing.Point(60, 143);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(171, 23);
            this.BtnBackup.TabIndex = 9;
            this.BtnBackup.Tag = "text_execute_backup";
            this.BtnBackup.Text = "Ejecutar backup completo";
            this.BtnBackup.UseVisualStyleBackColor = true;
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // BackupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnBackup);
            this.Controls.Add(this.BtnRestore);
            this.Controls.Add(this.BtnExaminarRestore);
            this.Controls.Add(this.TxtRestore);
            this.Controls.Add(this.BtnExaminarBackup);
            this.Controls.Add(this.TxtBackup);
            this.Controls.Add(this.ComboDb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BackupPanel";
            this.Size = new System.Drawing.Size(868, 449);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboDb;
        private System.Windows.Forms.TextBox TxtBackup;
        private System.Windows.Forms.Button BtnExaminarBackup;
        private System.Windows.Forms.Button BtnExaminarRestore;
        private System.Windows.Forms.TextBox TxtRestore;
        private System.Windows.Forms.Button BtnRestore;
        private System.Windows.Forms.Button BtnBackup;
    }
}
