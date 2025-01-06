namespace CMP307Project
{
    partial class EditEmployee
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
            this.departmentNum = new System.Windows.Forms.NumericUpDown();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.departmentIDLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.lastNameTB = new System.Windows.Forms.TextBox();
            this.firstNameTB = new System.Windows.Forms.TextBox();
            this.editEmployeeLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.departmentNum)).BeginInit();
            this.SuspendLayout();
            // 
            // departmentNum
            // 
            this.departmentNum.Location = new System.Drawing.Point(218, 246);
            this.departmentNum.Name = "departmentNum";
            this.departmentNum.Size = new System.Drawing.Size(132, 20);
            this.departmentNum.TabIndex = 53;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(246, 299);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 40);
            this.cancelBtn.TabIndex = 52;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(104, 299);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 40);
            this.updateBtn.TabIndex = 51;
            this.updateBtn.Text = "Update Employee";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // departmentIDLbl
            // 
            this.departmentIDLbl.AutoSize = true;
            this.departmentIDLbl.Location = new System.Drawing.Point(64, 248);
            this.departmentIDLbl.Name = "departmentIDLbl";
            this.departmentIDLbl.Size = new System.Drawing.Size(80, 13);
            this.departmentIDLbl.TabIndex = 50;
            this.departmentIDLbl.Text = "Department ID*";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(64, 209);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(57, 13);
            this.passwordLbl.TabIndex = 49;
            this.passwordLbl.Text = "Password*";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(64, 173);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(36, 13);
            this.emailLbl.TabIndex = 48;
            this.emailLbl.Text = "Email*";
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Location = new System.Drawing.Point(64, 136);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(62, 13);
            this.lastNameLbl.TabIndex = 47;
            this.lastNameLbl.Text = "Last Name*";
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.Location = new System.Drawing.Point(64, 99);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(61, 13);
            this.firstNameLbl.TabIndex = 46;
            this.firstNameLbl.Text = "First Name*";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(218, 206);
            this.passwordTB.MaxLength = 100;
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(132, 20);
            this.passwordTB.TabIndex = 45;
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(218, 170);
            this.emailTB.MaxLength = 255;
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(132, 20);
            this.emailTB.TabIndex = 44;
            // 
            // lastNameTB
            // 
            this.lastNameTB.Location = new System.Drawing.Point(218, 133);
            this.lastNameTB.MaxLength = 255;
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Size = new System.Drawing.Size(132, 20);
            this.lastNameTB.TabIndex = 43;
            // 
            // firstNameTB
            // 
            this.firstNameTB.Location = new System.Drawing.Point(218, 96);
            this.firstNameTB.MaxLength = 255;
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Size = new System.Drawing.Size(132, 20);
            this.firstNameTB.TabIndex = 42;
            // 
            // editEmployeeLbl
            // 
            this.editEmployeeLbl.AutoSize = true;
            this.editEmployeeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.editEmployeeLbl.Location = new System.Drawing.Point(97, 23);
            this.editEmployeeLbl.Name = "editEmployeeLbl";
            this.editEmployeeLbl.Size = new System.Drawing.Size(221, 37);
            this.editEmployeeLbl.TabIndex = 41;
            this.editEmployeeLbl.Text = "Edit Employee";
            // 
            // EditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 363);
            this.Controls.Add(this.departmentNum);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.departmentIDLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.lastNameLbl);
            this.Controls.Add(this.firstNameLbl);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.lastNameTB);
            this.Controls.Add(this.firstNameTB);
            this.Controls.Add(this.editEmployeeLbl);
            this.Name = "EditEmployee";
            this.Text = "EditEmployee";
            this.Load += new System.EventHandler(this.EditEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.departmentNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label departmentIDLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.Label editEmployeeLbl;
        public System.Windows.Forms.NumericUpDown departmentNum;
        public System.Windows.Forms.TextBox passwordTB;
        public System.Windows.Forms.TextBox emailTB;
        public System.Windows.Forms.TextBox lastNameTB;
        public System.Windows.Forms.TextBox firstNameTB;
    }
}