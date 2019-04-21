namespace HomebrewCombat
{
    partial class SpellTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpellTool));
            this.lstSpells = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSpellSearch = new System.Windows.Forms.TextBox();
            this.tbxSpellDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDBMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSpells
            // 
            this.lstSpells.FormattingEnabled = true;
            this.lstSpells.Location = new System.Drawing.Point(12, 25);
            this.lstSpells.Name = "lstSpells";
            this.lstSpells.Size = new System.Drawing.Size(235, 355);
            this.lstSpells.TabIndex = 0;
            this.lstSpells.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstSpells_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spells:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(198, 386);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 20);
            this.btnSearch.TabIndex = 67;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSpellSearch
            // 
            this.txtSpellSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSpellSearch.Location = new System.Drawing.Point(12, 386);
            this.txtSpellSearch.Name = "txtSpellSearch";
            this.txtSpellSearch.Size = new System.Drawing.Size(180, 20);
            this.txtSpellSearch.TabIndex = 66;
            this.txtSpellSearch.Enter += new System.EventHandler(this.txtSpellSearch_Enter);
            this.txtSpellSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSpellSearch_KeyDown);
            this.txtSpellSearch.Leave += new System.EventHandler(this.txtSpellSearch_Leave);
            // 
            // tbxSpellDescription
            // 
            this.tbxSpellDescription.Location = new System.Drawing.Point(253, 25);
            this.tbxSpellDescription.Name = "tbxSpellDescription";
            this.tbxSpellDescription.Size = new System.Drawing.Size(287, 355);
            this.tbxSpellDescription.TabIndex = 68;
            this.tbxSpellDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Description:";
            // 
            // btnDBMenu
            // 
            this.btnDBMenu.Location = new System.Drawing.Point(253, 386);
            this.btnDBMenu.Name = "btnDBMenu";
            this.btnDBMenu.Size = new System.Drawing.Size(287, 20);
            this.btnDBMenu.TabIndex = 70;
            this.btnDBMenu.Text = "Database Functions";
            this.btnDBMenu.UseVisualStyleBackColor = true;
            this.btnDBMenu.Click += new System.EventHandler(this.btnDBMenu_Click);
            // 
            // SpellTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(552, 411);
            this.Controls.Add(this.btnDBMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxSpellDescription);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSpellSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSpells);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SpellTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spell Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSpells;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSpellSearch;
        private System.Windows.Forms.RichTextBox tbxSpellDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDBMenu;
    }
}