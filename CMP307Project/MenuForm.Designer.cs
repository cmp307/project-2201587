namespace CMP307Project
{
    partial class MenuForm
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
            this.assetsBtn = new System.Windows.Forms.Button();
            this.employeesBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.profileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // assetsBtn
            // 
            this.assetsBtn.Location = new System.Drawing.Point(138, 136);
            this.assetsBtn.Name = "assetsBtn";
            this.assetsBtn.Size = new System.Drawing.Size(75, 23);
            this.assetsBtn.TabIndex = 0;
            this.assetsBtn.Text = "Assets";
            this.assetsBtn.UseVisualStyleBackColor = true;
            this.assetsBtn.Click += new System.EventHandler(this.assetsBtn_Click);
            // 
            // employeesBtn
            // 
            this.employeesBtn.Location = new System.Drawing.Point(300, 136);
            this.employeesBtn.Name = "employeesBtn";
            this.employeesBtn.Size = new System.Drawing.Size(75, 23);
            this.employeesBtn.TabIndex = 1;
            this.employeesBtn.Text = "Employees";
            this.employeesBtn.UseVisualStyleBackColor = true;
            this.employeesBtn.Click += new System.EventHandler(this.employeesBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(219, 215);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // profileBtn
            // 
            this.profileBtn.Location = new System.Drawing.Point(219, 136);
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Size = new System.Drawing.Size(75, 23);
            this.profileBtn.TabIndex = 4;
            this.profileBtn.Text = "Profile";
            this.profileBtn.UseVisualStyleBackColor = true;
            this.profileBtn.Click += new System.EventHandler(this.profileBtn_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 346);
            this.Controls.Add(this.profileBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.employeesBtn);
            this.Controls.Add(this.assetsBtn);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button assetsBtn;
        private System.Windows.Forms.Button employeesBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button profileBtn;
    }
}