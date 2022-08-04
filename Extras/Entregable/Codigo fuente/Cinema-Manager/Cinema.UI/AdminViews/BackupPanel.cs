using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.AdminViews
{
    /// <summary>
    /// Panel de administracion de backups y restauracion de backups.
    /// </summary>
    public partial class BackupPanel : UserControl
    {
        LanguageService _languageService;
        BackupServices _backupServices;
        /// <summary>
        /// Constructor con servicios de inyeccion de dependencia.
        /// </summary>
        /// <param name="languageService"></param>
        /// <param name="backupServices"></param>
        public BackupPanel(LanguageService languageService, BackupServices backupServices)
        {
            InitializeComponent();
            this.Tag = "text_backup_restore_panel_title";
            _languageService = languageService;
            _backupServices = backupServices;
        }

        private void BtnExaminarBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                BtnBackup.Enabled = ComboDb.SelectedIndex != -1 ? true : false;
                TxtBackup.Text = folderBrowserDialog.SelectedPath;               
            }
        }

        private void BtnExaminarRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Sql Server Backup Files (*.bak)|*.bak";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TxtRestore.Text = ofd.FileName;
                BtnRestore.Enabled = ComboDb.SelectedIndex != -1 ? true : false;

            }
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            _backupServices.BackupDatabase(ComboDb.Text, TxtBackup.Text);
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            _backupServices.RestoreDatabase(ComboDb.Text, TxtRestore.Text);
        }

        private void ComboDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnExaminarBackup.Enabled = ComboDb.SelectedIndex != -1 ? true : false;
            BtnExaminarRestore.Enabled = ComboDb.SelectedIndex != -1 ? true : false;
        }
    }
}
