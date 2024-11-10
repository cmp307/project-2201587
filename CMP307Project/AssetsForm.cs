using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CMP307Project
{
    public partial class AssetsForm : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public AssetsForm()
        {
            InitializeComponent();
        }

        private void loadTable()
        {
            IQueryable<Asset> assets = from f in db.Assets select f;
            assetsTable.DataSource = assets.ToList();
        }

        private void AssetsForm_Load(object sender, EventArgs e)
        {
            loadTable();

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddAsset newForm = new AddAsset();
            newForm.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            EditAsset newForm = new EditAsset();
            newForm.Show();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (assetsTable.SelectedRows.Count == 1)
                {
                    int assID = (int)assetsTable.SelectedRows[0].Cells["AssID"].Value;
                    if (MessageBox.Show("Are you sure you want to delete selected row? (row number: " + assID + ")", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        Asset asset = (from f in db.Assets
                                        where f.AssID == assID
                                        select f).FirstOrDefault();
                        if (asset != null)
                        {
                            db.Assets.Remove(asset);
                            db.SaveChanges();
                            loadTable();
                        }
                    }
                    else
                    {
                        // user clicked no
                    }
                }
                else
                {
                    MessageBox.Show("Can only delete one row at a time. Please select only one row and try again.");
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }
    }
}
