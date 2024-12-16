using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
            // get data from the database and update the assets table on the form
            db = new mssql2201587Entities();
            IQueryable<Asset> assets = from f in db.Assets select f;
            assetsTable.DataSource = assets.ToList();
        }

        private void AssetsForm_Load(object sender, EventArgs e)
        {
            // load data from the database as soon as the form opens
            loadTable();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // refresh table data
            loadTable();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // open add asset form
            AddAsset newForm = new AddAsset();
            newForm.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (assetsTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row
                    int assID = (int)assetsTable.SelectedRows[0].Cells["AssID"].Value;
                    Asset asset = (from f in db.Assets
                                    where f.AssID == assID
                                    select f).FirstOrDefault();
                    // if asset found, open edit form
                    if (asset != null)
                    {
                        // open edit asset form
                        EditAsset newForm = new EditAsset(asset);
                        newForm.Show();
                    }
                    
                }
                else
                {
                    // handle exception if user selects no rows or more than one row
                    MessageBox.Show("Can only edit one row at a time. Please select only one row and try again.");
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            // close asset page
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (assetsTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row and confirm the user would like to delete this row
                    int assID = (int)assetsTable.SelectedRows[0].Cells["AssID"].Value;
                    if (MessageBox.Show("Are you sure you want to delete selected row? All dependent links will be deleted. (row number: " + assID + ")", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // if user clicks confirm, find asset in the databse
                        Asset asset = (from f in db.Assets
                                        where f.AssID == assID
                                        select f).FirstOrDefault();
                        // if asset found, delete asset
                        if (asset != null)
                        {
                            IQueryable<Link> links = from f in db.Links
                                                     where f.AssID == assID
                                                     select f;
                            if (links != null)
                            {
                                foreach (Link link in links)
                                {
                                    db.Links.Remove(link);
                                }
                            }
                            db.Assets.Remove(asset);
                            db.SaveChanges();
                            loadTable();
                        }
                        else
                        {
                            throw new Exception("Asset not found");
                        }
                    }
                    else
                    {
                        // user clicked no
                    }
                }
                else
                {
                    // handle exception if user selects no rows or more than one row
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
