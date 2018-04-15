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
    public partial class InitCheck : Form
    {
        List<Combatant> checkedList = new List<Combatant>();
        List<Combatant> fullList = new List<Combatant>();



        public InitCheck(List<Combatant> fullList)
        {
            InitializeComponent();


            Combatant highestInitCombatant = new Combatant();
            this.fullList.Clear();
            var compareList = new List<Combatant>();
            int highestInit = -1000;
            int index = 0;



            foreach (var combatant in fullList)
            {
                compareList.Add(combatant);
            }


            while (compareList.Count > 0)
            {
                foreach (var combatant in compareList)
                {
                    if (int.Parse(combatant.initiative) > highestInit)
                    {
                        highestInitCombatant = combatant;
                        highestInit = int.Parse(highestInitCombatant.initiative);
                    }

                }
                highestInit = -1000;
                this.fullList.Add(highestInitCombatant);
                compareList.Remove(highestInitCombatant);
                index++;

            }





            foreach (var combatant in this.fullList)
            {




                

              
                lstInclude.Items.Add("ID#" + combatant.ID + ": " + combatant.name + ", HP: " + combatant.HP + "  -  Init: " + combatant.initiative);

            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var compareList = new List<Combatant>();

            foreach (var combatant in lstInclude.Items)
            {

                int indexStart = combatant.ToString().IndexOf("#");
                int indexStop = combatant.ToString().IndexOf(":");

                
                Combatant addCombatant = fullList.Find(x => x.ID.ToString() == combatant.ToString().Substring((indexStart + 1), (indexStop - 3)));
                compareList.Add(addCombatant);





                
            }


            Combatant highestInitCombatant = new Combatant();
            
            
            int highestInit = -1000;
            



           


            while (compareList.Count > 0)
            {
                foreach (var combatant in compareList)
                {
                    if (int.Parse(combatant.initiative) > highestInit)
                    {
                        highestInitCombatant = combatant;
                        highestInit = int.Parse(highestInitCombatant.initiative);
                    }

                }
                highestInit = -1000;
                checkedList.Add(highestInitCombatant);
                compareList.Remove(highestInitCombatant);
                

            }




            InitiativeUI initUI = new InitiativeUI(checkedList);
            initUI.Show();
            Dispose();



        }

        private void lstInclude_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                lstExclude.Items.Add(lstInclude.SelectedItem);
                lstInclude.Items.Remove(lstInclude.SelectedItem);
            }
            catch
            {

            }

        }

        private void lstExclude_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                lstInclude.Items.Add(lstExclude.SelectedItem);
                lstExclude.Items.Remove(lstExclude.SelectedItem);
            }
            catch
            {

            }

        }
    }
}
