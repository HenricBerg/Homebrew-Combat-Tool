using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomebrewCombat
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            Program.mainForm.Merge();
            Dispose();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Program.mainForm.DownloadDatabase();
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileHandler.SaveMonsterListToFileAs(Program.mainForm.monsterList);
            Dispose();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Program.mainForm.monsterList = FileHandler.GetMonsterListFromSelectedFile();
            Program.mainForm.RefreshMonsterList();
            Dispose();
        }
    }
}
