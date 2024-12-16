namespace CMP307Project
{
    partial class EditLink
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.activeCB = new System.Windows.Forms.CheckBox();
            this.softwareLbl = new System.Windows.Forms.Label();
            this.editLinkLbl = new System.Windows.Forms.Label();
            this.assetLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(197, 212);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 54;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(87, 212);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 53;
            this.editBtn.Text = "Edit Link";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // activeCB
            // 
            this.activeCB.AutoSize = true;
            this.activeCB.Location = new System.Drawing.Point(127, 146);
            this.activeCB.Name = "activeCB";
            this.activeCB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.activeCB.Size = new System.Drawing.Size(62, 17);
            this.activeCB.TabIndex = 52;
            this.activeCB.Text = "?Active";
            this.activeCB.UseVisualStyleBackColor = true;
            // 
            // softwareLbl
            // 
            this.softwareLbl.AutoSize = true;
            this.softwareLbl.Location = new System.Drawing.Point(124, 76);
            this.softwareLbl.Name = "softwareLbl";
            this.softwareLbl.Size = new System.Drawing.Size(93, 13);
            this.softwareLbl.TabIndex = 51;
            this.softwareLbl.Text = "Link for Software: ";
            // 
            // editLinkLbl
            // 
            this.editLinkLbl.AutoSize = true;
            this.editLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.editLinkLbl.Location = new System.Drawing.Point(103, 25);
            this.editLinkLbl.Name = "editLinkLbl";
            this.editLinkLbl.Size = new System.Drawing.Size(140, 37);
            this.editLinkLbl.TabIndex = 50;
            this.editLinkLbl.Text = "Edit Link";
            // 
            // assetLbl
            // 
            this.assetLbl.AutoSize = true;
            this.assetLbl.Location = new System.Drawing.Point(124, 108);
            this.assetLbl.Name = "assetLbl";
            this.assetLbl.Size = new System.Drawing.Size(56, 13);
            this.assetLbl.TabIndex = 55;
            this.assetLbl.Text = "On Asset: ";
            // 
            // EditLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 396);
            this.Controls.Add(this.assetLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.activeCB);
            this.Controls.Add(this.softwareLbl);
            this.Controls.Add(this.editLinkLbl);
            this.Name = "EditLink";
            this.Text = "EditLink";
            this.Load += new System.EventHandler(this.EditLink_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.CheckBox activeCB;
        private System.Windows.Forms.Label softwareLbl;
        private System.Windows.Forms.Label editLinkLbl;
        private System.Windows.Forms.Label assetLbl;
    }
}