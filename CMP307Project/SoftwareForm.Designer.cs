namespace CMP307Project
{
    partial class SoftwareForm
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.assetTableAdapter = new CMP307Project.mssql2201587DataSetTableAdapters.AssetTableAdapter();
            this.mssql2201587DataSet = new CMP307Project.mssql2201587DataSet();
            this.mssql2201587DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.assetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.refreshBtn = new System.Windows.Forms.Button();
            this.softwareTable = new System.Windows.Forms.DataGridView();
            this.SoftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oSnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softwareBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareBindingSource = new CMP307Project.softwareBindingSource();
            this.softwareLbl = new System.Windows.Forms.Label();
            this.softwareTableAdapter = new CMP307Project.softwareBindingSourceTableAdapters.SoftwareTableAdapter();
            this.linksTable = new System.Windows.Forms.DataGridView();
            this.linkSoftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.linksBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.linksBindingSource = new CMP307Project.linksBindingSource();
            this.linksTableAdapter = new CMP307Project.linksBindingSourceTableAdapters.LinksTableAdapter();
            this.vulnCheckBtn = new System.Windows.Forms.Button();
            this.addLinkBtn = new System.Windows.Forms.Button();
            this.editLinkBtn = new System.Windows.Forms.Button();
            this.deleteLinkBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2201587DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2201587DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(907, 338);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 41);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(165, 338);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 41);
            this.editBtn.TabIndex = 11;
            this.editBtn.Text = "Edit Software";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(246, 338);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 41);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Delete Software";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(84, 338);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 41);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "Add Software";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // assetTableAdapter
            // 
            this.assetTableAdapter.ClearBeforeFill = true;
            // 
            // mssql2201587DataSet
            // 
            this.mssql2201587DataSet.DataSetName = "mssql2201587DataSet";
            this.mssql2201587DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mssql2201587DataSetBindingSource
            // 
            this.mssql2201587DataSetBindingSource.DataSource = this.mssql2201587DataSet;
            this.mssql2201587DataSetBindingSource.Position = 0;
            // 
            // assetBindingSource
            // 
            this.assetBindingSource.DataMember = "Asset";
            this.assetBindingSource.DataSource = this.mssql2201587DataSetBindingSource;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(826, 338);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 41);
            this.refreshBtn.TabIndex = 12;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // softwareTable
            // 
            this.softwareTable.AllowUserToAddRows = false;
            this.softwareTable.AllowUserToDeleteRows = false;
            this.softwareTable.AutoGenerateColumns = false;
            this.softwareTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.softwareTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoftID,
            this.oSnameDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn});
            this.softwareTable.DataSource = this.softwareBindingSource1;
            this.softwareTable.Location = new System.Drawing.Point(84, 112);
            this.softwareTable.MultiSelect = false;
            this.softwareTable.Name = "softwareTable";
            this.softwareTable.ReadOnly = true;
            this.softwareTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.softwareTable.Size = new System.Drawing.Size(446, 189);
            this.softwareTable.TabIndex = 8;
            // 
            // SoftID
            // 
            this.SoftID.DataPropertyName = "SoftID";
            this.SoftID.HeaderText = "SoftID";
            this.SoftID.Name = "SoftID";
            this.SoftID.ReadOnly = true;
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
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // softwareBindingSource1
            // 
            this.softwareBindingSource1.DataMember = "Software";
            this.softwareBindingSource1.DataSource = this.softwareBindingSource;
            // 
            // softwareBindingSource
            // 
            this.softwareBindingSource.DataSetName = "softwareBindingSource";
            this.softwareBindingSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // softwareLbl
            // 
            this.softwareLbl.AutoSize = true;
            this.softwareLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.softwareLbl.Location = new System.Drawing.Point(459, 50);
            this.softwareLbl.Name = "softwareLbl";
            this.softwareLbl.Size = new System.Drawing.Size(143, 37);
            this.softwareLbl.TabIndex = 7;
            this.softwareLbl.Text = "Software";
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
            this.linkSoftID,
            this.AssID,
            this.Date,
            this.Active});
            this.linksTable.DataSource = this.linksBindingSource1;
            this.linksTable.Location = new System.Drawing.Point(536, 112);
            this.linksTable.MultiSelect = false;
            this.linksTable.Name = "linksTable";
            this.linksTable.ReadOnly = true;
            this.linksTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.linksTable.Size = new System.Drawing.Size(446, 189);
            this.linksTable.TabIndex = 14;
            // 
            // linkSoftID
            // 
            this.linkSoftID.DataPropertyName = "SoftID";
            this.linkSoftID.HeaderText = "SoftID";
            this.linkSoftID.Name = "linkSoftID";
            this.linkSoftID.ReadOnly = true;
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
            // vulnCheckBtn
            // 
            this.vulnCheckBtn.Location = new System.Drawing.Point(570, 338);
            this.vulnCheckBtn.Name = "vulnCheckBtn";
            this.vulnCheckBtn.Size = new System.Drawing.Size(80, 41);
            this.vulnCheckBtn.TabIndex = 15;
            this.vulnCheckBtn.Text = "Check Vulnerabilities ";
            this.vulnCheckBtn.UseVisualStyleBackColor = true;
            this.vulnCheckBtn.Click += new System.EventHandler(this.vulnCheckBtn_Click);
            // 
            // addLinkBtn
            // 
            this.addLinkBtn.Location = new System.Drawing.Point(327, 338);
            this.addLinkBtn.Name = "addLinkBtn";
            this.addLinkBtn.Size = new System.Drawing.Size(75, 41);
            this.addLinkBtn.TabIndex = 16;
            this.addLinkBtn.Text = "Add Link";
            this.addLinkBtn.UseVisualStyleBackColor = true;
            this.addLinkBtn.Click += new System.EventHandler(this.addLinkBtn_Click);
            // 
            // editLinkBtn
            // 
            this.editLinkBtn.Location = new System.Drawing.Point(408, 338);
            this.editLinkBtn.Name = "editLinkBtn";
            this.editLinkBtn.Size = new System.Drawing.Size(75, 41);
            this.editLinkBtn.TabIndex = 17;
            this.editLinkBtn.Text = "Edit Link";
            this.editLinkBtn.UseVisualStyleBackColor = true;
            this.editLinkBtn.Click += new System.EventHandler(this.editLinkBtn_Click);
            // 
            // deleteLinkBtn
            // 
            this.deleteLinkBtn.Location = new System.Drawing.Point(489, 338);
            this.deleteLinkBtn.Name = "deleteLinkBtn";
            this.deleteLinkBtn.Size = new System.Drawing.Size(75, 41);
            this.deleteLinkBtn.TabIndex = 18;
            this.deleteLinkBtn.Text = "Delete Link";
            this.deleteLinkBtn.UseVisualStyleBackColor = true;
            this.deleteLinkBtn.Click += new System.EventHandler(this.deleteLinkBtn_Click);
            // 
            // SoftwareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 424);
            this.Controls.Add(this.deleteLinkBtn);
            this.Controls.Add(this.editLinkBtn);
            this.Controls.Add(this.addLinkBtn);
            this.Controls.Add(this.vulnCheckBtn);
            this.Controls.Add(this.linksTable);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.softwareTable);
            this.Controls.Add(this.softwareLbl);
            this.Name = "SoftwareForm";
            this.Text = "SoftwareForm";
            this.Load += new System.EventHandler(this.SoftwareForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mssql2201587DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2201587DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linksBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private mssql2201587DataSetTableAdapters.AssetTableAdapter assetTableAdapter;
        private mssql2201587DataSet mssql2201587DataSet;
        private System.Windows.Forms.BindingSource mssql2201587DataSetBindingSource;
        private System.Windows.Forms.BindingSource assetBindingSource;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Label softwareLbl;
        private softwareBindingSource softwareBindingSource;
        private System.Windows.Forms.BindingSource softwareBindingSource1;
        private softwareBindingSourceTableAdapters.SoftwareTableAdapter softwareTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn oSnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private linksBindingSource linksBindingSource;
        private System.Windows.Forms.BindingSource linksBindingSource1;
        private linksBindingSourceTableAdapters.LinksTableAdapter linksTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkSoftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.Button vulnCheckBtn;
        private System.Windows.Forms.Button addLinkBtn;
        private System.Windows.Forms.Button editLinkBtn;
        private System.Windows.Forms.Button deleteLinkBtn;
        public System.Windows.Forms.DataGridView softwareTable;
        public System.Windows.Forms.DataGridView linksTable;
    }
}