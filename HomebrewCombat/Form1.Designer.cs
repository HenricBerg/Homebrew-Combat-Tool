namespace HomebrewCombat
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnDownload = new System.Windows.Forms.Button();
            this.lstMonsterList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtboxDetails = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCombat = new System.Windows.Forms.ListBox();
            this.btnAddToCombat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRemoveFromCombat = new System.Windows.Forms.Button();
            this.btnClearCombat = new System.Windows.Forms.Button();
            this.txtModifyHP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModifyCombatant = new System.Windows.Forms.Button();
            this.lstCombatantConditions = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDefaultConditions = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddMonster = new System.Windows.Forms.Button();
            this.btnQuickAdd = new System.Windows.Forms.Button();
            this.rbtnN10 = new System.Windows.Forms.RadioButton();
            this.rbtnN5 = new System.Windows.Forms.RadioButton();
            this.rbtnN1 = new System.Windows.Forms.RadioButton();
            this.rbtnP10 = new System.Windows.Forms.RadioButton();
            this.rbtnP5 = new System.Windows.Forms.RadioButton();
            this.rbtnP1 = new System.Windows.Forms.RadioButton();
            this.rbtnManual = new System.Windows.Forms.RadioButton();
            this.btnDeleteMonster = new System.Windows.Forms.Button();
            this.txtMonsterSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnTiles = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMerge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(250, 503);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(169, 23);
            this.btnDownload.TabIndex = 21;
            this.btnDownload.Text = "Download Monster Database";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstMonsterList
            // 
            this.lstMonsterList.FormattingEnabled = true;
            this.lstMonsterList.HorizontalScrollbar = true;
            this.lstMonsterList.Location = new System.Drawing.Point(12, 25);
            this.lstMonsterList.Name = "lstMonsterList";
            this.lstMonsterList.Size = new System.Drawing.Size(232, 446);
            this.lstMonsterList.TabIndex = 1;
            this.lstMonsterList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstMonsterList_MouseClick);
            this.lstMonsterList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMonsterList_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "List of monsters:";
            // 
            // rtboxDetails
            // 
            this.rtboxDetails.Location = new System.Drawing.Point(250, 25);
            this.rtboxDetails.Name = "rtboxDetails";
            this.rtboxDetails.Size = new System.Drawing.Size(336, 472);
            this.rtboxDetails.TabIndex = 2;
            this.rtboxDetails.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Detailed Description of Selected Monster:";
            // 
            // lstCombat
            // 
            this.lstCombat.BackColor = System.Drawing.SystemColors.Window;
            this.lstCombat.FormattingEnabled = true;
            this.lstCombat.HorizontalScrollbar = true;
            this.lstCombat.Location = new System.Drawing.Point(592, 25);
            this.lstCombat.Name = "lstCombat";
            this.lstCombat.Size = new System.Drawing.Size(321, 147);
            this.lstCombat.TabIndex = 3;
            this.lstCombat.Click += new System.EventHandler(this.lstCombat_Click);
            this.lstCombat.DoubleClick += new System.EventHandler(this.lstCombat_DoubleClick);
            // 
            // btnAddToCombat
            // 
            this.btnAddToCombat.Location = new System.Drawing.Point(592, 178);
            this.btnAddToCombat.Name = "btnAddToCombat";
            this.btnAddToCombat.Size = new System.Drawing.Size(160, 23);
            this.btnAddToCombat.TabIndex = 4;
            this.btnAddToCombat.Text = "Add To Combat";
            this.btnAddToCombat.UseVisualStyleBackColor = true;
            this.btnAddToCombat.Click += new System.EventHandler(this.btnAddToCombat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(589, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Combat List:";
            // 
            // btnRemoveFromCombat
            // 
            this.btnRemoveFromCombat.Location = new System.Drawing.Point(753, 178);
            this.btnRemoveFromCombat.Name = "btnRemoveFromCombat";
            this.btnRemoveFromCombat.Size = new System.Drawing.Size(160, 23);
            this.btnRemoveFromCombat.TabIndex = 5;
            this.btnRemoveFromCombat.Text = "Remove From Combat";
            this.btnRemoveFromCombat.UseVisualStyleBackColor = true;
            this.btnRemoveFromCombat.Click += new System.EventHandler(this.btnRemoveFromCombat_Click);
            // 
            // btnClearCombat
            // 
            this.btnClearCombat.Location = new System.Drawing.Point(753, 207);
            this.btnClearCombat.Name = "btnClearCombat";
            this.btnClearCombat.Size = new System.Drawing.Size(160, 23);
            this.btnClearCombat.TabIndex = 7;
            this.btnClearCombat.Text = "Clear Combat List";
            this.btnClearCombat.UseVisualStyleBackColor = true;
            this.btnClearCombat.Click += new System.EventHandler(this.btnClearCombat_Click);
            // 
            // txtModifyHP
            // 
            this.txtModifyHP.Location = new System.Drawing.Point(612, 257);
            this.txtModifyHP.Name = "txtModifyHP";
            this.txtModifyHP.Size = new System.Drawing.Size(100, 20);
            this.txtModifyHP.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(589, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Add/Reduce HP:";
            // 
            // btnModifyCombatant
            // 
            this.btnModifyCombatant.Location = new System.Drawing.Point(592, 321);
            this.btnModifyCombatant.Name = "btnModifyCombatant";
            this.btnModifyCombatant.Size = new System.Drawing.Size(120, 23);
            this.btnModifyCombatant.TabIndex = 15;
            this.btnModifyCombatant.Text = "Apply HP-Change!";
            this.btnModifyCombatant.UseVisualStyleBackColor = true;
            this.btnModifyCombatant.Click += new System.EventHandler(this.btnModifyCombatant_Click);
            // 
            // lstCombatantConditions
            // 
            this.lstCombatantConditions.FormattingEnabled = true;
            this.lstCombatantConditions.HorizontalScrollbar = true;
            this.lstCombatantConditions.Location = new System.Drawing.Point(592, 386);
            this.lstCombatantConditions.Name = "lstCombatantConditions";
            this.lstCombatantConditions.Size = new System.Drawing.Size(120, 82);
            this.lstCombatantConditions.TabIndex = 16;
            this.lstCombatantConditions.DoubleClick += new System.EventHandler(this.lstCombatantConditions_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(589, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Combatant\'s Conditions:";
            // 
            // lstDefaultConditions
            // 
            this.lstDefaultConditions.FormattingEnabled = true;
            this.lstDefaultConditions.HorizontalScrollbar = true;
            this.lstDefaultConditions.Location = new System.Drawing.Point(744, 269);
            this.lstDefaultConditions.Name = "lstDefaultConditions";
            this.lstDefaultConditions.Size = new System.Drawing.Size(169, 199);
            this.lstDefaultConditions.TabIndex = 17;
            this.lstDefaultConditions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstDefaultConditions_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(741, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Conditions:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(741, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "(Double-click to add)";
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Location = new System.Drawing.Point(744, 474);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(169, 23);
            this.btnAddCondition.TabIndex = 18;
            this.btnAddCondition.Text = "Show Condition Description";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(589, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "(Double-click to remove)";
            // 
            // btnAddMonster
            // 
            this.btnAddMonster.Location = new System.Drawing.Point(12, 503);
            this.btnAddMonster.Name = "btnAddMonster";
            this.btnAddMonster.Size = new System.Drawing.Size(127, 23);
            this.btnAddMonster.TabIndex = 20;
            this.btnAddMonster.Text = "Add/Edit Monster";
            this.btnAddMonster.UseVisualStyleBackColor = true;
            this.btnAddMonster.Click += new System.EventHandler(this.btnAddMonster_Click);
            // 
            // btnQuickAdd
            // 
            this.btnQuickAdd.Location = new System.Drawing.Point(592, 207);
            this.btnQuickAdd.Name = "btnQuickAdd";
            this.btnQuickAdd.Size = new System.Drawing.Size(160, 23);
            this.btnQuickAdd.TabIndex = 6;
            this.btnQuickAdd.Text = "Manually Add Combatant";
            this.btnQuickAdd.UseVisualStyleBackColor = true;
            this.btnQuickAdd.Click += new System.EventHandler(this.btnQuickAdd_Click);
            // 
            // rbtnN10
            // 
            this.rbtnN10.AutoSize = true;
            this.rbtnN10.Location = new System.Drawing.Point(592, 283);
            this.rbtnN10.Name = "rbtnN10";
            this.rbtnN10.Size = new System.Drawing.Size(43, 17);
            this.rbtnN10.TabIndex = 9;
            this.rbtnN10.Text = " -10";
            this.rbtnN10.UseVisualStyleBackColor = true;
            // 
            // rbtnN5
            // 
            this.rbtnN5.AutoSize = true;
            this.rbtnN5.Location = new System.Drawing.Point(638, 283);
            this.rbtnN5.Name = "rbtnN5";
            this.rbtnN5.Size = new System.Drawing.Size(37, 17);
            this.rbtnN5.TabIndex = 10;
            this.rbtnN5.Text = " -5";
            this.rbtnN5.UseVisualStyleBackColor = true;
            // 
            // rbtnN1
            // 
            this.rbtnN1.AutoSize = true;
            this.rbtnN1.Location = new System.Drawing.Point(678, 283);
            this.rbtnN1.Name = "rbtnN1";
            this.rbtnN1.Size = new System.Drawing.Size(37, 17);
            this.rbtnN1.TabIndex = 11;
            this.rbtnN1.Text = " -1";
            this.rbtnN1.UseVisualStyleBackColor = true;
            // 
            // rbtnP10
            // 
            this.rbtnP10.AutoSize = true;
            this.rbtnP10.Location = new System.Drawing.Point(592, 298);
            this.rbtnP10.Name = "rbtnP10";
            this.rbtnP10.Size = new System.Drawing.Size(43, 17);
            this.rbtnP10.TabIndex = 12;
            this.rbtnP10.Text = "+10";
            this.rbtnP10.UseVisualStyleBackColor = true;
            // 
            // rbtnP5
            // 
            this.rbtnP5.AutoSize = true;
            this.rbtnP5.Location = new System.Drawing.Point(638, 298);
            this.rbtnP5.Name = "rbtnP5";
            this.rbtnP5.Size = new System.Drawing.Size(37, 17);
            this.rbtnP5.TabIndex = 13;
            this.rbtnP5.Text = "+5";
            this.rbtnP5.UseVisualStyleBackColor = true;
            // 
            // rbtnP1
            // 
            this.rbtnP1.AutoSize = true;
            this.rbtnP1.Location = new System.Drawing.Point(678, 298);
            this.rbtnP1.Name = "rbtnP1";
            this.rbtnP1.Size = new System.Drawing.Size(37, 17);
            this.rbtnP1.TabIndex = 14;
            this.rbtnP1.Text = "+1";
            this.rbtnP1.UseVisualStyleBackColor = true;
            // 
            // rbtnManual
            // 
            this.rbtnManual.AutoSize = true;
            this.rbtnManual.Checked = true;
            this.rbtnManual.Location = new System.Drawing.Point(592, 260);
            this.rbtnManual.Name = "rbtnManual";
            this.rbtnManual.Size = new System.Drawing.Size(14, 13);
            this.rbtnManual.TabIndex = 60;
            this.rbtnManual.TabStop = true;
            this.rbtnManual.UseVisualStyleBackColor = true;
            this.rbtnManual.CheckedChanged += new System.EventHandler(this.rbtnManual_CheckedChanged);
            // 
            // btnDeleteMonster
            // 
            this.btnDeleteMonster.Location = new System.Drawing.Point(145, 503);
            this.btnDeleteMonster.Name = "btnDeleteMonster";
            this.btnDeleteMonster.Size = new System.Drawing.Size(99, 23);
            this.btnDeleteMonster.TabIndex = 63;
            this.btnDeleteMonster.Text = "Delete Monster";
            this.btnDeleteMonster.UseVisualStyleBackColor = true;
            this.btnDeleteMonster.Click += new System.EventHandler(this.btnDeleteMonster_Click);
            // 
            // txtMonsterSearch
            // 
            this.txtMonsterSearch.ForeColor = System.Drawing.Color.Black;
            this.txtMonsterSearch.Location = new System.Drawing.Point(12, 477);
            this.txtMonsterSearch.Name = "txtMonsterSearch";
            this.txtMonsterSearch.Size = new System.Drawing.Size(177, 20);
            this.txtMonsterSearch.TabIndex = 64;
            this.txtMonsterSearch.Enter += new System.EventHandler(this.txtMonsterSearch_Enter);
            this.txtMonsterSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMonsterSearch_KeyDown);
            this.txtMonsterSearch.Leave += new System.EventHandler(this.txtMonsterSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(195, 477);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 20);
            this.btnSearch.TabIndex = 65;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnTiles
            // 
            this.btnTiles.Location = new System.Drawing.Point(425, 503);
            this.btnTiles.Name = "btnTiles";
            this.btnTiles.Size = new System.Drawing.Size(161, 23);
            this.btnTiles.TabIndex = 66;
            this.btnTiles.Text = "Dungeon Tiles";
            this.btnTiles.UseVisualStyleBackColor = true;
            this.btnTiles.Click += new System.EventHandler(this.btnTiles_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(763, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "(Double-click for combat-stats)";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(592, 503);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(120, 23);
            this.btnMerge.TabIndex = 68;
            this.btnMerge.Text = "Merge Local XML";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(925, 532);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTiles);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtMonsterSearch);
            this.Controls.Add(this.btnDeleteMonster);
            this.Controls.Add(this.rbtnManual);
            this.Controls.Add(this.rbtnP1);
            this.Controls.Add(this.rbtnP5);
            this.Controls.Add(this.rbtnP10);
            this.Controls.Add(this.rbtnN1);
            this.Controls.Add(this.rbtnN5);
            this.Controls.Add(this.rbtnN10);
            this.Controls.Add(this.btnQuickAdd);
            this.Controls.Add(this.btnAddMonster);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAddCondition);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstDefaultConditions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstCombatantConditions);
            this.Controls.Add(this.btnModifyCombatant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtModifyHP);
            this.Controls.Add(this.btnClearCombat);
            this.Controls.Add(this.btnRemoveFromCombat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAddToCombat);
            this.Controls.Add(this.lstCombat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtboxDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMonsterList);
            this.Controls.Add(this.btnDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Henric\'s D&D 5th Edition GM-Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ListBox lstMonsterList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtboxDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstCombat;
        private System.Windows.Forms.Button btnAddToCombat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRemoveFromCombat;
        private System.Windows.Forms.Button btnClearCombat;
        private System.Windows.Forms.TextBox txtModifyHP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModifyCombatant;
        private System.Windows.Forms.ListBox lstCombatantConditions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstDefaultConditions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddMonster;
        private System.Windows.Forms.Button btnQuickAdd;
        private System.Windows.Forms.RadioButton rbtnN10;
        private System.Windows.Forms.RadioButton rbtnN5;
        private System.Windows.Forms.RadioButton rbtnN1;
        private System.Windows.Forms.RadioButton rbtnP10;
        private System.Windows.Forms.RadioButton rbtnP5;
        private System.Windows.Forms.RadioButton rbtnP1;
        private System.Windows.Forms.RadioButton rbtnManual;
        private System.Windows.Forms.Button btnDeleteMonster;
        private System.Windows.Forms.TextBox txtMonsterSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnTiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMerge;
    }
}

