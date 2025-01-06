namespace CMP307Project
{
    partial class AddEmployee
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
            this.addBtn = new System.Windows.Forms.Button();
            this.departmentIDLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.lastNameTB = new System.Windows.Forms.TextBox();
            this.firstNameTB = new System.Windows.Forms.TextBox();
            this.addEmployeeLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.departmentNum)).BeginInit();
            this.SuspendLayout();
            // 
            // departmentNum
            // 
            this.departmentNum.Location = new System.Drawing.Point(218, 250);
            this.departmentNum.Name = "departmentNum";
            this.departmentNum.Size = new System.Drawing.Size(132, 20);
            this.departmentNum.TabIndex = 40;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(246, 303);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 40);
            this.cancelBtn.TabIndex = 38;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(104, 303);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 40);
            this.addBtn.TabIndex = 37;
            this.addBtn.Text = "Add Employee";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // departmentIDLbl
            // 
            this.departmentIDLbl.AutoSize = true;
            this.departmentIDLbl.Location = new System.Drawing.Point(64, 252);
            this.departmentIDLbl.Name = "departmentIDLbl";
            this.departmentIDLbl.Size = new System.Drawing.Size(80, 13);
            this.departmentIDLbl.TabIndex = 36;
            this.departmentIDLbl.Text = "Department ID*";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(64, 213);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(57, 13);
            this.passwordLbl.TabIndex = 30;
            this.passwordLbl.Text = "Password*";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(64, 177);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(36, 13);
            this.emailLbl.TabIndex = 29;
            this.emailLbl.Text = "Email*";
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Location = new System.Drawing.Point(64, 140);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(62, 13);
            this.lastNameLbl.TabIndex = 28;
            this.lastNameLbl.Text = "Last Name*";
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.Location = new System.Drawing.Point(64, 103);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(61, 13);
            this.firstNameLbl.TabIndex = 27;
            this.firstNameLbl.Text = "First Name*";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(218, 210);
            this.passwordTB.MaxLength = 100;
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(132, 20);
            this.passwordTB.TabIndex = 25;
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(218, 174);
            this.emailTB.MaxLength = 255;
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(132, 20);
            this.emailTB.TabIndex = 24;
            // 
            // lastNameTB
            // 
            this.lastNameTB.Location = new System.Drawing.Point(218, 137);
            this.lastNameTB.MaxLength = 255;
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Size = new System.Drawing.Size(132, 20);
            this.lastNameTB.TabIndex = 23;
            // 
            // firstNameTB
            // 
            this.firstNameTB.Location = new System.Drawing.Point(218, 100);
            this.firstNameTB.MaxLength = 255;
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Size = new System.Drawing.Size(132, 20);
            this.firstNameTB.TabIndex = 22;
            // 
            // addEmployeeLbl
            // 
            this.addEmployeeLbl.AutoSize = true;
            this.addEmployeeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.addEmployeeLbl.Location = new System.Drawing.Point(97, 27);
            this.addEmployeeLbl.Name = "addEmployeeLbl";
            this.addEmployeeLbl.Size = new System.Drawing.Size(224, 37);
            this.addEmployeeLbl.TabIndex = 21;
            this.addEmployeeLbl.Text = "Add Employee";
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 363);
            this.Controls.Add(this.departmentNum);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.departmentIDLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.lastNameLbl);
            this.Controls.Add(this.firstNameLbl);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.lastNameTB);
            this.Controls.Add(this.firstNameTB);
            this.Controls.Add(this.addEmployeeLbl);
            this.Name = "AddEmployee";
            this.Text = "AddEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.departmentNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label departmentIDLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.Label addEmployeeLbl;
        public System.Windows.Forms.NumericUpDown departmentNum;
        public System.Windows.Forms.TextBox passwordTB;
        public System.Windows.Forms.TextBox emailTB;
        public System.Windows.Forms.TextBox lastNameTB;
        public System.Windows.Forms.TextBox firstNameTB;
    }
}