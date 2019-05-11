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

        private void btnReset_Click(object sender, EventArgs e)
        {
            Program.mainForm.Reset();
        }

        private void btnLoadSpells_Click(object sender, EventArgs e)
        {
            Program.mainForm.spellList = SpellFileHandler.GetSpellListFromSelectedFile();


            List<Form> formList = new List<Form>();

            foreach (Form f in Application.OpenForms)
            {

                formList.Add(f);

            }

            foreach (Form f in formList)
            {
                if (f is SpellTool)
                {
                    SpellTool x = (SpellTool)f;
                    x.RefreshSpells();
                }


            }

            Dispose();

        }

        private void btnSaveSpell_Click(object sender, EventArgs e)
        {
            SpellFileHandler.SaveSpellListToFileAs(Program.mainForm.spellList);
            Dispose();
        }

        

        private void btnDuplicates_Click(object sender, EventArgs e)
        {
            List<Monster> newList = new List<Monster>();
            
            foreach (Monster monster in Program.mainForm.monsterList)
            {
                string testName = monster.name;

                List<Monster> found = newList.Where(x => x.name == testName).ToList();

                if (found.Count < 1)
                {
                    newList.Add(monster);
                }
                
            }

            Program.mainForm.monsterList.Clear();

            foreach(Monster monster in newList)
            {
                Program.mainForm.monsterList.Add(monster);
            }

            Program.mainForm.RefreshMonsterList();

        }
    }
}
