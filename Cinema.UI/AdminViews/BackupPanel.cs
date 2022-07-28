using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.AdminViews
{
    public partial class BackupPanel : UserControl
    {
        LanguageService _languageService;
        BackupServices _backupServices;
        public BackupPanel(LanguageService languageService, BackupServices backupServices)
        {
            InitializeComponent();
            this.Tag = "text_backup_restore_panel_title";
            _languageService = languageService;
            _backupServices = backupServices;
        }

        private void BtnExaminarBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.bak | Archivos de copia de seguridad";
            saveFileDialog.Title = _languageService.TranslateCode("text_save_backup");
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK || saveFileDialog.ShowDialog() != DialogResult.Yes)
                return;
            if (saveFileDialog.CheckPathExists)
            {
                _backupServices.BackupDatabase(ComboDb.Text, saveFileDialog.FileName);
            }
        }

        private void BtnExaminarRestore_Click(object sender, EventArgs e)
        {

        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {

        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {

        }

        private void ComboDb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
