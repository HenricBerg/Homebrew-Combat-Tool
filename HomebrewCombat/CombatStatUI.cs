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
    public partial class CombatStatUI : Form
    {
        private int animateCombatCount = 1;
        private int animateHealCount = 1;
        List<Combatant> combatantList = FileHandler.GetCombatantListFromFile();

        public CombatStatUI(Combatant combatant)
        {
            InitializeComponent();
            Name = combatant.ID.ToString();
            Text = Text + " ID#" + combatant.ID;
            Refresh(combatant);









        }

        public void ColorSync()
        {
            richTextBox1.BackColor = BackColor;
        }

        public void Refresh(Combatant combatant)
        {

            lblNameID.Text = combatant.name + ", ID: " + combatant.ID;
            lblAC.Text = combatant.AC;
            lblHP.Text = combatant.HP.ToString();
            lblSave.Text = combatant.save;



        }


        private void CombatStatUI_Load(object sender, EventArgs e)
        {

           combatantList = FileHandler.GetCombatantListFromFile();


            var _point = new Point(Cursor.Position.X, Cursor.Position.Y);
            Top = _point.Y - 10;
            Left = _point.X - 40;

            



        }

        public void Death()
        {
            tmrAnimateCombat.Stop();
            tmrAnimateHeal.Stop();
            pbxExp.Image = Properties.Resources.skull;
        }

        public void AnimateCombat()
        {
            tmrAnimateCombat.Start();
        }

        public void AnimateHeal()
        {
            tmrAnimateHeal.Start();
        }

        private void tmrAnimateCombat_Tick(object sender, EventArgs e)
        {

            switch (animateCombatCount)
            {
                case 1:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp1;
                    break;

                case 2:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp2;
                    break;
                case 3:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp3;
                    break;
                case 4:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp4;
                    break;
                case 5:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp5;
                    break;
                case 6:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp6;
                    break;
                case 7:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp7;
                    break;
                case 8:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp8;
                    break;
                case 9:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp9;
                    break;
                case 10:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp10;
                    break;
                case 11:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp11;
                    break;
                case 12:
                    animateCombatCount++;
                    pbxExp.Image = Properties.Resources.exp12;
                    break;
                case 13:
                    animateCombatCount = 1;
                    pbxExp.Image = null;
                    tmrAnimateCombat.Stop();
                    break;






            }
        }



        

        private void tmrAnimateHeal_Tick(object sender, EventArgs e)
        {
            switch (animateHealCount)
            {
                case 1:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._1;
                    break;

                case 2:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._2;
                    break;
                case 3:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._3;
                    break;
                case 4:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._4;
                    break;
                case 5:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._5;
                    break;
                case 6:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._6;
                    break;
                case 7:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._7;
                    break;
                case 8:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._8;
                    break;
                case 9:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._9;
                    break;
                case 10:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._10;
                    break;
                case 11:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._11;
                    break;
                case 12:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._12;
                    break;
                case 13:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._13;
                    break;
                case 14:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._14;
                    break;
                case 15:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._15;
                    break;
                case 16:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._16;
                    break;
                case 17:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._17;
                    break;
                case 18:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._18;
                    break;
                case 19:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._19;
                    break;
                case 20:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._20;
                    break;
                case 21:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._21;
                    break;
                case 22:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._22;
                    break;
                case 23:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._23;
                    break;
                case 24:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._24;
                    break;
                case 25:
                    animateHealCount++;
                    pbxExp.Image = Properties.Resources._25;
                    break;
                case 26:
                    animateHealCount = 1;
                    pbxExp.Image = null;
                    tmrAnimateHeal.Stop();
                    break;
            }
        }

        private void btnModifyCombatant_Click(object sender, EventArgs e)
        {
            try
            {
                int HPChange = 0;

                if (rbtnN10.Checked)
                {
                    HPChange = -10;
                }
                if (rbtnN5.Checked)
                {
                    HPChange = -5;
                }
                if (rbtnN1.Checked)
                {
                    HPChange = -1;
                }
                if (rbtnP10.Checked)
                {
                    HPChange = 10;
                }
                if (rbtnP5.Checked)
                {
                    HPChange = 5;
                }
                if (rbtnP1.Checked)
                {
                    HPChange = 1;
                }




               
            string[] stringArray = lblNameID.Text.Split(':');


            
            Combatant combatant = MainWindow.monsterCombatants.Single(x => x.ID.ToString() == stringArray[1].Trim(' '));

            combatant.HP = combatant.HP + HPChange;

            
               
                if (HPChange < 0)
                {

                    AnimateCombat();
                }
                else if (HPChange > 0)
                {
                    AnimateHeal();
                }

                if (combatant.HP < 1)
                {
                    Death();
                }


          


            Program.mainForm.RefreshCombatList();
        }
            catch
            {

                MessageBox.Show("HP-value must be an integer.");


            }
}
    }
}
