namespace CMP307Project
{
    partial class AddSoftware
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
            this.assetNum = new System.Windows.Forms.NumericUpDown();
            this.autofillBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.assetIDLbl = new System.Windows.Forms.Label();
            this.manufacturerLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.osNameLbl = new System.Windows.Forms.Label();
            this.manuTB = new System.Windows.Forms.TextBox();
            this.versionTB = new System.Windows.Forms.TextBox();
            this.osNameTB = new System.Windows.Forms.TextBox();
            this.addSoftwareLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.assetNum)).BeginInit();
            this.SuspendLayout();
            // 
            // assetNum
            // 
            this.assetNum.Location = new System.Drawing.Point(218, 211);
            this.assetNum.Name = "assetNum";
            this.assetNum.Size = new System.Drawing.Size(120, 20);
            this.assetNum.TabIndex = 40;
            // 
            // autofillBtn
            // 
            this.autofillBtn.Location = new System.Drawing.Point(67, 257);
            this.autofillBtn.Name = "autofillBtn";
            this.autofillBtn.Size = new System.Drawing.Size(75, 43);
            this.autofillBtn.TabIndex = 39;
            this.autofillBtn.Text = "Autofill";
            this.autofillBtn.UseVisualStyleBackColor = true;
            this.autofillBtn.Click += new System.EventHandler(this.autofillBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(255, 257);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 43);
            this.cancelBtn.TabIndex = 38;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(162, 257);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 43);
            this.addBtn.TabIndex = 37;
            this.addBtn.Text = "Add Software";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // assetIDLbl
            // 
            this.assetIDLbl.AutoSize = true;
            this.assetIDLbl.Location = new System.Drawing.Point(64, 213);
            this.assetIDLbl.Name = "assetIDLbl";
            this.assetIDLbl.Size = new System.Drawing.Size(47, 13);
            this.assetIDLbl.TabIndex = 36;
            this.assetIDLbl.Text = "Asset ID";
            // 
            // manufacturerLbl
            // 
            this.manufacturerLbl.AutoSize = true;
            this.manufacturerLbl.Location = new System.Drawing.Point(64, 177);
            this.manufacturerLbl.Name = "manufacturerLbl";
            this.manufacturerLbl.Size = new System.Drawing.Size(74, 13);
            this.manufacturerLbl.TabIndex = 29;
            this.manufacturerLbl.Text = "Manufacturer*";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Location = new System.Drawing.Point(64, 140);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(46, 13);
            this.versionLbl.TabIndex = 28;
            this.versionLbl.Text = "Version*";
            // 
            // osNameLbl
            // 
            this.osNameLbl.AutoSize = true;
            this.osNameLbl.Location = new System.Drawing.Point(64, 103);
            this.osNameLbl.Name = "osNameLbl";
            this.osNameLbl.Size = new System.Drawing.Size(125, 13);
            this.osNameLbl.TabIndex = 27;
            this.osNameLbl.Text = "Operating System Name*";
            // 
            // manuTB
            // 
            this.manuTB.Location = new System.Drawing.Point(218, 174);
            this.manuTB.MaxLength = 255;
            this.manuTB.Name = "manuTB";
            this.manuTB.Size = new System.Drawing.Size(132, 20);
            this.manuTB.TabIndex = 24;
            // 
            // versionTB
            // 
            this.versionTB.Location = new System.Drawing.Point(218, 137);
            this.versionTB.MaxLength = 255;
            this.versionTB.Name = "versionTB";
            this.versionTB.Size = new System.Drawing.Size(132, 20);
            this.versionTB.TabIndex = 23;
            // 
            // osNameTB
            // 
            this.osNameTB.Location = new System.Drawing.Point(218, 100);
            this.osNameTB.MaxLength = 255;
            this.osNameTB.Name = "osNameTB";
            this.osNameTB.Size = new System.Drawing.Size(132, 20);
            this.osNameTB.TabIndex = 22;
            // 
            // addSoftwareLbl
            // 
            this.addSoftwareLbl.AutoSize = true;
            this.addSoftwareLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.addSoftwareLbl.Location = new System.Drawing.Point(103, 27);
            this.addSoftwareLbl.Name = "addSoftwareLbl";
            this.addSoftwareLbl.Size = new System.Drawing.Size(210, 37);
            this.addSoftwareLbl.TabIndex = 21;
            this.addSoftwareLbl.Text = "Add Software";
            // 
            // AddSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 337);
            this.Controls.Add(this.assetNum);
            this.Controls.Add(this.autofillBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.assetIDLbl);
            this.Controls.Add(this.manufacturerLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.osNameLbl);
            this.Controls.Add(this.manuTB);
            this.Controls.Add(this.versionTB);
            this.Controls.Add(this.osNameTB);
            this.Controls.Add(this.addSoftwareLbl);
            this.Name = "AddSoftware";
            this.Text = "AddSoftware";
            ((System.ComponentModel.ISupportInitialize)(this.assetNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown assetNum;
        private System.Windows.Forms.Button autofillBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label assetIDLbl;
        private System.Windows.Forms.Label manufacturerLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label osNameLbl;
        private System.Windows.Forms.TextBox manuTB;
        private System.Windows.Forms.TextBox versionTB;
        private System.Windows.Forms.TextBox osNameTB;
        private System.Windows.Forms.Label addSoftwareLbl;
    }
}