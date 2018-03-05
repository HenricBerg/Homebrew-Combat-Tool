namespace HomebrewCombat
{
    partial class InitCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitCheck));
            this.label1 = new System.Windows.Forms.Label();
            this.lstInclude = new System.Windows.Forms.ListBox();
            this.lstExclude = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Included in initiative-order:";
            // 
            // lstInclude
            // 
            this.lstInclude.FormattingEnabled = true;
            this.lstInclude.Location = new System.Drawing.Point(15, 25);
            this.lstInclude.Name = "lstInclude";
            this.lstInclude.Size = new System.Drawing.Size(321, 290);
            this.lstInclude.TabIndex = 1;
            this.lstInclude.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstInclude_MouseDoubleClick);
            // 
            // lstExclude
            // 
            this.lstExclude.FormattingEnabled = true;
            this.lstExclude.Location = new System.Drawing.Point(395, 25);
            this.lstExclude.Name = "lstExclude";
            this.lstExclude.Size = new System.Drawing.Size(321, 290);
            this.lstExclude.TabIndex = 2;
            this.lstExclude.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstExclude_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Excluded from initiative-order:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "(Double-click to exclude/include)";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Mistral", 15F, System.Drawing.FontStyle.Bold);
            this.btnGo.Location = new System.Drawing.Point(15, 321);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(321, 28);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "INITIATE COMBAT!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // InitCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(728, 354);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstExclude);
            this.Controls.Add(this.lstInclude);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitCheck";
            this.Text = "Initiative Checklist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstInclude;
        private System.Windows.Forms.ListBox lstExclude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
    }
}