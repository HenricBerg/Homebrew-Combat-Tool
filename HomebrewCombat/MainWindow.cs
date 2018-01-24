using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace HomebrewCombat
{
    public partial class MainWindow : Form
    {
        public List<Monster> monsterList = new List<Monster>();
        public static List<Combatant> monsterCombatants = new List<Combatant>();
        public List<Condition> defaultConditions = new List<Condition>();
        public static int combatantID = 0;




        public MainWindow()
        {

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;


            monsterList = FileHandler.GetMonsterListFromFile();
            monsterCombatants = FileHandler.GetCombatantListFromFile();


            foreach (var combatant in monsterCombatants)
            {
                if (combatantID < combatant.ID)
                {
                    combatantID = combatant.ID;
                }

            }



            RefreshMonsterList();
            RefreshDefaultConditions();
            RefreshCombatList();





        }

        public void manualAddCombatant(string name, string init, string AC, int HP, string saves)
        {
            Combatant combatant = new Combatant();
            combatant.AC = AC;
            combatant.HP = HP;
            combatant.save = saves;
            combatant.name = name;
            combatant.initiative = init;
            combatant.ID = combatantID + 1;
            combatantID++;
            monsterCombatants.Add(combatant);
            RefreshCombatList();

        }


        public void RefreshDefaultConditions()
        {

            Condition condition = new Condition();
            List<string> conditionDescription = new List<string>();

            condition.name = "Blinded";
            conditionDescription.Add("A blinded creature can’t see and automatically fails any ability check that requires sight.");
            conditionDescription.Add("Attack rolls against the creature have advantage, and the creature’s Attack rolls have disadvantage.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Charmed";
            conditionDescription.Add("A charmed creature can’t Attack the charmer or target the charmer with harmful Abilities or magical effects.");
            conditionDescription.Add("The charmer has advantage on any ability check to interact socially with the creature.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Deafened";
            conditionDescription.Add("A deafened creature can’t hear and automatically fails any ability check that requires hearing.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Frightened";
            conditionDescription.Add("A frightened creature has disadvantage on Ability Checks and Attack rolls while the source of its fear is within line of sight.");
            conditionDescription.Add("The creature can’t willingly move closer to the source of its fear.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Grappled";
            conditionDescription.Add("A grappled creature’s speed becomes 0, and it can’t benefit from any bonus to its speed.");
            conditionDescription.Add("The condition ends if the Grappler is incapacitated (see the condition).");
            conditionDescription.Add("The condition also ends if an effect removes the grappled creature from the reach of the Grappler or Grappling effect, such as when a creature is hurled away by the Thunderwave spell.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Incapacitated";
            conditionDescription.Add("An incapacitated creature can’t take actions or reactions.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Invisible";
            conditionDescription.Add("An invisible creature is impossible to see without the aid of magic or a Special sense. For the purpose of Hiding, the creature is heavily obscured. The creature’s location can be detected by any noise it makes or any tracks it leaves.");
            conditionDescription.Add("Attack rolls against the creature have disadvantage, and the creature’s Attack rolls have advantage.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Paralyzed";
            conditionDescription.Add("A paralyzed creature is incapacitated (see the condition) and can’t move or speak.");
            conditionDescription.Add("The creature automatically fails Strength and Dexterity saving throws.");
            conditionDescription.Add("Attack rolls against the creature have advantage.");
            conditionDescription.Add("Any Attack that hits the creature is a critical hit if the attacker is within 5 feet of the creature.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Petrified";
            conditionDescription.Add("A petrified creature is transformed, along with any nonmagical object it is wearing or carrying, into a solid inanimate substance (usually stone). Its weight increases by a factor of ten, and it ceases aging.");
            conditionDescription.Add("The creature is incapacitated (see the condition), can’t move or speak, and is unaware of its surroundings.");
            conditionDescription.Add("Attack rolls against the creature have advantage.");
            conditionDescription.Add("The creature automatically fails Strength and Dexterity saving throws.");
            conditionDescription.Add("The creature has Resistance to all damage.");
            conditionDescription.Add("The creature is immune to poison and disease, although a poison or disease already in its system is suspended, not neutralized.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Poisoned";
            conditionDescription.Add("A poisoned creature has disadvantage on Attack rolls and Ability Checks.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Prone";
            conditionDescription.Add("A prone creature’s only Movement option is to crawl, unless it stands up and thereby ends the condition.");
            conditionDescription.Add("The creature has disadvantage on Attack rolls.");
            conditionDescription.Add("An Attack roll against the creature has advantage if the attacker is within 5 feet of the creature. Otherwise, the Attack roll has disadvantage.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Restrained";
            conditionDescription.Add("A restrained creature’s speed becomes 0, and it can’t benefit from any bonus to its speed.");
            conditionDescription.Add("Attack rolls against the creature have advantage, and the creature’s Attack rolls have disadvantage.");
            conditionDescription.Add("Attack rolls against the creature have advantage.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Stunned";
            conditionDescription.Add("A stunned creature is incapacitated (see the condition), can’t move, and can speak only falteringly.");
            conditionDescription.Add("The creature automatically fails Strength and Dexterity saving throws.");
            conditionDescription.Add("The creature has disadvantage on Dexterity saving throws.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Unconscious";
            conditionDescription.Add("An unconscious creature is incapacitated (see the condition), can’t move or speak, and is unaware of its surroundings.");
            conditionDescription.Add("The creature drops whatever it’s holding and falls prone.");
            conditionDescription.Add("The creature automatically fails Strength and Dexterity saving throws.");
            conditionDescription.Add("Attack rolls against the creature have advantage.");
            conditionDescription.Add("Any Attack that hits the creature is a critical hit if the attacker is within 5 feet of the creature.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Exhaustion Level 1";
            conditionDescription.Add("Disadvantage on Ability Checks");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Exhaustion Level 2";
            conditionDescription.Add("Disadvantage on Ability Checks");
            conditionDescription.Add("Speed halved");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Exhaustion Level 3";
            conditionDescription.Add("Disadvantage on Ability Checks");
            conditionDescription.Add("Speed halved");
            conditionDescription.Add("Disadvantage on Attack rolls and saving throws");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Exhaustion Level 4";
            conditionDescription.Add("Disadvantage on Ability Checks");
            conditionDescription.Add("Speed halved");
            conditionDescription.Add("Disadvantage on Attack rolls and saving throws");
            conditionDescription.Add("Hit point maximum halved");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Exhaustion Level 5";
            conditionDescription.Add("Disadvantage on Ability Checks");
            conditionDescription.Add("Speed halved");
            conditionDescription.Add("Disadvantage on Attack rolls and saving throws");
            conditionDescription.Add("Hit point maximum halved");
            conditionDescription.Add("Speed reduced to 0");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Exhaustion Level 6";
            conditionDescription.Add("Disadvantage on Ability Checks");
            conditionDescription.Add("Speed halved");
            conditionDescription.Add("Disadvantage on Attack rolls and saving throws");
            conditionDescription.Add("Hit point maximum halved");
            conditionDescription.Add("Speed reduced to 0");
            conditionDescription.Add("Death");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Advantage (manual)";
            conditionDescription.Add("Roll 2d20 and choose the highest result.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);

            condition = new Condition();
            conditionDescription = new List<string>();
            condition.name = "Disadvantage (manual)";
            conditionDescription.Add("Roll 2d20 and choose the lowest result.");
            condition.descriptionList = conditionDescription;
            defaultConditions.Add(condition);


            foreach (var item in defaultConditions)
            {
                lstDefaultConditions.Items.Add(item.name);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ALWAYS make sure have a backup of your current database before proceeding with this step.");
            DialogResult dialogResult = MessageBox.Show("This action will take some time, and will reset the database to its original state. Are you sure you want to continiue?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                monsterList = FileHandler.GetMonsterListFromWeb();


                MessageBox.Show("The database has been downloaded.");
            }

            lstMonsterList.Items.Clear();
            rtboxDetails.Clear();
            RefreshMonsterList();
            txtModifyHP.Text = "0";



        }

        public void PopOutCombat()
        {
            if (lstCombat.SelectedIndex != -1)
            {
                int indexStart = lstCombat.SelectedItem.ToString().IndexOf("#");
                int indexStop = lstCombat.SelectedItem.ToString().IndexOf(":");


                Combatant combatant = monsterCombatants.Find(x => x.ID.ToString() == lstCombat.SelectedItem.ToString().Substring((indexStart + 1), (indexStop - 3)));

                Form form = Application.OpenForms[combatant.ID.ToString()];
                if (form == null)
                {
                    CombatStatUI statUI = new CombatStatUI(combatant);

                    statUI.Show();
                }
                else
                {
                    form.Dispose();
                    CombatStatUI statUI = new CombatStatUI(combatant);

                    statUI.Show();
                }






            }
            else
            {
                MessageBox.Show("You need to select a monster from the combat list.");
            }
        }



        private void lstMonsterList_MouseClick(object sender, MouseEventArgs e)
        {

            if (lstMonsterList.SelectedIndex != -1)
            {
                var monster = monsterList.First(x => x.name == lstMonsterList.SelectedItem.ToString());
                ShowDetails(monster);
            }



        }

        public void RefreshMonsterList()
        {
            FileHandler.SaveMonsterListToFile(monsterList);
            monsterList = FileHandler.GetMonsterListFromFile();
            int listIndex = lstMonsterList.SelectedIndex;
            lstMonsterList.Items.Clear();

            var sortedList = monsterList.OrderBy(x => x.name);

            foreach (var monster in sortedList)
            {
                lstMonsterList.Items.Add(monster.name);
            }


            try
            {
                lstMonsterList.SelectedIndex = listIndex;
                var monster = monsterList.First(x => x.name == lstMonsterList.SelectedItem.ToString());
                ShowDetails(monster);


            }
            catch
            {
                rtboxDetails.Text = "";
            }


            txtMonsterSearch.ForeColor = Color.LightGray;
            txtMonsterSearch.Font = new Font(txtMonsterSearch.Font, FontStyle.Italic);
            txtMonsterSearch.Text = "Search...";



        }


        public void ShowSearchList(List<Monster> searchList)
        {

            int listIndex = lstMonsterList.SelectedIndex;
            lstMonsterList.Items.Clear();
            if (searchList.Count > 0)
            {
                foreach (var monster in searchList)
                {
                    lstMonsterList.Items.Add(monster.name);
                }

            }
            else
            {

                lstMonsterList.Items.Clear();
                lstMonsterList.Items.Add("No monsters found.");

            }



            rtboxDetails.Text = "";



            txtMonsterSearch.ForeColor = Color.LightGray;
            txtMonsterSearch.Font = new Font(txtMonsterSearch.Font, FontStyle.Italic);
            txtMonsterSearch.Text = "Search...";



        }



        public void RefreshCombatList()
        {


            FileHandler.SaveCombatantListToFile(monsterCombatants);


            int listIndex = lstCombat.SelectedIndex;
            lstCombat.Items.Clear();
            Combatant highestInitCombatant = new Combatant();
            var initiativeList = new List<Combatant>();
            var compareList = new List<Combatant>();
            int highestInit = -1000;
            int index = 0;



            foreach (var combatant in monsterCombatants)
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
                initiativeList.Add(highestInitCombatant);
                compareList.Remove(highestInitCombatant);
                index++;

            }


            foreach (var combatant in initiativeList)
            {
                lstCombat.Items.Add("ID#" + combatant.ID + ": " + combatant.name + ", HP: " + combatant.HP + "  -  Init: " + combatant.initiative);

               

                Form form = Application.OpenForms[combatant.ID.ToString()];
                if (form != null)
                {
                    CombatStatUI statUI = (CombatStatUI)form;
                    statUI.Refresh(combatant);
                }
                


                


            }



            try
            {
                lstCombat.SelectedIndex = listIndex;

            }
            catch
            {
                try
                {
                    lstCombat.SelectedIndex = listIndex - 1;
                }
                catch
                {

                }
            }



        }

        public void ShowDetails(Monster monster)
        {






            var fullDescription = @"Name: " + monster.name + @"
Description: " + monster.description + @" 
Size: " + monster.size + @"
Type: " + monster.type + @"
Alignment: " + monster.alignment + @"
Senses: " + monster.senses + @"
Initiative modifier: " + monster.initiative + @"
AC: " + monster.AC + @"
HP: " + monster.HP + @"
CR: " + monster.CR + @"
Speed: " + monster.speed + @"
STR: " + monster.STR + @"
DEX: " + monster.DEX + @"
CON: " + monster.CON + @"
INT: " + monster.INT + @"
WIS: " + monster.WIS + @"
CHA: " + monster.CHA + @"
Saving Throws: " + monster.save + @"
Skills: " + monster.skill + @"
Passive Perception: " + monster.passive + @"
Languages: " + monster.languages + @"
Physical Immunities: " + monster.immune + @"
Condition Immunities: " + monster.conditionImmune + @"
Resistances: " + monster.resist + @"
Vulnerabilites: " + monster.vulnerable + @"
Spells: " + monster.spells + @"
Spell Slots: " + monster.slots;



            fullDescription += @"

Traits: 
";

            foreach (var trait in monster.traitList)
            {
                fullDescription += @"
" + trait.name + @"
";

                foreach (var text in trait.textList)
                {
                    if (text.Equals(""))
                    {
                        continue;
                    }
                    fullDescription += @"
" + text + @"
";
                }

            }

            fullDescription += @"


Actions: 
";


            foreach (var action in monster.actionList)
            {
                fullDescription += @"
" + action.name + @"
" + action.text + @"
";
            }

            fullDescription += @"


Reactions: 
";


            foreach (var reaction in monster.reactionList)
            {
                fullDescription += @"
" + reaction.name + @"
" + reaction.text + @"
";
            }

            fullDescription += @"


Legendary Actions: 
";


            foreach (var legendary in monster.legendaryList)
            {
                fullDescription += @"
" + legendary.name + @"
" + legendary.text + @"
";
            }

            rtboxDetails.Text = fullDescription;

        }

        private void btnAddToCombat_Click(object sender, EventArgs e)
        {
            if (lstMonsterList.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a monster from the monster list.");
            }
            else
            {
                Random initd20 = new Random();
                Combatant combatant = new Combatant();
                var monster = monsterList.First(x => x.name == lstMonsterList.SelectedItem.ToString());

                int init = 0;
                try
                {
                    init = (initd20.Next(1, 21) + int.Parse(monster.initiative));
                }
                catch
                {

                }


                string[] hpSplit = monster.HP.Split(new string[] { " " }, StringSplitOptions.None);

                combatant.name = monster.name;
                combatant.initiative = init.ToString();
                combatant.ID = combatantID + 1;
                combatant.HP = 0;
                combatant.AC = monster.AC;
                combatant.save = monster.save;
                try
                {
                    combatant.HP = int.Parse(hpSplit[0]);
                }
                catch
                {

                }

                combatantID++;
                monsterCombatants.Add(combatant);

                RefreshCombatList();


            }
        }

        private void btnRemoveFromCombat_Click(object sender, EventArgs e)
        {
            if (lstCombat.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a monster from the combat list.");
            }
            else
            {

                int indexStart = lstCombat.SelectedItem.ToString().IndexOf("#");
                int indexStop = lstCombat.SelectedItem.ToString().IndexOf(":");


                monsterCombatants.RemoveAll(x => x.ID.ToString() == lstCombat.SelectedItem.ToString().Substring((indexStart + 1), (indexStop - 3)));
                Form form = Application.OpenForms[lstCombat.SelectedItem.ToString().Substring((indexStart + 1), (indexStop - 3))];

                if (form != null)
                {
                    form.Dispose();
                }
                


                RefreshCombatList();



            }

        }

        private void btnClearCombat_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                lstCombat.Items.Clear();
                monsterCombatants.Clear();
                lstCombatantConditions.Items.Clear();
                txtModifyHP.Text = "0";
                combatantID = 0;
            }


            RefreshCombatList();
            List<Form> formList = new List<Form>();

            foreach (Form f in Application.OpenForms)
            {

                formList.Add(f);

            }

            foreach (Form f in formList)
            {
                if (f is CombatStatUI)
                {
                    f.Dispose();
                }


            }


        }

        private void btnModifyCombatant_Click(object sender, EventArgs e)
        {



            if (lstCombat.SelectedIndex == -1)
            {


                MessageBox.Show("You need to select a monster from the combat list.");



            }
            else
            {
                try
                {
                    int HPChange = 0;
                    if (rbtnManual.Checked)
                    {
                        HPChange = int.Parse(txtModifyHP.Text);
                    }
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




                    int indexStart = lstCombat.SelectedItem.ToString().IndexOf("#");
                    int indexStop = lstCombat.SelectedItem.ToString().IndexOf(":");


                    Combatant combatant = monsterCombatants.Single(x => x.ID.ToString() == lstCombat.SelectedItem.ToString().Substring((indexStart + 1), (indexStop - 3)));


                    combatant.HP = combatant.HP + HPChange;

                    Form form = Application.OpenForms[combatant.ID.ToString()];
                    if (form != null)
                    {
                        CombatStatUI statUI = (CombatStatUI)form;
                        if (HPChange < 0)
                        { 
                            
                            statUI.AnimateCombat();
                        }
                        else if (HPChange > 0)
                        {
                            statUI.AnimateHeal();
                        }
                        
                        if (combatant.HP < 1)
                        {
                            statUI.Death();
                        }

                        
                    }


                    RefreshCombatList();
                }
                catch
                {

                    MessageBox.Show("HP-value must be an integer.");


                }




            }

        }

        private void lstDefaultConditions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstDefaultConditions.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a condition.");
            }
            else
            {
                if (lstCombat.SelectedIndex == -1)
                {
                    MessageBox.Show("You need to select a monster from the combat list.");
                }
                else
                {
                    lstCombatantConditions.Items.Add(lstDefaultConditions.SelectedItem);

                    int indexStart = lstCombat.SelectedItem.ToString().IndexOf("#");
                    int indexStop = lstCombat.SelectedItem.ToString().IndexOf(":");


                    Combatant combatant = new Combatant();
                    combatant = monsterCombatants.Single(x => x.ID.ToString() == lstCombat.SelectedItem.ToString().Substring((indexStart + 1), (indexStop - 3)));

                    Condition condition = new Condition();
                    condition = defaultConditions.Single(x => x.name == lstDefaultConditions.SelectedItem.ToString());

                    List<Condition> conditionList;


                    try
                    {
                        conditionList = combatant.conditions;
                        conditionList.Add(condition);

                    }
                    catch
                    {
                        conditionList = new List<Condition>();
                        conditionList.Add(condition);

                    }



                    combatant.conditions = conditionList;
                    RefreshCombatList();

                }



            }
        }

        public void ShowCondition()
        {
            if (lstDefaultConditions.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a condition.");
            }
            else
            {
                Condition condition = defaultConditions.Single(x => x.name == lstDefaultConditions.SelectedItem.ToString());
                string fullConditionDescription = condition.name + @":
";

                foreach (var item in condition.descriptionList)
                {
                    fullConditionDescription += @"
- " + item + @"
";
                }

                MessageBox.Show(fullConditionDescription);

            }
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {

            ShowCondition();
            
        }

        private void lstCombat_Click(object sender, EventArgs e)
        {

            if (lstCombat.SelectedIndex == -1)
            {

            }
            else
            {
                int indexMonsterStart = lstCombat.SelectedItem.ToString().IndexOf(": ");
                int indexMonsterStop = lstCombat.SelectedItem.ToString().IndexOf(", HP");
                string combatMonster = lstCombat.SelectedItem.ToString().Substring((indexMonsterStart + 2), (indexMonsterStop - 6));


                try
                {
                    var monster = monsterList.First(x => x.name == combatMonster);
                    ShowDetails(monster);
                }
                catch
                {

                }



                txtModifyHP.Text = "0";
                lstCombatantConditions.Items.Clear();

                int indexStart = lstCombat.SelectedItem.ToString().IndexOf("#");
                int indexStop = lstCombat.SelectedItem.ToString().IndexOf(":");
                Combatant combatant = monsterCombatants.Single(x => x.ID.ToString() == lstCombat.SelectedItem.ToString().Substring((indexStart + 1), (indexStop - 3)));

                try
                {
                    foreach (var condition in combatant.conditions)
                    {
                        lstCombatantConditions.Items.Add(condition.name);
                    }
                }
                catch
                {

                }

            }


        }

        private void lstCombatantConditions_DoubleClick(object sender, EventArgs e)
        {
            if (lstCombat.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a monster from the combat list.");
            }
            else
            {
                
                    int indexStart = lstCombat.SelectedItem.ToString().IndexOf("#");
                    int indexStop = lstCombat.SelectedItem.ToString().IndexOf(":");
                    Combatant combatant = monsterCombatants.Single(x => x.ID.ToString() == lstCombat.SelectedItem.ToString().Substring((indexStart + 1), (indexStop - 3)));

                    List<Condition> conditionList;


                    try
                    {
                        conditionList = combatant.conditions;
                        conditionList.RemoveAll(x => x.name == lstCombatantConditions.SelectedItem.ToString());
                        lstCombatantConditions.Items.Clear();
                        foreach (var condition in conditionList)
                        {
                            lstCombatantConditions.Items.Add(condition.name);
                        }

                    }
                    catch
                    {
                        conditionList = new List<Condition>();


                    }



                    combatant.conditions = conditionList;

                

                RefreshCombatList();
            }


        }

        private void btnAddMonster_Click(object sender, EventArgs e)
        {
            Monster monster = new Monster();
            try
            {
                monster = monsterList.First(x => x.name == lstMonsterList.SelectedItem.ToString());
            }
            catch
            {

            }






            FileHandler.SaveCombatantListToFile(monsterCombatants);
            FileHandler.SaveMonsterListToFile(monsterList);


            ManualMonster newForm = new ManualMonster(this, monster);
            newForm.Show();

        }

        private void btnQuickAdd_Click(object sender, EventArgs e)
        {

            ManualCombatant newForm = new ManualCombatant(this);
            newForm.Show();
        }



        private void rbtnManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnManual.Checked)
            {
                txtModifyHP.Enabled = true;

            }
            else
            {
                txtModifyHP.Enabled = false;
            }
        }


        private void btnDeleteMonster_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("Remove monster: " + lstMonsterList.SelectedItem.ToString() + " ?", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string name = lstMonsterList.SelectedItem.ToString();

                    Monster monster = monsterList.Find(x => x.name == name);

                    monsterList.Remove(monster);


                    RefreshMonsterList();
                }
            }
            catch
            {
                MessageBox.Show("You need to select a monster from the monster list.");
            }



        }

        private void txtMonsterSearch_Enter(object sender, EventArgs e)
        {
            if (txtMonsterSearch.Font.Italic)
            {
                txtMonsterSearch.ForeColor = Color.Black;
                txtMonsterSearch.Font = new Font(txtMonsterSearch.Font, FontStyle.Regular);
                txtMonsterSearch.Text = "";
            }

        }

        private void txtMonsterSearch_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMonsterSearch.Text))
            {
                txtMonsterSearch.ForeColor = Color.LightGray;
                txtMonsterSearch.Font = new Font(txtMonsterSearch.Font, FontStyle.Italic);
                txtMonsterSearch.Text = "Search...";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMonsterSearch.Text) || txtMonsterSearch.Font.Italic)
            {
                RefreshMonsterList();
            }
            else
            {
                try
                {
                    List<Monster> searchList = monsterList.FindAll(x => x.name.ToLower().Contains(txtMonsterSearch.Text.ToLower()));
                    ShowSearchList(searchList);


                }
                catch
                {
                    lstMonsterList.Items.Clear();
                    lstMonsterList.Items.Add("No monsters found.");
                }
            }


        }

        private void txtMonsterSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
                txtMonsterSearch.Focus();
                txtMonsterSearch.ForeColor = Color.Black;
                txtMonsterSearch.Font = new Font(txtMonsterSearch.Font, FontStyle.Regular);
                txtMonsterSearch.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }


        }

        private void btnTiles_Click(object sender, EventArgs e)
        {
            MapTileUI mapTileUI = new MapTileUI();
            mapTileUI.Show();
        }

        private void lstCombat_DoubleClick(object sender, EventArgs e)
        {
            PopOutCombat();
        }

        private void lstMonsterList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstMonsterList.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a monster from the monster list.");
            }
            else
            {
                Random initd20 = new Random();
                Combatant combatant = new Combatant();
                var monster = monsterList.First(x => x.name == lstMonsterList.SelectedItem.ToString());

                int init = 0;
                try
                {
                    init = (initd20.Next(1, 21) + int.Parse(monster.initiative));
                }
                catch
                {

                }


                string[] hpSplit = monster.HP.Split(new string[] { " " }, StringSplitOptions.None);

                combatant.name = monster.name;
                combatant.initiative = init.ToString();
                combatant.ID = combatantID + 1;
                combatant.HP = 0;
                combatant.AC = monster.AC;
                combatant.save = monster.save;
                try
                {
                    combatant.HP = int.Parse(hpSplit[0]);
                }
                catch
                {

                }

                combatantID++;
                monsterCombatants.Add(combatant);

                RefreshCombatList();


            }
        }
    }
}
