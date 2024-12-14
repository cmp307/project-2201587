namespace CMP307Project
{
    partial class ProfileForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.profileLbl = new System.Windows.Forms.Label();
            this.assetBindingSource = new CMP307Project.assetBindingSource();
            this.assetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.assetTableAdapter = new CMP307Project.assetBindingSourceTableAdapters.AssetTableAdapter();
            this.assIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.systemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softwareBindingSource = new CMP307Project.softwareBindingSource();
            this.softwareBindingSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.softwareBindingSourceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareBindingSourceBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareTableAdapter = new CMP307Project.softwareBindingSourceTableAdapters.SoftwareTableAdapter();
            this.softwareBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.softIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oSnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assIDDataGridViewTextBoxColumn,
            this.systemNameDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.iPAddressDataGridViewTextBoxColumn,
            this.purchaseDateDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.assetBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(26, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(946, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.softIDDataGridViewTextBoxColumn,
            this.oSnameDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.softwareBindingSource2;
            this.dataGridView2.Location = new System.Drawing.Point(296, 288);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(446, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // profileLbl
            // 
            this.profileLbl.AutoSize = true;
            this.profileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.profileLbl.Location = new System.Drawing.Point(451, 35);
            this.profileLbl.Name = "profileLbl";
            this.profileLbl.Size = new System.Drawing.Size(107, 37);
            this.profileLbl.TabIndex = 2;
            this.profileLbl.Text = "Profile";
            // 
            // assetBindingSource
            // 
            this.assetBindingSource.DataSetName = "assetBindingSource";
            this.assetBindingSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // assetBindingSource1
            // 
            this.assetBindingSource1.DataMember = "Asset";
            this.assetBindingSource1.DataSource = this.assetBindingSource;
            // 
            // assetTableAdapter
            // 
            this.assetTableAdapter.ClearBeforeFill = true;
            // 
            // assIDDataGridViewTextBoxColumn
            // 
            this.assIDDataGridViewTextBoxColumn.DataPropertyName = "AssID";
            this.assIDDataGridViewTextBoxColumn.HeaderText = "AssID";
            this.assIDDataGridViewTextBoxColumn.Name = "assIDDataGridViewTextBoxColumn";
            this.assIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // systemNameDataGridViewTextBoxColumn
            // 
            this.systemNameDataGridViewTextBoxColumn.DataPropertyName = "SystemName";
            this.systemNameDataGridViewTextBoxColumn.HeaderText = "SystemName";
            this.systemNameDataGridViewTextBoxColumn.Name = "systemNameDataGridViewTextBoxColumn";
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // iPAddressDataGridViewTextBoxColumn
            // 
            this.iPAddressDataGridViewTextBoxColumn.DataPropertyName = "IPAddress";
            this.iPAddressDataGridViewTextBoxColumn.HeaderText = "IPAddress";
            this.iPAddressDataGridViewTextBoxColumn.Name = "iPAddressDataGridViewTextBoxColumn";
            // 
            // purchaseDateDataGridViewTextBoxColumn
            // 
            this.purchaseDateDataGridViewTextBoxColumn.DataPropertyName = "PurchaseDate";
            this.purchaseDateDataGridViewTextBoxColumn.HeaderText = "PurchaseDate";
            this.purchaseDateDataGridViewTextBoxColumn.Name = "purchaseDateDataGridViewTextBoxColumn";
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            // 
            // softwareBindingSource
            // 
            this.softwareBindingSource.DataSetName = "softwareBindingSource";
            this.softwareBindingSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // softwareBindingSourceBindingSource
            // 
            this.softwareBindingSourceBindingSource.DataSource = this.softwareBindingSource;
            this.softwareBindingSourceBindingSource.Position = 0;
            // 
            // softwareBindingSourceBindingSource1
            // 
            this.softwareBindingSourceBindingSource1.DataSource = this.softwareBindingSource;
            this.softwareBindingSourceBindingSource1.Position = 0;
            // 
            // softwareBindingSourceBindingSource2
            // 
            this.softwareBindingSourceBindingSource2.DataSource = this.softwareBindingSource;
            this.softwareBindingSourceBindingSource2.Position = 0;
            // 
            // softwareBindingSource1
            // 
            this.softwareBindingSource1.DataMember = "Software";
            this.softwareBindingSource1.DataSource = this.softwareBindingSourceBindingSource2;
            // 
            // softwareTableAdapter
            // 
            this.softwareTableAdapter.ClearBeforeFill = true;
            // 
            // softwareBindingSource2
            // 
            this.softwareBindingSource2.DataMember = "Software";
            this.softwareBindingSource2.DataSource = this.softwareBindingSourceBindingSource;
            // 
            // softIDDataGridViewTextBoxColumn
            // 
            this.softIDDataGridViewTextBoxColumn.DataPropertyName = "SoftID";
            this.softIDDataGridViewTextBoxColumn.HeaderText = "SoftID";
            this.softIDDataGridViewTextBoxColumn.Name = "softIDDataGridViewTextBoxColumn";
            this.softIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oSnameDataGridViewTextBoxColumn
            // 
            this.oSnameDataGridViewTextBoxColumn.DataPropertyName = "OSname";
            this.oSnameDataGridViewTextBoxColumn.HeaderText = "OSname";
            this.oSnameDataGridViewTextBoxColumn.Name = "oSnameDataGridViewTextBoxColumn";
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            // 
            // manufacturerDataGridViewTextBoxColumn1
            // 
            this.manufacturerDataGridViewTextBoxColumn1.DataPropertyName = "manufacturer";
            this.manufacturerDataGridViewTextBoxColumn1.HeaderText = "manufacturer";
            this.manufacturerDataGridViewTextBoxColumn1.Name = "manufacturerDataGridViewTextBoxColumn1";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 478);
            this.Controls.Add(this.profileLbl);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label profileLbl;
        private assetBindingSource assetBindingSource;
        private System.Windows.Forms.BindingSource assetBindingSource1;
        private assetBindingSourceTableAdapters.AssetTableAdapter assetTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn assIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn systemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource softwareBindingSourceBindingSource2;
        private softwareBindingSource softwareBindingSource;
        private System.Windows.Forms.BindingSource softwareBindingSourceBindingSource;
        private System.Windows.Forms.BindingSource softwareBindingSourceBindingSource1;
        private System.Windows.Forms.BindingSource softwareBindingSource1;
        private softwareBindingSourceTableAdapters.SoftwareTableAdapter softwareTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn softIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oSnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource softwareBindingSource2;
    }
}