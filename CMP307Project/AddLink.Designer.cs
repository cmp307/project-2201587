namespace CMP307Project
{
    partial class AddLink
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
            this.assetIdLbl = new System.Windows.Forms.Label();
            this.addLinkLbl = new System.Windows.Forms.Label();
            this.softwareLbl = new System.Windows.Forms.Label();
            this.activeCB = new System.Windows.Forms.CheckBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.assetNum)).BeginInit();
            this.SuspendLayout();
            // 
            // assetNum
            // 
            this.assetNum.Location = new System.Drawing.Point(204, 129);
            this.assetNum.Name = "assetNum";
            this.assetNum.Size = new System.Drawing.Size(120, 20);
            this.assetNum.TabIndex = 42;
            // 
            // assetIdLbl
            // 
            this.assetIdLbl.AutoSize = true;
            this.assetIdLbl.Location = new System.Drawing.Point(50, 131);
            this.assetIdLbl.Name = "assetIdLbl";
            this.assetIdLbl.Size = new System.Drawing.Size(47, 13);
            this.assetIdLbl.TabIndex = 41;
            this.assetIdLbl.Text = "Asset ID";
            // 
            // addLinkLbl
            // 
            this.addLinkLbl.AutoSize = true;
            this.addLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.addLinkLbl.Location = new System.Drawing.Point(92, 35);
            this.addLinkLbl.Name = "addLinkLbl";
            this.addLinkLbl.Size = new System.Drawing.Size(143, 37);
            this.addLinkLbl.TabIndex = 43;
            this.addLinkLbl.Text = "Add Link";
            // 
            // softwareLbl
            // 
            this.softwareLbl.AutoSize = true;
            this.softwareLbl.Location = new System.Drawing.Point(113, 86);
            this.softwareLbl.Name = "softwareLbl";
            this.softwareLbl.Size = new System.Drawing.Size(93, 13);
            this.softwareLbl.TabIndex = 44;
            this.softwareLbl.Text = "Link for Software: ";
            // 
            // activeCB
            // 
            this.activeCB.AutoSize = true;
            this.activeCB.Location = new System.Drawing.Point(126, 170);
            this.activeCB.Name = "activeCB";
            this.activeCB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.activeCB.Size = new System.Drawing.Size(62, 17);
            this.activeCB.TabIndex = 45;
            this.activeCB.Text = "?Active";
            this.activeCB.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(76, 222);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 46;
            this.addBtn.Text = "Add Link";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(186, 222);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 47;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // AddLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 300);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.activeCB);
            this.Controls.Add(this.softwareLbl);
            this.Controls.Add(this.addLinkLbl);
            this.Controls.Add(this.assetNum);
            this.Controls.Add(this.assetIdLbl);
            this.Name = "AddLink";
            this.Text = "AddLink";
            ((System.ComponentModel.ISupportInitialize)(this.assetNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown assetNum;
        private System.Windows.Forms.Label assetIdLbl;
        private System.Windows.Forms.Label addLinkLbl;
        private System.Windows.Forms.Label softwareLbl;
        private System.Windows.Forms.CheckBox activeCB;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}