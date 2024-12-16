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
            // get data from the database and update the assets table on the form
            db = new mssql2201587Entities();
            IQueryable<Asset> assets = from f in db.Assets where f.EmployeeID == employee.EmployeeID select f;
            assetsTable.DataSource = assets.ToList();
            List<Link> links = new List<Link>();
            List<Software> softwareList = new List<Software>();
            foreach (Asset asset in assets)
            {
                IQueryable<Link> getlinks = from f in db.Links where f.AssID == asset.AssID select f;
                if (getlinks != null)
                {
                    foreach (Link link in getlinks)
                    {
                        links.Add(link);
                        Software findSoftware = (from f in db.Softwares where f.SoftID == link.SoftID select f).FirstOrDefault();
                        bool found = false;
                        foreach (Software software in softwareList)
                        {
                            if (software.SoftID == findSoftware.SoftID)
                            {
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            softwareList.Add(findSoftware);
                        }
                    }
                }
            }
            softwareTable.DataSource = softwareList.OrderBy(software => software.SoftID).ToList();
            linksTable.DataSource = links.OrderBy(link => link.SoftID).ToList();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
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
            loadTable();
        }

        private void addSoftBtn_Click(object sender, EventArgs e)
        {
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
                    Software software = (from f in db.Softwares
                                         where f.SoftID == softID
                                         select f).FirstOrDefault();
                    // if asset found, open edit form
                    if (software != null)
                    {
                        Link link = (from f in db.Links
                                     where f.SoftID == softID
                                     select f).FirstOrDefault();
                        if (link != null)
                        {
                            // open edit asset form
                            EditSoftware newForm = new EditSoftware(software);
                            newForm.Show();
                        }
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
                    Software software = (from f in db.Softwares
                                         where f.SoftID == softID
                                         select f).FirstOrDefault();
                    // if asset found, open edit form
                    if (software != null)
                    {
                        Link link = (from f in db.Links
                                     where f.SoftID == softID
                                     select f).FirstOrDefault();
                        if (link != null)
                        {
                            // open edit asset form
                            AddLink newForm = new AddLink(software, employee.EmployeeID);
                            newForm.Show();
                        }
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
                    // get the ID of the row
                    int softID = (int)linksTable.SelectedRows[0].Cells["linkSoftID"].Value;
                    int assID = (int)linksTable.SelectedRows[0].Cells["AssID"].Value;
                    Link link = (from f in db.Links
                                 where f.SoftID == softID && f.AssID == assID
                                 select f).FirstOrDefault();
                    // if asset found, open edit form
                    if (link != null)
                    {

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
