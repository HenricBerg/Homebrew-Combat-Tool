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
    public partial class InitiativeUI : Form
    {
        public int counter = 0;
        public int combatantCount = 0;
        public List<Combatant> initiativeList = new List<Combatant>();


        public InitiativeUI()
        {
            InitializeComponent();
        }

        private void InitiativeUI_Load(object sender, EventArgs e)
        {
            foreach (var combatant in Program.mainForm.initiativeList)
            {
                initiativeList.Add(combatant);
            }


            initiativeList.Count();


            if (initiativeList.Count > 0)
            {
                lblCurrent.Text = initiativeList[0].name + ", ID:" + initiativeList[0].ID;
                combatantCount = initiativeList.Count;
            }
            else
            {
                lblCurrent.Text = "NO ONE";
                lblNext.Text = "NO ONE";
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {






            counter++;
            if (counter == combatantCount)
            {
                counter = 0;
                if (initiativeList.Count > 0)
                {
                    lblCurrent.Text = initiativeList[counter].name + ", ID:" + initiativeList[counter].ID;
                    try
                    {
                        lblNext.Text = initiativeList[counter + 1].name + ", ID:" + initiativeList[counter + 1].ID;
                    }
                    catch
                    {
                        lblNext.Text = "NO ONE";
                    }

                }
                else
                {
                    lblCurrent.Text = "NO ONE";
                    lblNext.Text = "NO ONE";
                }
            }
            else
            {

                if (initiativeList.Count > 0)
                {
                    lblCurrent.Text = initiativeList[counter].name + ", ID:" + initiativeList[counter].ID;
                    try
                    {
                        lblNext.Text = initiativeList[counter + 1].name + ", ID:" + initiativeList[counter + 1].ID;
                    }
                    catch
                    {
                        lblNext.Text = initiativeList[0].name + ", ID:" + initiativeList[0].ID; ;
                    }
                }
                else
                {
                    lblCurrent.Text = "NO ONE!";
                    lblNext.Text = "NO ONE!";
                }

            }



        }
    }
}
