namespace Cinema.UI.AdminViews
{
    partial class LogsPanel
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
            this.GridLogs = new System.Windows.Forms.DataGridView();
            this.BtnObtenerLogsLocales = new System.Windows.Forms.Button();
            this.BtnObtenerLogsBd = new System.Windows.Forms.Button();
            this.TxtDetalleLog = new System.Windows.Forms.TextBox();
            this.TxtFiltrar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // GridLogs
            // 
            this.GridLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridLogs.Location = new System.Drawing.Point(3, 109);
            this.GridLogs.Name = "GridLogs";
            this.GridLogs.RowTemplate.Height = 25;
            this.GridLogs.Size = new System.Drawing.Size(1020, 235);
            this.GridLogs.TabIndex = 0;
            // 
            // BtnObtenerLogsLocales
            // 
            this.BtnObtenerLogsLocales.Location = new System.Drawing.Point(67, 29);
            this.BtnObtenerLogsLocales.Name = "BtnObtenerLogsLocales";
            this.BtnObtenerLogsLocales.Size = new System.Drawing.Size(190, 32);
            this.BtnObtenerLogsLocales.TabIndex = 1;
            this.BtnObtenerLogsLocales.Text = "Obtener logs locales";
            this.BtnObtenerLogsLocales.UseVisualStyleBackColor = true;
            // 
            // BtnObtenerLogsBd
            // 
            this.BtnObtenerLogsBd.Location = new System.Drawing.Point(263, 29);
            this.BtnObtenerLogsBd.Name = "BtnObtenerLogsBd";
            this.BtnObtenerLogsBd.Size = new System.Drawing.Size(190, 32);
            this.BtnObtenerLogsBd.TabIndex = 2;
            this.BtnObtenerLogsBd.Text = "Obtener logs de base de datos";
            this.BtnObtenerLogsBd.UseVisualStyleBackColor = true;
            // 
            // TxtDetalleLog
            // 
            this.TxtDetalleLog.Location = new System.Drawing.Point(3, 350);
            this.TxtDetalleLog.Multiline = true;
            this.TxtDetalleLog.Name = "TxtDetalleLog";
            this.TxtDetalleLog.Size = new System.Drawing.Size(1020, 161);
            this.TxtDetalleLog.TabIndex = 3;
            // 
            // TxtFiltrar
            // 
            this.TxtFiltrar.Location = new System.Drawing.Point(131, 80);
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Size = new System.Drawing.Size(251, 23);
            this.TxtFiltrar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filtrar:";
            // 
            // LogsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.TxtDetalleLog);
            this.Controls.Add(this.BtnObtenerLogsBd);
            this.Controls.Add(this.BtnObtenerLogsLocales);
            this.Controls.Add(this.GridLogs);
            this.Name = "LogsPanel";
            this.Size = new System.Drawing.Size(1026, 514);
            ((System.ComponentModel.ISupportInitialize)(this.GridLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridLogs;
        private System.Windows.Forms.Button BtnObtenerLogsLocales;
        private System.Windows.Forms.Button BtnObtenerLogsBd;
        private System.Windows.Forms.TextBox TxtDetalleLog;
        private System.Windows.Forms.TextBox TxtFiltrar;
        private System.Windows.Forms.Label label1;
    }
}
