namespace HomebrewCombat
{
    partial class ManualCombatant
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualCombatant));
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblInit = new System.Windows.Forms.Label();
            this.txtInit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAC = new System.Windows.Forms.TextBox();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblInit
            // 
            this.lblInit.AutoSize = true;
            this.lblInit.Location = new System.Drawing.Point(9, 48);
            this.lblInit.Name = "lblInit";
            this.lblInit.Size = new System.Drawing.Size(112, 13);
            this.lblInit.TabIndex = 2;
            this.lblInit.Text = "Initiative (not modifier):";
            // 
            // txtInit
            // 
            this.txtInit.Location = new System.Drawing.Point(12, 64);
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(131, 20);
            this.txtInit.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 100);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(118, 13);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "Something went wrong.";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 283);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add!";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(83, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtHP
            // 
            this.txtHP.Location = new System.Drawing.Point(12, 218);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(131, 20);
            this.txtHP.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "HP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "AC:";
            // 
            // txtAC
            // 
            this.txtAC.Location = new System.Drawing.Point(12, 179);
            this.txtAC.Name = "txtAC";
            this.txtAC.Size = new System.Drawing.Size(131, 20);
            this.txtAC.TabIndex = 7;
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(12, 257);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(131, 20);
            this.txtSave.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Saving Throw Proficiencies:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "(Optional Info)";
            // 
            // ManualCombatant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(158, 318);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAC);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInit);
            this.Controls.Add(this.lblInit);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManualCombatant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick-Combatant";
            this.Load += new System.EventHandler(this.ManualCombatant_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblInit;
        private System.Windows.Forms.TextBox txtInit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAC;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}