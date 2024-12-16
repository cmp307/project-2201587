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
            this.assetsTable = new System.Windows.Forms.DataGridView();
            this.assetsAssID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.systemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.assetBindingSource = new CMP307Project.assetBindingSource();
            this.softwareTable = new System.Windows.Forms.DataGridView();
            this.softwareSoftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oSnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softwareBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareBindingSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.softwareBindingSource = new CMP307Project.softwareBindingSource();
            this.profileLbl = new System.Windows.Forms.Label();
            this.assetTableAdapter = new CMP307Project.assetBindingSourceTableAdapters.AssetTableAdapter();
            this.softwareBindingSourceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareBindingSourceBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareTableAdapter = new CMP307Project.softwareBindingSourceTableAdapters.SoftwareTableAdapter();
            this.linksTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.linksBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.linksBindingSource = new CMP307Project.linksBindingSource();
            this.linksTableAdapter = new CMP307Project.linksBindingSourceTableAdapters.LinksTableAdapter();
            this.addAssetBtn = new System.Windows.Forms.Button();
            this.addSoftBtn = new System.Windows.Forms.Button();
            this.editAssetBtn = new System.Windows.Forms.Button();
            this.editSoftBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.addLinkBtn = new System.Windows.Forms.Button();
            this.editLinkBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.assetsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // assetsTable
            // 
            this.assetsTable.AllowUserToAddRows = false;
            this.assetsTable.AllowUserToDeleteRows = false;
            this.assetsTable.AutoGenerateColumns = false;
            this.assetsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assetsAssID,
            this.systemNameDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.iPAddressDataGridViewTextBoxColumn,
            this.purchaseDateDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn});
            this.assetsTable.DataSource = this.assetBindingSource1;
            this.assetsTable.Location = new System.Drawing.Point(26, 118);
            this.assetsTable.MultiSelect = false;
            this.assetsTable.Name = "assetsTable";
            this.assetsTable.ReadOnly = true;
            this.assetsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.assetsTable.Size = new System.Drawing.Size(946, 150);
            this.assetsTable.TabIndex = 0;
            // 
            // assetsAssID
            // 
            this.assetsAssID.DataPropertyName = "AssID";
            this.assetsAssID.HeaderText = "AssID";
            this.assetsAssID.Name = "assetsAssID";
            this.assetsAssID.ReadOnly = true;
            // 
            // systemNameDataGridViewTextBoxColumn
            // 
            this.systemNameDataGridViewTextBoxColumn.DataPropertyName = "SystemName";
            this.systemNameDataGridViewTextBoxColumn.HeaderText = "SystemName";
            this.systemNameDataGridViewTextBoxColumn.Name = "systemNameDataGridViewTextBoxColumn";
            this.systemNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iPAddressDataGridViewTextBoxColumn
            // 
            this.iPAddressDataGridViewTextBoxColumn.DataPropertyName = "IPAddress";
            this.iPAddressDataGridViewTextBoxColumn.HeaderText = "IPAddress";
            this.iPAddressDataGridViewTextBoxColumn.Name = "iPAddressDataGridViewTextBoxColumn";
            this.iPAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchaseDateDataGridViewTextBoxColumn
            // 
            this.purchaseDateDataGridViewTextBoxColumn.DataPropertyName = "PurchaseDate";
            this.purchaseDateDataGridViewTextBoxColumn.HeaderText = "PurchaseDate";
            this.purchaseDateDataGridViewTextBoxColumn.Name = "purchaseDateDataGridViewTextBoxColumn";
            this.purchaseDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // assetBindingSource1
            // 
            this.assetBindingSource1.DataMember = "Asset";
            this.assetBindingSource1.DataSource = this.assetBindingSource;
            // 
            // assetBindingSource
            // 
            this.assetBindingSource.DataSetName = "assetBindingSource";
            this.assetBindingSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // softwareTable
            // 
            this.softwareTable.AllowUserToAddRows = false;
            this.softwareTable.AllowUserToDeleteRows = false;
            this.softwareTable.AutoGenerateColumns = false;
            this.softwareTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.softwareTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.softwareSoftID,
            this.oSnameDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn1});
            this.softwareTable.DataSource = this.softwareBindingSource2;
            this.softwareTable.Location = new System.Drawing.Point(526, 288);
            this.softwareTable.MultiSelect = false;
            this.softwareTable.Name = "softwareTable";
            this.softwareTable.ReadOnly = true;
            this.softwareTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.softwareTable.Size = new System.Drawing.Size(446, 150);
            this.softwareTable.TabIndex = 1;
            // 
            // softwareSoftID
            // 
            this.softwareSoftID.DataPropertyName = "SoftID";
            this.softwareSoftID.HeaderText = "SoftID";
            this.softwareSoftID.Name = "softwareSoftID";
            this.softwareSoftID.ReadOnly = true;
            // 
            // oSnameDataGridViewTextBoxColumn
            // 
            this.oSnameDataGridViewTextBoxColumn.DataPropertyName = "OSname";
            this.oSnameDataGridViewTextBoxColumn.HeaderText = "OSname";
            this.oSnameDataGridViewTextBoxColumn.Name = "oSnameDataGridViewTextBoxColumn";
            this.oSnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manufacturerDataGridViewTextBoxColumn1
            // 
            this.manufacturerDataGridViewTextBoxColumn1.DataPropertyName = "manufacturer";
            this.manufacturerDataGridViewTextBoxColumn1.HeaderText = "manufacturer";
            this.manufacturerDataGridViewTextBoxColumn1.Name = "manufacturerDataGridViewTextBoxColumn1";
            this.manufacturerDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // softwareBindingSource2
            // 
            this.softwareBindingSource2.DataMember = "Software";
            this.softwareBindingSource2.DataSource = this.softwareBindingSourceBindingSource;
            // 
            // softwareBindingSourceBindingSource
            // 
            this.softwareBindingSourceBindingSource.DataSource = this.softwareBindingSource;
            this.softwareBindingSourceBindingSource.Position = 0;
            // 
            // softwareBindingSource
            // 
            this.softwareBindingSource.DataSetName = "softwareBindingSource";
            this.softwareBindingSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // assetTableAdapter
            // 
            this.assetTableAdapter.ClearBeforeFill = true;
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
            // linksTable
            // 
            this.linksTable.AllowUserToAddRows = false;
            this.linksTable.AllowUserToDeleteRows = false;
            this.linksTable.AutoGenerateColumns = false;
            this.linksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.linksTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.AssID,
            this.Date,
            this.Active});
            this.linksTable.DataSource = this.linksBindingSource1;
            this.linksTable.Location = new System.Drawing.Point(26, 288);
            this.linksTable.MultiSelect = false;
            this.linksTable.Name = "linksTable";
            this.linksTable.ReadOnly = true;
            this.linksTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.linksTable.Size = new System.Drawing.Size(446, 150);
            this.linksTable.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SoftID";
            this.dataGridViewTextBoxColumn1.HeaderText = "SoftID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // AssID
            // 
            this.AssID.DataPropertyName = "AssID";
            this.AssID.HeaderText = "AssID";
            this.AssID.Name = "AssID";
            this.AssID.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // linksBindingSource1
            // 
            this.linksBindingSource1.DataMember = "Links";
            this.linksBindingSource1.DataSource = this.linksBindingSource;
            // 
            // linksBindingSource
            // 
            this.linksBindingSource.DataSetName = "linksBindingSource";
            this.linksBindingSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // linksTableAdapter
            // 
            this.linksTableAdapter.ClearBeforeFill = true;
            // 
            // addAssetBtn
            // 
            this.addAssetBtn.Location = new System.Drawing.Point(26, 462);
            this.addAssetBtn.Name = "addAssetBtn";
            this.addAssetBtn.Size = new System.Drawing.Size(75, 37);
            this.addAssetBtn.TabIndex = 4;
            this.addAssetBtn.Text = "Add Asset";
            this.addAssetBtn.UseVisualStyleBackColor = true;
            this.addAssetBtn.Click += new System.EventHandler(this.addAssetBtn_Click);
            // 
            // addSoftBtn
            // 
            this.addSoftBtn.Location = new System.Drawing.Point(188, 462);
            this.addSoftBtn.Name = "addSoftBtn";
            this.addSoftBtn.Size = new System.Drawing.Size(75, 37);
            this.addSoftBtn.TabIndex = 5;
            this.addSoftBtn.Text = "Add Software";
            this.addSoftBtn.UseVisualStyleBackColor = true;
            this.addSoftBtn.Click += new System.EventHandler(this.addSoftBtn_Click);
            // 
            // editAssetBtn
            // 
            this.editAssetBtn.Location = new System.Drawing.Point(107, 462);
            this.editAssetBtn.Name = "editAssetBtn";
            this.editAssetBtn.Size = new System.Drawing.Size(75, 37);
            this.editAssetBtn.TabIndex = 6;
            this.editAssetBtn.Text = "Edit Asset";
            this.editAssetBtn.UseVisualStyleBackColor = true;
            this.editAssetBtn.Click += new System.EventHandler(this.editAssetBtn_Click);
            // 
            // editSoftBtn
            // 
            this.editSoftBtn.Location = new System.Drawing.Point(269, 462);
            this.editSoftBtn.Name = "editSoftBtn";
            this.editSoftBtn.Size = new System.Drawing.Size(75, 37);
            this.editSoftBtn.TabIndex = 7;
            this.editSoftBtn.Text = "Edit Software";
            this.editSoftBtn.UseVisualStyleBackColor = true;
            this.editSoftBtn.Click += new System.EventHandler(this.editSoftBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(897, 462);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 37);
            this.closeBtn.TabIndex = 8;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(816, 462);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 37);
            this.refreshBtn.TabIndex = 9;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // addLinkBtn
            // 
            this.addLinkBtn.Location = new System.Drawing.Point(350, 462);
            this.addLinkBtn.Name = "addLinkBtn";
            this.addLinkBtn.Size = new System.Drawing.Size(75, 37);
            this.addLinkBtn.TabIndex = 10;
            this.addLinkBtn.Text = "Add Link";
            this.addLinkBtn.UseVisualStyleBackColor = true;
            // 
            // editLinkBtn
            // 
            this.editLinkBtn.Location = new System.Drawing.Point(431, 462);
            this.editLinkBtn.Name = "editLinkBtn";
            this.editLinkBtn.Size = new System.Drawing.Size(75, 37);
            this.editLinkBtn.TabIndex = 11;
            this.editLinkBtn.Text = "Edit Link";
            this.editLinkBtn.UseVisualStyleBackColor = true;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 532);
            this.Controls.Add(this.editLinkBtn);
            this.Controls.Add(this.addLinkBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.editSoftBtn);
            this.Controls.Add(this.editAssetBtn);
            this.Controls.Add(this.addSoftBtn);
            this.Controls.Add(this.addAssetBtn);
            this.Controls.Add(this.linksTable);
            this.Controls.Add(this.profileLbl);
            this.Controls.Add(this.softwareTable);
            this.Controls.Add(this.assetsTable);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assetsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSourceBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView assetsTable;
        private System.Windows.Forms.DataGridView softwareTable;
        private System.Windows.Forms.Label profileLbl;
        private assetBindingSource assetBindingSource;
        private System.Windows.Forms.BindingSource assetBindingSource1;
        private assetBindingSourceTableAdapters.AssetTableAdapter assetTableAdapter;
        private System.Windows.Forms.BindingSource softwareBindingSourceBindingSource2;
        private softwareBindingSource softwareBindingSource;
        private System.Windows.Forms.BindingSource softwareBindingSourceBindingSource;
        private System.Windows.Forms.BindingSource softwareBindingSourceBindingSource1;
        private System.Windows.Forms.BindingSource softwareBindingSource1;
        private softwareBindingSourceTableAdapters.SoftwareTableAdapter softwareTableAdapter;
        private System.Windows.Forms.BindingSource softwareBindingSource2;
        private System.Windows.Forms.DataGridView linksTable;
        private linksBindingSource linksBindingSource;
        private System.Windows.Forms.BindingSource linksBindingSource1;
        private linksBindingSourceTableAdapters.LinksTableAdapter linksTableAdapter;
        private System.Windows.Forms.Button addAssetBtn;
        private System.Windows.Forms.Button addSoftBtn;
        private System.Windows.Forms.Button editAssetBtn;
        private System.Windows.Forms.Button editSoftBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetsAssID;
        private System.Windows.Forms.DataGridViewTextBoxColumn systemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn softwareSoftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn oSnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button addLinkBtn;
        private System.Windows.Forms.Button editLinkBtn;
    }
}