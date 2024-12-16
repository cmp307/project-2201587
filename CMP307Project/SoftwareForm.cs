using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP307Project
{
    public partial class SoftwareForm : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public SoftwareForm()
        {
            InitializeComponent();
        }

        private void loadTables()
        {
            // get data from the database and update the assets table on the form
            db = new mssql2201587Entities();
            IQueryable<Software> softwares = from f in db.Softwares select f;
            softwareTable.DataSource = softwares.ToList();
            IQueryable<Link> links = from f in db.Links select f;
            linksTable.DataSource = links.OrderBy(link => link.SoftID).ToList();
        }

        private void SoftwareForm_Load(object sender, EventArgs e)
        {
            // load data from the database as soon as the form opens
            loadTables();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // refresh table data
            loadTables();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            // close software page
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // open add software form
            AddSoftware newForm = new AddSoftware();
            newForm.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (softwareTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row
                    int softID = (int)softwareTable.SelectedRows[0].Cells["SoftID"].Value;
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (softwareTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row and confirm the user would like to delete this row
                    int softID = (int)softwareTable.SelectedRows[0].Cells["SoftID"].Value;
                    if (MessageBox.Show("Are you sure you want to delete selected row? All dependent links will be deleted. (row number: " + softID + ")", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // if user clicks confirm, find asset in the databse
                        Software software = (from f in db.Softwares
                                       where f.SoftID == softID
                                       select f).FirstOrDefault();
                        // if asset found, delete asset
                        if (software != null)
                        {
                            IQueryable<Link> links = from f in db.Links
                                         where f.SoftID == softID
                                         select f;   
                            if (links != null)
                            {
                                foreach (Link link in links)
                                {
                                    db.Links.Remove(link);
                                }
                            }
                            db.Softwares.Remove(software);
                            db.SaveChanges();
                            loadTables();
                        }
                        else
                        {
                            throw new Exception("SOftware not found");
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

        private void vulnCheckBtn_Click(object sender, EventArgs e)
        {
            if (softwareTable.SelectedRows.Count == 1)
            {
                int softID = (int)softwareTable.SelectedRows[0].Cells["SoftID"].Value;
                Software software = (from f in db.Softwares where f.SoftID == softID select f).FirstOrDefault();
                string api = @"https://services.nvd.nist.gov/rest/json/cves/2.0?";
                string url = api;
                if (software.OSname.Contains("Windows 10"))
                {
                    url += "cpeName=cpe:2.3:o:microsoft:windows_10";
                }
                else
                {
                    url += "cpeName=cpe:2.3:o:microsoft:windows_11";
                }
                string version = software.Version.Substring(2);
                url += ":" + software.Version;
                VulnerabilityCheck newForm = new VulnerabilityCheck(url);
                newForm.Show();
            }
            else
            {
                // handle exception if user selects no rows or more than one row
                MessageBox.Show("Can only use one row at a time. Please select only one row and try again.");
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
                    int softID = (int)softwareTable.SelectedRows[0].Cells["SoftID"].Value;
                    Software software = (from f in db.Softwares
                                         where f.SoftID == softID
                                         select f).FirstOrDefault();
                    // if asset found, open edit form
                    if (software != null)
                    {
                        // open edit asset form
                        AddLink newForm = new AddLink(software);
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
                    // get the ID of the row
                    int softID = (int)linksTable.SelectedRows[0].Cells["linkSoftID"].Value;
                    int assID = (int)linksTable.SelectedRows[0].Cells["AssID"].Value;
                    Link link = (from f in db.Links
                                         where f.SoftID == softID && f.AssID == assID
                                         select f).FirstOrDefault();
                    // if asset found, open edit form
                    if (link != null)
                    {
                        
                        EditLink newForm = new EditLink(link);
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
