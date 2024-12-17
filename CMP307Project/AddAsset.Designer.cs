namespace CMP307Project
{
    partial class AddAsset
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
            this.addAssetLbl = new System.Windows.Forms.Label();
            this.sysNameTB = new System.Windows.Forms.TextBox();
            this.modelTB = new System.Windows.Forms.TextBox();
            this.manuTB = new System.Windows.Forms.TextBox();
            this.typeTB = new System.Windows.Forms.TextBox();
            this.ipTB = new System.Windows.Forms.TextBox();
            this.systemNameLbl = new System.Windows.Forms.Label();
            this.modelLbl = new System.Windows.Forms.Label();
            this.manufacturerLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.ipaddressLbl = new System.Windows.Forms.Label();
            this.dateLbl = new System.Windows.Forms.Label();
            this.notesLbl = new System.Windows.Forms.Label();
            this.datePick = new System.Windows.Forms.DateTimePicker();
            this.notesTB = new System.Windows.Forms.RichTextBox();
            this.employeeIDLbl = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.autofillBtn = new System.Windows.Forms.Button();
            this.employeeNum = new System.Windows.Forms.NumericUpDown();
            this.dateCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.employeeNum)).BeginInit();
            this.SuspendLayout();
            // 
            // addAssetLbl
            // 
            this.addAssetLbl.AutoSize = true;
            this.addAssetLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.addAssetLbl.Location = new System.Drawing.Point(118, 28);
            this.addAssetLbl.Name = "addAssetLbl";
            this.addAssetLbl.Size = new System.Drawing.Size(164, 37);
            this.addAssetLbl.TabIndex = 0;
            this.addAssetLbl.Text = "Add Asset";
            // 
            // sysNameTB
            // 
            this.sysNameTB.Location = new System.Drawing.Point(233, 101);
            this.sysNameTB.MaxLength = 255;
            this.sysNameTB.Name = "sysNameTB";
            this.sysNameTB.Size = new System.Drawing.Size(132, 20);
            this.sysNameTB.TabIndex = 1;
            // 
            // modelTB
            // 
            this.modelTB.Location = new System.Drawing.Point(233, 138);
            this.modelTB.MaxLength = 255;
            this.modelTB.Name = "modelTB";
            this.modelTB.Size = new System.Drawing.Size(132, 20);
            this.modelTB.TabIndex = 2;
            // 
            // manuTB
            // 
            this.manuTB.Location = new System.Drawing.Point(233, 175);
            this.manuTB.MaxLength = 255;
            this.manuTB.Name = "manuTB";
            this.manuTB.Size = new System.Drawing.Size(132, 20);
            this.manuTB.TabIndex = 3;
            // 
            // typeTB
            // 
            this.typeTB.Location = new System.Drawing.Point(233, 211);
            this.typeTB.MaxLength = 100;
            this.typeTB.Name = "typeTB";
            this.typeTB.Size = new System.Drawing.Size(132, 20);
            this.typeTB.TabIndex = 4;
            // 
            // ipTB
            // 
            this.ipTB.Location = new System.Drawing.Point(233, 247);
            this.ipTB.MaxLength = 15;
            this.ipTB.Name = "ipTB";
            this.ipTB.Size = new System.Drawing.Size(132, 20);
            this.ipTB.TabIndex = 5;
            // 
            // systemNameLbl
            // 
            this.systemNameLbl.AutoSize = true;
            this.systemNameLbl.Location = new System.Drawing.Point(79, 104);
            this.systemNameLbl.Name = "systemNameLbl";
            this.systemNameLbl.Size = new System.Drawing.Size(76, 13);
            this.systemNameLbl.TabIndex = 7;
            this.systemNameLbl.Text = "System Name*";
            // 
            // modelLbl
            // 
            this.modelLbl.AutoSize = true;
            this.modelLbl.Location = new System.Drawing.Point(79, 141);
            this.modelLbl.Name = "modelLbl";
            this.modelLbl.Size = new System.Drawing.Size(40, 13);
            this.modelLbl.TabIndex = 8;
            this.modelLbl.Text = "Model*";
            // 
            // manufacturerLbl
            // 
            this.manufacturerLbl.AutoSize = true;
            this.manufacturerLbl.Location = new System.Drawing.Point(79, 178);
            this.manufacturerLbl.Name = "manufacturerLbl";
            this.manufacturerLbl.Size = new System.Drawing.Size(74, 13);
            this.manufacturerLbl.TabIndex = 9;
            this.manufacturerLbl.Text = "Manufacturer*";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Location = new System.Drawing.Point(79, 214);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(35, 13);
            this.typeLbl.TabIndex = 10;
            this.typeLbl.Text = "Type*";
            // 
            // ipaddressLbl
            // 
            this.ipaddressLbl.AutoSize = true;
            this.ipaddressLbl.Location = new System.Drawing.Point(79, 250);
            this.ipaddressLbl.Name = "ipaddressLbl";
            this.ipaddressLbl.Size = new System.Drawing.Size(58, 13);
            this.ipaddressLbl.TabIndex = 11;
            this.ipaddressLbl.Text = "IP Address";
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Location = new System.Drawing.Point(79, 321);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(78, 13);
            this.dateLbl.TabIndex = 12;
            this.dateLbl.Text = "Purchase Date";
            // 
            // notesLbl
            // 
            this.notesLbl.AutoSize = true;
            this.notesLbl.Location = new System.Drawing.Point(79, 359);
            this.notesLbl.Name = "notesLbl";
            this.notesLbl.Size = new System.Drawing.Size(35, 13);
            this.notesLbl.TabIndex = 13;
            this.notesLbl.Text = "Notes";
            // 
            // datePick
            // 
            this.datePick.Checked = false;
            this.datePick.Location = new System.Drawing.Point(233, 321);
            this.datePick.Name = "datePick";
            this.datePick.Size = new System.Drawing.Size(132, 20);
            this.datePick.TabIndex = 14;
            // 
            // notesTB
            // 
            this.notesTB.Location = new System.Drawing.Point(233, 356);
            this.notesTB.MaxLength = 512;
            this.notesTB.Name = "notesTB";
            this.notesTB.Size = new System.Drawing.Size(132, 96);
            this.notesTB.TabIndex = 15;
            this.notesTB.Text = "";
            // 
            // employeeIDLbl
            // 
            this.employeeIDLbl.AutoSize = true;
            this.employeeIDLbl.Location = new System.Drawing.Point(79, 473);
            this.employeeIDLbl.Name = "employeeIDLbl";
            this.employeeIDLbl.Size = new System.Drawing.Size(67, 13);
            this.employeeIDLbl.TabIndex = 16;
            this.employeeIDLbl.Text = "Employee ID";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(177, 522);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 17;
            this.addBtn.Text = "Add Asset";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(270, 522);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // autofillBtn
            // 
            this.autofillBtn.Location = new System.Drawing.Point(82, 522);
            this.autofillBtn.Name = "autofillBtn";
            this.autofillBtn.Size = new System.Drawing.Size(75, 23);
            this.autofillBtn.TabIndex = 19;
            this.autofillBtn.Text = "Autofill";
            this.autofillBtn.UseVisualStyleBackColor = true;
            this.autofillBtn.Click += new System.EventHandler(this.autofillBtn_Click);
            // 
            // employeeNum
            // 
            this.employeeNum.Location = new System.Drawing.Point(233, 471);
            this.employeeNum.Name = "employeeNum";
            this.employeeNum.Size = new System.Drawing.Size(120, 20);
            this.employeeNum.TabIndex = 20;
            // 
            // dateCB
            // 
            this.dateCB.AutoSize = true;
            this.dateCB.Location = new System.Drawing.Point(138, 287);
            this.dateCB.Name = "dateCB";
            this.dateCB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateCB.Size = new System.Drawing.Size(125, 17);
            this.dateCB.TabIndex = 21;
            this.dateCB.Text = "?Is there a date lable";
            this.dateCB.UseVisualStyleBackColor = true;
            // 
            // AddAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 563);
            this.Controls.Add(this.dateCB);
            this.Controls.Add(this.employeeNum);
            this.Controls.Add(this.autofillBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.employeeIDLbl);
            this.Controls.Add(this.notesTB);
            this.Controls.Add(this.datePick);
            this.Controls.Add(this.notesLbl);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.ipaddressLbl);
            this.Controls.Add(this.typeLbl);
            this.Controls.Add(this.manufacturerLbl);
            this.Controls.Add(this.modelLbl);
            this.Controls.Add(this.systemNameLbl);
            this.Controls.Add(this.ipTB);
            this.Controls.Add(this.typeTB);
            this.Controls.Add(this.manuTB);
            this.Controls.Add(this.modelTB);
            this.Controls.Add(this.sysNameTB);
            this.Controls.Add(this.addAssetLbl);
            this.Name = "AddAsset";
            this.Text = "AddAsset";
            this.Load += new System.EventHandler(this.AddAsset_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addAssetLbl;
        private System.Windows.Forms.TextBox sysNameTB;
        private System.Windows.Forms.TextBox modelTB;
        private System.Windows.Forms.TextBox manuTB;
        private System.Windows.Forms.TextBox typeTB;
        private System.Windows.Forms.TextBox ipTB;
        private System.Windows.Forms.Label systemNameLbl;
        private System.Windows.Forms.Label modelLbl;
        private System.Windows.Forms.Label manufacturerLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label ipaddressLbl;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Label notesLbl;
        private System.Windows.Forms.DateTimePicker datePick;
        private System.Windows.Forms.RichTextBox notesTB;
        private System.Windows.Forms.Label employeeIDLbl;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button autofillBtn;
        private System.Windows.Forms.NumericUpDown employeeNum;
        private System.Windows.Forms.CheckBox dateCB;
    }
}