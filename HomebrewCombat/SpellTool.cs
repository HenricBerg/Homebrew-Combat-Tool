using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomebrewCombat.Models;

namespace HomebrewCombat
{
    public partial class SpellTool : Form
    {

        List<Spell> spellList = new List<Spell>();
        public SpellTool()
        {
            InitializeComponent();
            RefreshSpells();
        }

   

        private void btnDBMenu_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
        }

        public void RefreshSpells()
        {
            spellList.Clear();
            foreach (var spell in Program.mainForm.spellList)
            {
                spellList.Add(spell);
            }



            int listIndex = lstSpells.SelectedIndex;
            lstSpells.Items.Clear();

            var sortedList = spellList.OrderBy(x => x.name);

            foreach (var spell in sortedList)
            {
                lstSpells.Items.Add(spell.name);
            }


            try
            {
                lstSpells.SelectedIndex = listIndex;
                var spell = spellList.First(x => x.name == lstSpells.SelectedItem.ToString());
                ShowDetails(spell);


            }
            catch
            {
                tbxSpellDescription.Text = "";
            }


            txtSpellSearch.ForeColor = Color.LightGray;
            txtSpellSearch.Font = new Font(txtSpellSearch.Font, FontStyle.Italic);
            txtSpellSearch.Text = "Search...";
        }



        public void ShowDetails(Spell spell)
        {






            var fullDescription = @"Name: " + spell.name + @"
Level: " + spell.level + @" 
School: " + spell.school + @"
Time: " + spell.time + @"
Range: " + spell.range + @"
Components: " + spell.components + @"
Duration: " + spell.duration + @"
Classes: " + spell.classes + @"
Ritual: " + spell.ritual;



            fullDescription += @"

Text: 
";

            foreach (var text in spell.textList)
            {
                fullDescription += @"
" + text + @"
";
            }

            

            tbxSpellDescription.Text = fullDescription;

        }

        private void lstSpells_MouseClick(object sender, MouseEventArgs e)
        {

            if (lstSpells.SelectedIndex != -1)
            {
                var spell = spellList.First(x => x.name == lstSpells.SelectedItem.ToString());
                ShowDetails(spell);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSpellSearch.Text) || txtSpellSearch.Font.Italic)
            {
                RefreshSpells();
            }
            else
            {
                try
                {
                    List<Spell> searchList = spellList.FindAll(x => x.name.ToLower().Contains(txtSpellSearch.Text.ToLower()));
                    ShowSearchList(searchList);


                }
                catch
                {
                    lstSpells.Items.Clear();
                    lstSpells.Items.Add("No spells found.");
                }
            }
        }


        public void ShowSearchList(List<Spell> searchList)
        {

            int listIndex = lstSpells.SelectedIndex;
            lstSpells.Items.Clear();
            if (searchList.Count > 0)
            {
                foreach (var spell in searchList)
                {
                    lstSpells.Items.Add(spell.name);
                }

            }
            else
            {

                lstSpells.Items.Clear();
                lstSpells.Items.Add("No spells found.");

            }



            tbxSpellDescription.Text = "";



            txtSpellSearch.ForeColor = Color.LightGray;
            txtSpellSearch.Font = new Font(txtSpellSearch.Font, FontStyle.Italic);
            txtSpellSearch.Text = "Search...";



        }

        private void txtSpellSearch_Enter(object sender, EventArgs e)
        {
            if (txtSpellSearch.Font.Italic)
            {
                txtSpellSearch.ForeColor = Color.Black;
                txtSpellSearch.Font = new Font(txtSpellSearch.Font, FontStyle.Regular);
                txtSpellSearch.Text = "";
            }
        }

        private void txtSpellSearch_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSpellSearch.Text))
            {
                txtSpellSearch.ForeColor = Color.LightGray;
                txtSpellSearch.Font = new Font(txtSpellSearch.Font, FontStyle.Italic);
                txtSpellSearch.Text = "Search...";
            }
        }

        private void txtSpellSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
                txtSpellSearch.Focus();
                txtSpellSearch.ForeColor = Color.Black;
                txtSpellSearch.Font = new Font(txtSpellSearch.Font, FontStyle.Regular);
                txtSpellSearch.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
