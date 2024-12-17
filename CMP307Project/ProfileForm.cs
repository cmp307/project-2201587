using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP307Project
{
    public partial class ProfileForm : Form
    {
        // setup global variables and database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private Employee employee;
        public ProfileForm(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void loadTable()
        {
            // get data from the database and update the tables on the form
            db = new mssql2201587Entities();
            // get all assets assigned to employee and add to table
            IQueryable<Asset> assets = from f in db.Assets where f.EmployeeID == employee.EmployeeID select f;
            assetsTable.DataSource = assets.ToList();
            // create links and software lists
            List<Link> links = new List<Link>();
            List<Software> softwareList = new List<Software>();
            // go through each asset
            foreach (Asset asset in assets)
            {
                // get all links associated with the asset
                IQueryable<Link> getlinks = from f in db.Links where f.AssID == asset.AssID select f;
                // if links are found
                if (getlinks != null)
                {
                    // go through each link
                    foreach (Link link in getlinks)
                    {
                        // add link to list
                        links.Add(link);
                        // get software associated with link
                        Software findSoftware = (from f in db.Softwares where f.SoftID == link.SoftID select f).FirstOrDefault();
                        // search for software in software list to see if it is already added
                        bool found = false;
                        foreach (Software software in softwareList)
                        {
                            // if found, set found to true
                            if (software.SoftID == findSoftware.SoftID)
                            {
                                found = true;
                            }
                        }
                        // if found is not true, add software to list
                        if (!found)
                        {
                            softwareList.Add(findSoftware);
                        }
                    }
                }
            }
            // add software and links to tables
            softwareTable.DataSource = softwareList.OrderBy(software => software.SoftID).ToList();
            linksTable.DataSource = links.OrderBy(link => link.SoftID).ToList();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            // load data from the database as soon as the form opens
            loadTable();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            // close profile page
            this.Close();
        }

        private void addAssetBtn_Click(object sender, EventArgs e)
        {
            // open add asset form
            AddAsset newForm = new AddAsset(employee.EmployeeID);
            newForm.Show();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // refresh tables
            loadTable();
        }

        private void addSoftBtn_Click(object sender, EventArgs e)
        {
            // open add software form
            AddSoftware newForm = new AddSoftware(employee.EmployeeID);
            newForm.Show();
        }

        private void editAssetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (assetsTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row
                    int assID = (int)assetsTable.SelectedRows[0].Cells["assetsAssID"].Value;
                    // find asset
                    Asset asset = (from f in db.Assets
                                   where f.AssID == assID
                                   select f).FirstOrDefault();
                    // if asset found, open edit form
                    if (asset != null)
                    {
                        // open edit asset form
                        EditAsset newForm = new EditAsset(asset, employee.EmployeeID);
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

        private void editSoftBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (softwareTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row
                    int softID = (int)softwareTable.SelectedRows[0].Cells["softwareSoftID"].Value;
                    // find software
                    Software software = (from f in db.Softwares
                                         where f.SoftID == softID
                                         select f).FirstOrDefault();
                    // if software found, open edit form
                    if (software != null)
                    {
                        // open edit software form
                        EditSoftware newForm = new EditSoftware(software);
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

        private void addLinkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (softwareTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row
                    int softID = (int)softwareTable.SelectedRows[0].Cells["softwareSoftID"].Value;
                    // find software
                    Software software = (from f in db.Softwares
                                         where f.SoftID == softID
                                         select f).FirstOrDefault();
                    // if software found
                    if (software != null)
                    {
                        // open add link form
                        AddLink newForm = new AddLink(software, employee.EmployeeID);
                        newForm.Show();
                    }
                }
                else
                {
                    // handle exception if user selects no rows or more than one row
                    MessageBox.Show("Can only use one row at a time. Please select only one row and try again.");
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }            
        }

        private void editLinkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (linksTable.SelectedRows.Count == 1)
                {
                    // get the IDs from the selected row
                    int softID = (int)linksTable.SelectedRows[0].Cells["linkSoftID"].Value;
                    int assID = (int)linksTable.SelectedRows[0].Cells["AssID"].Value;
                    // find link
                    Link link = (from f in db.Links
                                 where f.SoftID == softID && f.AssID == assID
                                 select f).FirstOrDefault();
                    // if link found, open edit link form
                    if (link != null)
                    {
                        // open edit link form
                        EditLink newForm = new EditLink(link, employee.EmployeeID);
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
    }
}
