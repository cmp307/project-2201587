namespace CMP307Project
{
    partial class EditSoftware
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.assetIDLbl = new System.Windows.Forms.Label();
            this.manufacturerLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.osNameLbl = new System.Windows.Forms.Label();
            this.manuTB = new System.Windows.Forms.TextBox();
            this.versionTB = new System.Windows.Forms.TextBox();
            this.osNameTB = new System.Windows.Forms.TextBox();
            this.editSoftwareLbl = new System.Windows.Forms.Label();
            this.activeCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.assetNum)).BeginInit();
            this.SuspendLayout();
            // 
            // assetNum
            // 
            this.assetNum.Location = new System.Drawing.Point(213, 216);
            this.assetNum.Name = "assetNum";
            this.assetNum.Size = new System.Drawing.Size(120, 20);
            this.assetNum.TabIndex = 52;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(250, 300);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 43);
            this.cancelBtn.TabIndex = 50;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(157, 300);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 43);
            this.editBtn.TabIndex = 49;
            this.editBtn.Text = "Edit Software";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // assetIDLbl
            // 
            this.assetIDLbl.AutoSize = true;
            this.assetIDLbl.Location = new System.Drawing.Point(59, 218);
            this.assetIDLbl.Name = "assetIDLbl";
            this.assetIDLbl.Size = new System.Drawing.Size(47, 13);
            this.assetIDLbl.TabIndex = 48;
            this.assetIDLbl.Text = "Asset ID";
            // 
            // manufacturerLbl
            // 
            this.manufacturerLbl.AutoSize = true;
            this.manufacturerLbl.Location = new System.Drawing.Point(59, 182);
            this.manufacturerLbl.Name = "manufacturerLbl";
            this.manufacturerLbl.Size = new System.Drawing.Size(74, 13);
            this.manufacturerLbl.TabIndex = 47;
            this.manufacturerLbl.Text = "Manufacturer*";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Location = new System.Drawing.Point(59, 145);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(46, 13);
            this.versionLbl.TabIndex = 46;
            this.versionLbl.Text = "Version*";
            // 
            // osNameLbl
            // 
            this.osNameLbl.AutoSize = true;
            this.osNameLbl.Location = new System.Drawing.Point(59, 108);
            this.osNameLbl.Name = "osNameLbl";
            this.osNameLbl.Size = new System.Drawing.Size(125, 13);
            this.osNameLbl.TabIndex = 45;
            this.osNameLbl.Text = "Operating System Name*";
            // 
            // manuTB
            // 
            this.manuTB.Location = new System.Drawing.Point(213, 179);
            this.manuTB.MaxLength = 255;
            this.manuTB.Name = "manuTB";
            this.manuTB.Size = new System.Drawing.Size(132, 20);
            this.manuTB.TabIndex = 44;
            // 
            // versionTB
            // 
            this.versionTB.Location = new System.Drawing.Point(213, 142);
            this.versionTB.MaxLength = 255;
            this.versionTB.Name = "versionTB";
            this.versionTB.Size = new System.Drawing.Size(132, 20);
            this.versionTB.TabIndex = 43;
            // 
            // osNameTB
            // 
            this.osNameTB.Location = new System.Drawing.Point(213, 105);
            this.osNameTB.MaxLength = 255;
            this.osNameTB.Name = "osNameTB";
            this.osNameTB.Size = new System.Drawing.Size(132, 20);
            this.osNameTB.TabIndex = 42;
            // 
            // editSoftwareLbl
            // 
            this.editSoftwareLbl.AutoSize = true;
            this.editSoftwareLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.editSoftwareLbl.Location = new System.Drawing.Point(98, 32);
            this.editSoftwareLbl.Name = "editSoftwareLbl";
            this.editSoftwareLbl.Size = new System.Drawing.Size(207, 37);
            this.editSoftwareLbl.TabIndex = 41;
            this.editSoftwareLbl.Text = "Edit Software";
            // 
            // activeCB
            // 
            this.activeCB.AutoSize = true;
            this.activeCB.Location = new System.Drawing.Point(135, 257);
            this.activeCB.Name = "activeCB";
            this.activeCB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.activeCB.Size = new System.Drawing.Size(62, 17);
            this.activeCB.TabIndex = 53;
            this.activeCB.Text = "?Active";
            this.activeCB.UseVisualStyleBackColor = true;
            // 
            // EditSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 372);
            this.Controls.Add(this.activeCB);
            this.Controls.Add(this.assetNum);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.assetIDLbl);
            this.Controls.Add(this.manufacturerLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.osNameLbl);
            this.Controls.Add(this.manuTB);
            this.Controls.Add(this.versionTB);
            this.Controls.Add(this.osNameTB);
            this.Controls.Add(this.editSoftwareLbl);
            this.Name = "EditSoftware";
            this.Text = "EditSoftware";
            this.Load += new System.EventHandler(this.EditSoftware_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assetNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown assetNum;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label assetIDLbl;
        private System.Windows.Forms.Label manufacturerLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label osNameLbl;
        private System.Windows.Forms.TextBox manuTB;
        private System.Windows.Forms.TextBox versionTB;
        private System.Windows.Forms.TextBox osNameTB;
        private System.Windows.Forms.Label editSoftwareLbl;
        private System.Windows.Forms.CheckBox activeCB;
    }
}