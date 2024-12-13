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
            ((System.ComponentModel.ISupportInitialize)(this.mssql2201587DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssql2201587DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(455, 338);
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
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(246, 338);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 41);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Delete Software";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(84, 338);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 41);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "Add Software";
            this.addBtn.UseVisualStyleBackColor = true;
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
            this.refreshBtn.Location = new System.Drawing.Point(374, 338);
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
            this.softwareLbl.Location = new System.Drawing.Point(245, 50);
            this.softwareLbl.Name = "softwareLbl";
            this.softwareLbl.Size = new System.Drawing.Size(143, 37);
            this.softwareLbl.TabIndex = 7;
            this.softwareLbl.Text = "Software";
            // 
            // softwareTableAdapter
            // 
            this.softwareTableAdapter.ClearBeforeFill = true;
            // 
            // SoftwareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 424);
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
        private System.Windows.Forms.DataGridView softwareTable;
        private System.Windows.Forms.Label softwareLbl;
        private softwareBindingSource softwareBindingSource;
        private System.Windows.Forms.BindingSource softwareBindingSource1;
        private softwareBindingSourceTableAdapters.SoftwareTableAdapter softwareTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn oSnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
    }
}