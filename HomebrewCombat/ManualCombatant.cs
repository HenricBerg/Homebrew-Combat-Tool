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
    public partial class ManualCombatant : Form
    {
        MainWindow mainWindow;
        public ManualCombatant(MainWindow mainWindow)
        {
            InitializeComponent();
            mainWindow.Hide();
            this.mainWindow = mainWindow;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ManualCombatant_Load(object sender, EventArgs e)
        {
            try
            {
                lblID.Text = (MainWindow.combatantID + 1).ToString();
                
            }
            catch
            {

            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string AC = "";
            int HP = 0;
            string saves = "";
            try
            {
                Validator.CheckIfEmptyString(txtName.Text);
                Validator.CheckIfEmptyString(txtInit.Text);
                Validator.CheckSoStringIsNumber(txtInit.Text);
                if (!String.IsNullOrEmpty(txtHP.Text))
                {
                    Validator.CheckSoStringIsNumber(txtHP.Text);
                    HP = int.Parse(txtHP.Text);
                }
                
                AC = txtAC.Text;
                
                saves = txtSave.Text;


                Program.mainForm.manualAddCombatant(txtName.Text, txtInit.Text, AC, HP, saves);
                mainWindow.Show();
                Dispose();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);

            }
            


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainWindow.Show();
            Close();
        }
    }
}
