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
    public partial class ManualMonster : Form
    {
        MainWindow mainWindow;
        Monster mainMonster;

        List<Action> actionList;



        public ManualMonster(MainWindow mainForm, Monster monster)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            mainWindow = mainForm;
            ControlBox = false;
            mainMonster = monster;
            //traitList = monster.traitList;
            //actionList = monster.actionList;
            //legendaryList = monster.legendaryList;
            //reactionList = monster.reactionList;
            this.FillFields();





        }

        public void FillFields()
        {
            //txtName.Text = mainMonster.name;
            //txtSize.Text = mainMonster.size;
            //txtType.Text = mainMonster.type;
            //txtAlignment.Text = mainMonster.alignment;
            //txtAC.Text = mainMonster.AC;
            //txtHP.Text = mainMonster.HP;
            //txtSpeed.Text = mainMonster.speed;
            //txtSTR.Text = mainMonster.STR;
            //txtDEX.Text = mainMonster.DEX;
            //txtCON.Text = mainMonster.CON;
            //txtINT.Text = mainMonster.INT;
            //txtWIS.Text = mainMonster.WIS;
            //txtCHA.Text = mainMonster.CHA;
            //txtSkill.Text = mainMonster.skill;
            //txtPassive.Text = mainMonster.passive;
            //txtLanguages.Text = mainMonster.languages;
            //txtCR.Text = mainMonster.CR;
            //txtImmune.Text = mainMonster.immune;
            //txtSenses.Text = mainMonster.senses;
            //txtSave.Text = mainMonster.save;
            //txtResist.Text = mainMonster.resist;
            //txtVulnerable.Text = mainMonster.vulnerable;
            //txtConditionImmune.Text = mainMonster.conditionImmune;
            //rtboxDescription.Text = mainMonster.description;
            //txtSpells.Text = mainMonster.spells;
            //txtSlots.Text = mainMonster.slots;
            //txtInitiative.Text = mainMonster.initiative;

            //try
            //{
            //    foreach (var trait in mainMonster.traitList)
            //    {
            //        lstTrait.Items.Add(trait.name);
            //    }
            //}
            //catch
            //{

            //}
            
            //try
            //{
            //    foreach (var action in mainMonster.actionList)
            //    {
            //        lstAction.Items.Add(action.name);
            //    }
            //}
            //catch
            //{

            //}
            

            //try
            //{
            //    foreach (var legendary in mainMonster.legendaryList)
            //    {
            //        lstLegendary.Items.Add(legendary.name);
            //    }
            //}
            //catch
            //{

            //}
            

            //try
            //{
            //    foreach (var reaction in mainMonster.reactionList)
            //    {
            //        lstReaction.Items.Add(reaction.name);
            //    }

            //}
            //catch
            //{

            //}
            



        }

        public Monster TextToMonster()
        {
            Monster monster = new Monster();
            //monster.name = "N/A";
            //monster.size = "N/A";
            //monster.type = "N/A";
            //monster.alignment = "N/A";
            //monster.AC = "N/A";
            //monster.HP = "N/A";
            //monster.speed = "N/A";
            //monster.STR = "N/A";
            //monster.DEX = "N/A";
            //monster.CON = "N/A";
            //monster.INT = "N/A";
            //monster.WIS = "N/A";
            //monster.CHA = "N/A";
            //monster.skill = "N/A";
            //monster.passive = "N/A";
            //monster.languages = "N/A";
            //monster.CR = "N/A";
            //monster.immune = "N/A";
            //monster.senses = "N/A";
            //monster.save = "N/A";
            //monster.resist = "N/A";
            //monster.vulnerable = "N/A";
            //monster.conditionImmune = "N/A";
            //monster.description = "N/A";
            //monster.spells = "N/A";
            //monster.slots = "N/A";
            //monster.initiative = "N/A";
            
            //monster.traitList = traitList;
            //monster.actionList = actionList;
            //monster.legendaryList = legendaryList;
            //monster.reactionList = reactionList;








            

            

            //monster.name = txtName.Text;
            //monster.size = txtSize.Text;
            //monster.type = txtType.Text;
            //monster.alignment = txtAlignment.Text;
            //monster.AC = txtAC.Text;
            //monster.HP = txtHP.Text;
            //monster.speed = txtSpeed.Text;
            //monster.STR = txtSTR.Text;
            //monster.DEX = txtDEX.Text;
            //monster.CON = txtCON.Text;
            //monster.INT = txtINT.Text;
            //monster.WIS = txtWIS.Text;
            //monster.CHA = txtCHA.Text;
            //monster.skill = txtSkill.Text;
            //monster.passive = txtPassive.Text;
            //monster.languages = txtLanguages.Text;
            //monster.CR = txtCR.Text;
            //monster.immune = txtImmune.Text;
            //monster.senses = txtSenses.Text;
            //monster.save = txtSave.Text;
            //monster.resist = txtResist.Text;
            //monster.vulnerable = txtVulnerable.Text;
            //monster.conditionImmune = txtConditionImmune.Text;
            //monster.description = rtboxDescription.Text;
            //monster.spells = txtSpells.Text;
            //monster.slots = txtSlots.Text;
            //monster.initiative = txtInitiative.Text;

            return monster;
            
        }
       

        private void ManualMonster_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Monster monster = new Monster();

            //if (String.IsNullOrEmpty(txtName.Text))
            //{
            //    MessageBox.Show("A name is required.");
            //}
            //else
            //{
                


            //    var existing = mainWindow.monsterList.FirstOrDefault(x => x.name == txtName.Text);

            //    if (existing == null)
            //    {

            //        monster = TextToMonster();
            //        mainWindow.monsterList.Add(monster);
                    
                    
            //        mainWindow.RefreshMonsterList();
                    
            //        this.Close();
            //    }
            //    else
            //    {


            //        DialogResult dialogResult = MessageBox.Show("That name already exists. Are you sure you want to overwrite that monster?", "Are you sure?", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {



            //            int index = mainWindow.monsterList.IndexOf(existing);
            //            monster = TextToMonster();
            //            mainWindow.monsterList[index] = monster;
                        
            //            mainWindow.RefreshMonsterList();
                        
                       
            //            this.Close();

            //        }


                        
            //    }
            //}


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnAddTrait_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtTName.Text))
            //{
            //    MessageBox.Show("The trait needs a name.");
            //}
            //else
            //{

            //    Trait exists = traitList.FirstOrDefault(x => x.name == txtTName.Text);

            //    if (exists == null)
            //    {
            //        Trait trait = new Trait();
            //        List<string> textList = new List<string>();
            //        trait.name = txtTName.Text;

            //        textList.Add(txtTText.Text);
            //        trait.textList = textList;
            //        traitList.Add(trait);
            //        lstTrait.Items.Add(trait.name);
            //        txtTName.Text = "";
            //        txtTText.Text = "";
            //    }
            //    else
            //    {
            //        MessageBox.Show("A trait with that name already exists.");
            //    }

                
            //}

            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mainMonster = new Monster();
           
            actionList = new List<Action>();
          
            rtboxDescription.Text = "";


            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.Items.Clear();
                }
            }
        }

        private void lstTrait_DoubleClick(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Remove trait: " + lstTrait.SelectedItem.ToString() +  " ?", "Are you sure?", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    try
            //    {


            //        Trait trait = traitList.First(x => x.name == lstTrait.SelectedItem.ToString());

            //        traitList.Remove(trait);


            //        lstTrait.Items.Remove(lstTrait.SelectedItem);
            //    }
            //    catch
            //    {

            //    }

            //}

            
        }

        private void lstAction_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Remove action: " + lstAction.SelectedItem.ToString() + " ?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {


                    Action action = actionList.First(x => x.name == lstAction.SelectedItem.ToString());

                    actionList.Remove(action);


                    lstAction.Items.Remove(lstAction.SelectedItem);
                }
                catch
                {

                }

            }
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAName.Text))
            {
                MessageBox.Show("The action needs a name.");
            }
            else
            {

                Action exists = actionList.FirstOrDefault(x => x.name == txtAName.Text);

                if (exists == null)
                {
                    Action action = new Action();
                    
                    action.name = txtAName.Text;
                    action.text = txtAText.Text;
                    actionList.Add(action);
                    lstAction.Items.Add(action.name);
                    txtAName.Text = "";
                    txtAText.Text = "";
                }
                else
                {
                    MessageBox.Show("An action with that name already exists.");
                }


            }
        }

        private void btnAddLegendary_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtLName.Text))
            //{
            //    MessageBox.Show("The legendary needs a name.");
            //}
            //else
            //{

            //    Legendary exists = legendaryList.FirstOrDefault(x => x.name == txtLName.Text);

            //    if (exists == null)
            //    {
            //        Legendary legendary = new Legendary();

            //        legendary.name = txtLName.Text;
            //        legendary.text = txtLText.Text;
            //        legendaryList.Add(legendary);
            //        lstLegendary.Items.Add(legendary.name);
            //        txtLName.Text = "";
            //        txtLText.Text = "";
            //    }
            //    else
            //    {
            //        MessageBox.Show("A legendary action with that name already exists.");
            //    }


            //}
        }

        private void btnAddReaction_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtRName.Text))
            //{
            //    MessageBox.Show("The reaction needs a name.");
            //}
            //else
            //{
                
            //        Reaction exists = reactionList.FirstOrDefault(x => x.name == txtRName.Text);
                
                

            //    if (exists == null)
            //    {
            //        Reaction reaction = new Reaction();

            //        reaction.name = txtRName.Text;
            //        reaction.text = txtRText.Text;
            //        reactionList.Add(reaction);
            //        lstReaction.Items.Add(reaction.name);
            //        txtRName.Text = "";
            //        txtRText.Text = "";
            //    }
            //    else
            //    {
            //        MessageBox.Show("A reaction with that name already exists.");
            //    }


            //}
        }

        private void lstLegendary_DoubleClick(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Remove legendary action: " + lstLegendary.SelectedItem.ToString() + " ?", "Are you sure?", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    try
            //    {


            //        Legendary legendary = legendaryList.First(x => x.name == lstLegendary.SelectedItem.ToString());

            //        legendaryList.Remove(legendary);


            //        lstLegendary.Items.Remove(lstLegendary.SelectedItem);
            //    }
            //    catch
            //    {

            //    }

            //}
        }

        private void lstReaction_DoubleClick(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Remove reaction: " + lstReaction.SelectedItem.ToString() + " ?", "Are you sure?", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    try
            //    {


            //        Reaction reaction = reactionList.First(x => x.name == lstReaction.SelectedItem.ToString());

            //        reactionList.Remove(reaction);


            //        lstReaction.Items.Remove(lstReaction.SelectedItem);
            //    }
            //    catch
            //    {

            //    }

            //}
        }
    }
}
