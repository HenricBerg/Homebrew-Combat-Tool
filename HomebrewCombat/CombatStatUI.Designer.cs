namespace HomebrewCombat
{
    partial class CombatStatUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombatStatUI));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNameID = new System.Windows.Forms.Label();
            this.lblAC = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.tmrAnimateCombat = new System.Windows.Forms.Timer(this.components);
            this.tmrAnimateHeal = new System.Windows.Forms.Timer(this.components);
            this.pbxExp = new System.Windows.Forms.PictureBox();
            this.rbtnP1 = new System.Windows.Forms.RadioButton();
            this.rbtnP5 = new System.Windows.Forms.RadioButton();
            this.rbtnP10 = new System.Windows.Forms.RadioButton();
            this.rbtnN1 = new System.Windows.Forms.RadioButton();
            this.rbtnN5 = new System.Windows.Forms.RadioButton();
            this.rbtnN10 = new System.Windows.Forms.RadioButton();
            this.btnModifyCombatant = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExp)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "AC:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "HP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Saving Throw Proficiencies:";
            // 
            // lblNameID
            // 
            this.lblNameID.AutoSize = true;
            this.lblNameID.Location = new System.Drawing.Point(61, 9);
            this.lblNameID.Name = "lblNameID";
            this.lblNameID.Size = new System.Drawing.Size(13, 13);
            this.lblNameID.TabIndex = 5;
            this.lblNameID.Text = "0";
            // 
            // lblAC
            // 
            this.lblAC.AutoSize = true;
            this.lblAC.Location = new System.Drawing.Point(45, 38);
            this.lblAC.Name = "lblAC";
            this.lblAC.Size = new System.Drawing.Size(13, 13);
            this.lblAC.TabIndex = 6;
            this.lblAC.Text = "0";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(46, 67);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(13, 13);
            this.lblHP.TabIndex = 7;
            this.lblHP.Text = "0";
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Location = new System.Drawing.Point(12, 109);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(13, 13);
            this.lblSave.TabIndex = 8;
            this.lblSave.Text = "0";
            // 
            // tmrAnimateCombat
            // 
            this.tmrAnimateCombat.Interval = 50;
            this.tmrAnimateCombat.Tick += new System.EventHandler(this.tmrAnimateCombat_Tick);
            // 
            // tmrAnimateHeal
            // 
            this.tmrAnimateHeal.Interval = 50;
            this.tmrAnimateHeal.Tick += new System.EventHandler(this.tmrAnimateHeal_Tick);
            // 
            // pbxExp
            // 
            this.pbxExp.Location = new System.Drawing.Point(183, 22);
            this.pbxExp.Name = "pbxExp";
            this.pbxExp.Size = new System.Drawing.Size(96, 95);
            this.pbxExp.TabIndex = 9;
            this.pbxExp.TabStop = false;
            // 
            // rbtnP1
            // 
            this.rbtnP1.AutoSize = true;
            this.rbtnP1.Location = new System.Drawing.Point(101, 171);
            this.rbtnP1.Name = "rbtnP1";
            this.rbtnP1.Size = new System.Drawing.Size(37, 17);
            this.rbtnP1.TabIndex = 67;
            this.rbtnP1.Text = "+1";
            this.rbtnP1.UseVisualStyleBackColor = true;
            // 
            // rbtnP5
            // 
            this.rbtnP5.AutoSize = true;
            this.rbtnP5.Location = new System.Drawing.Point(61, 171);
            this.rbtnP5.Name = "rbtnP5";
            this.rbtnP5.Size = new System.Drawing.Size(37, 17);
            this.rbtnP5.TabIndex = 66;
            this.rbtnP5.Text = "+5";
            this.rbtnP5.UseVisualStyleBackColor = true;
            // 
            // rbtnP10
            // 
            this.rbtnP10.AutoSize = true;
            this.rbtnP10.Location = new System.Drawing.Point(15, 171);
            this.rbtnP10.Name = "rbtnP10";
            this.rbtnP10.Size = new System.Drawing.Size(43, 17);
            this.rbtnP10.TabIndex = 65;
            this.rbtnP10.Text = "+10";
            this.rbtnP10.UseVisualStyleBackColor = true;
            // 
            // rbtnN1
            // 
            this.rbtnN1.AutoSize = true;
            this.rbtnN1.Location = new System.Drawing.Point(101, 156);
            this.rbtnN1.Name = "rbtnN1";
            this.rbtnN1.Size = new System.Drawing.Size(37, 17);
            this.rbtnN1.TabIndex = 64;
            this.rbtnN1.Text = " -1";
            this.rbtnN1.UseVisualStyleBackColor = true;
            // 
            // rbtnN5
            // 
            this.rbtnN5.AutoSize = true;
            this.rbtnN5.Location = new System.Drawing.Point(61, 156);
            this.rbtnN5.Name = "rbtnN5";
            this.rbtnN5.Size = new System.Drawing.Size(37, 17);
            this.rbtnN5.TabIndex = 63;
            this.rbtnN5.Text = " -5";
            this.rbtnN5.UseVisualStyleBackColor = true;
            // 
            // rbtnN10
            // 
            this.rbtnN10.AutoSize = true;
            this.rbtnN10.Location = new System.Drawing.Point(15, 156);
            this.rbtnN10.Name = "rbtnN10";
            this.rbtnN10.Size = new System.Drawing.Size(43, 17);
            this.rbtnN10.TabIndex = 62;
            this.rbtnN10.Text = " -10";
            this.rbtnN10.UseVisualStyleBackColor = true;
            // 
            // btnModifyCombatant
            // 
            this.btnModifyCombatant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyCombatant.Location = new System.Drawing.Point(144, 156);
            this.btnModifyCombatant.Name = "btnModifyCombatant";
            this.btnModifyCombatant.Size = new System.Drawing.Size(135, 32);
            this.btnModifyCombatant.TabIndex = 68;
            this.btnModifyCombatant.Text = "Apply HP-Change!";
            this.btnModifyCombatant.UseVisualStyleBackColor = true;
            this.btnModifyCombatant.Click += new System.EventHandler(this.btnModifyCombatant_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Add/Reduce HP:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(0, 194);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(283, 21);
            this.richTextBox1.TabIndex = 70;
            this.richTextBox1.Text = "";
            // 
            // CombatStatUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(283, 216);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.rbtnP1);
            this.Controls.Add(this.rbtnP5);
            this.Controls.Add(this.rbtnP10);
            this.Controls.Add(this.rbtnN1);
            this.Controls.Add(this.rbtnN5);
            this.Controls.Add(this.rbtnN10);
            this.Controls.Add(this.btnModifyCombatant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxExp);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.lblAC);
            this.Controls.Add(this.lblNameID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CombatStatUI";
            this.Text = "Combat Stats";
            this.Load += new System.EventHandler(this.CombatStatUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxExp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNameID;
        private System.Windows.Forms.Label lblAC;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.PictureBox pbxExp;
        private System.Windows.Forms.Timer tmrAnimateCombat;
        private System.Windows.Forms.Timer tmrAnimateHeal;
        private System.Windows.Forms.RadioButton rbtnP1;
        private System.Windows.Forms.RadioButton rbtnP5;
        private System.Windows.Forms.RadioButton rbtnP10;
        private System.Windows.Forms.RadioButton rbtnN1;
        private System.Windows.Forms.RadioButton rbtnN5;
        private System.Windows.Forms.RadioButton rbtnN10;
        private System.Windows.Forms.Button btnModifyCombatant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}