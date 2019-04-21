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
        public int timerSec = 0;


        public InitiativeUI(List<Combatant> checkedList)
        {


            InitializeComponent();

            foreach (var combatant in checkedList)
            {
                initiativeList.Add(combatant);
            }

        }

        private void InitiativeUI_Load(object sender, EventArgs e)
        {
            


            


            if (initiativeList.Count > 0)
            {
                lblCurrent.Text = initiativeList[0].name + ", ID:" + initiativeList[0].ID;
                
                combatantCount = initiativeList.Count;

                if (initiativeList.Count > 1)
                {
                    lblNext.Text = initiativeList[1].name + ", ID:" + initiativeList[1].ID;
                }
                else
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            timerSec = 0;
            btnNext.ForeColor = Color.Black;
            btnNext.Text = "NEXT!";
            tmrCombat.Enabled = true;
            tmrCombat.Stop();
            tmrCombat.Start();





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
                    lblCurrent.Text = "NO ONE";
                    lblNext.Text = "NO ONE";
                }

            }



        }

        private void tmrCombat_Tick(object sender, EventArgs e)
        {

            timerSec++;
            btnNext.Text = timerSec.ToString();

            if (timerSec > 14)
            {
                if (timerSec < 30)
                {
                    btnNext.ForeColor = Color.Yellow;
                }
                else
                {
                    btnNext.ForeColor = Color.Red;
                    
                }

                if (timerSec > 59)
                {
                    btnNext.Text = "NEXT!";
                    tmrCombat.Stop();

                }

            }
            

            

           
        }
    }
}
