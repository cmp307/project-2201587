namespace CMP307Project
{
    partial class EditAsset
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
            this.employeeNum = new System.Windows.Forms.NumericUpDown();
            this.autofillBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.employeeIDLbl = new System.Windows.Forms.Label();
            this.notesTB = new System.Windows.Forms.RichTextBox();
            this.datePick = new System.Windows.Forms.DateTimePicker();
            this.notesLbl = new System.Windows.Forms.Label();
            this.dateLbl = new System.Windows.Forms.Label();
            this.ipaddressLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.manufacturerLbl = new System.Windows.Forms.Label();
            this.modelLbl = new System.Windows.Forms.Label();
            this.systemNameLbl = new System.Windows.Forms.Label();
            this.ipTB = new System.Windows.Forms.TextBox();
            this.typeTB = new System.Windows.Forms.TextBox();
            this.manuTB = new System.Windows.Forms.TextBox();
            this.modelTB = new System.Windows.Forms.TextBox();
            this.sysNameTB = new System.Windows.Forms.TextBox();
            this.editAssetLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.employeeNum)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeNum
            // 
            this.employeeNum.Location = new System.Drawing.Point(218, 435);
            this.employeeNum.Name = "employeeNum";
            this.employeeNum.Size = new System.Drawing.Size(120, 20);
            this.employeeNum.TabIndex = 40;
            // 
            // autofillBtn
            // 
            this.autofillBtn.Location = new System.Drawing.Point(67, 486);
            this.autofillBtn.Name = "autofillBtn";
            this.autofillBtn.Size = new System.Drawing.Size(75, 23);
            this.autofillBtn.TabIndex = 39;
            this.autofillBtn.Text = "Autofill";
            this.autofillBtn.UseVisualStyleBackColor = true;
            this.autofillBtn.Click += new System.EventHandler(this.autofillBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(255, 486);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 38;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(162, 486);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 37;
            this.editBtn.Text = "Update Asset";
            this.editBtn.UseVisualStyleBackColor = true;
            // 
            // employeeIDLbl
            // 
            this.employeeIDLbl.AutoSize = true;
            this.employeeIDLbl.Location = new System.Drawing.Point(64, 437);
            this.employeeIDLbl.Name = "employeeIDLbl";
            this.employeeIDLbl.Size = new System.Drawing.Size(67, 13);
            this.employeeIDLbl.TabIndex = 36;
            this.employeeIDLbl.Text = "Employee ID";
            // 
            // notesTB
            // 
            this.notesTB.Location = new System.Drawing.Point(218, 320);
            this.notesTB.MaxLength = 512;
            this.notesTB.Name = "notesTB";
            this.notesTB.Size = new System.Drawing.Size(132, 96);
            this.notesTB.TabIndex = 35;
            this.notesTB.Text = "";
            // 
            // datePick
            // 
            this.datePick.Checked = false;
            this.datePick.Location = new System.Drawing.Point(218, 285);
            this.datePick.Name = "datePick";
            this.datePick.Size = new System.Drawing.Size(132, 20);
            this.datePick.TabIndex = 34;
            // 
            // notesLbl
            // 
            this.notesLbl.AutoSize = true;
            this.notesLbl.Location = new System.Drawing.Point(64, 323);
            this.notesLbl.Name = "notesLbl";
            this.notesLbl.Size = new System.Drawing.Size(35, 13);
            this.notesLbl.TabIndex = 33;
            this.notesLbl.Text = "Notes";
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Location = new System.Drawing.Point(64, 285);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(78, 13);
            this.dateLbl.TabIndex = 32;
            this.dateLbl.Text = "Purchase Date";
            // 
            // ipaddressLbl
            // 
            this.ipaddressLbl.AutoSize = true;
            this.ipaddressLbl.Location = new System.Drawing.Point(64, 249);
            this.ipaddressLbl.Name = "ipaddressLbl";
            this.ipaddressLbl.Size = new System.Drawing.Size(58, 13);
            this.ipaddressLbl.TabIndex = 31;
            this.ipaddressLbl.Text = "IP Address";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Location = new System.Drawing.Point(64, 213);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(35, 13);
            this.typeLbl.TabIndex = 30;
            this.typeLbl.Text = "Type*";
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
            // modelLbl
            // 
            this.modelLbl.AutoSize = true;
            this.modelLbl.Location = new System.Drawing.Point(64, 140);
            this.modelLbl.Name = "modelLbl";
            this.modelLbl.Size = new System.Drawing.Size(40, 13);
            this.modelLbl.TabIndex = 28;
            this.modelLbl.Text = "Model*";
            // 
            // systemNameLbl
            // 
            this.systemNameLbl.AutoSize = true;
            this.systemNameLbl.Location = new System.Drawing.Point(64, 103);
            this.systemNameLbl.Name = "systemNameLbl";
            this.systemNameLbl.Size = new System.Drawing.Size(76, 13);
            this.systemNameLbl.TabIndex = 27;
            this.systemNameLbl.Text = "System Name*";
            // 
            // ipTB
            // 
            this.ipTB.Location = new System.Drawing.Point(218, 246);
            this.ipTB.MaxLength = 15;
            this.ipTB.Name = "ipTB";
            this.ipTB.Size = new System.Drawing.Size(132, 20);
            this.ipTB.TabIndex = 26;
            // 
            // typeTB
            // 
            this.typeTB.Location = new System.Drawing.Point(218, 210);
            this.typeTB.MaxLength = 100;
            this.typeTB.Name = "typeTB";
            this.typeTB.Size = new System.Drawing.Size(132, 20);
            this.typeTB.TabIndex = 25;
            // 
            // manuTB
            // 
            this.manuTB.Location = new System.Drawing.Point(218, 174);
            this.manuTB.MaxLength = 255;
            this.manuTB.Name = "manuTB";
            this.manuTB.Size = new System.Drawing.Size(132, 20);
            this.manuTB.TabIndex = 24;
            // 
            // modelTB
            // 
            this.modelTB.Location = new System.Drawing.Point(218, 137);
            this.modelTB.MaxLength = 255;
            this.modelTB.Name = "modelTB";
            this.modelTB.Size = new System.Drawing.Size(132, 20);
            this.modelTB.TabIndex = 23;
            // 
            // sysNameTB
            // 
            this.sysNameTB.Location = new System.Drawing.Point(218, 100);
            this.sysNameTB.MaxLength = 255;
            this.sysNameTB.Name = "sysNameTB";
            this.sysNameTB.Size = new System.Drawing.Size(132, 20);
            this.sysNameTB.TabIndex = 22;
            // 
            // editAssetLbl
            // 
            this.editAssetLbl.AutoSize = true;
            this.editAssetLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.editAssetLbl.Location = new System.Drawing.Point(103, 27);
            this.editAssetLbl.Name = "editAssetLbl";
            this.editAssetLbl.Size = new System.Drawing.Size(161, 37);
            this.editAssetLbl.TabIndex = 21;
            this.editAssetLbl.Text = "Edit Asset";
            // 
            // EditAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 537);
            this.Controls.Add(this.employeeNum);
            this.Controls.Add(this.autofillBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.editBtn);
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
            this.Controls.Add(this.editAssetLbl);
            this.Name = "EditAsset";
            this.Text = "EditAsset";
            ((System.ComponentModel.ISupportInitialize)(this.employeeNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown employeeNum;
        private System.Windows.Forms.Button autofillBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label employeeIDLbl;
        private System.Windows.Forms.RichTextBox notesTB;
        private System.Windows.Forms.DateTimePicker datePick;
        private System.Windows.Forms.Label notesLbl;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Label ipaddressLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label manufacturerLbl;
        private System.Windows.Forms.Label modelLbl;
        private System.Windows.Forms.Label systemNameLbl;
        private System.Windows.Forms.TextBox ipTB;
        private System.Windows.Forms.TextBox typeTB;
        private System.Windows.Forms.TextBox manuTB;
        private System.Windows.Forms.TextBox modelTB;
        private System.Windows.Forms.TextBox sysNameTB;
        private System.Windows.Forms.Label editAssetLbl;
    }
}