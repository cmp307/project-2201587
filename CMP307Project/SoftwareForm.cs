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

        public SoftwareForm(mssql2201587Entities dbContext)
        {
            InitializeComponent();
            this.db = dbContext;
            loadTables(db);
        }
        private void loadTables()
        {
            // get data from the database and update the assets table on the form
            db = new mssql2201587Entities();
            IQueryable<Software> softwares = from f in db.Softwares select f;
            softwareTable.DataSource = softwares.ToList();
            IQueryable<Link> links = from f in db.Links select f;
            // order links by software ID
            linksTable.DataSource = links.OrderBy(link => link.SoftID).ToList();
        }

        public void loadTables(mssql2201587Entities db)
        {
            // get data from the database and update the assets table on the form
            IQueryable<Software> softwares = from f in db.Softwares select f;
            softwareTable.DataSource = softwares.ToList();
            IQueryable<Link> links = from f in db.Links select f;
            // order links by software ID
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

        public void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (softwareTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row and confirm the user would like to delete this row
                    int softID = (int)softwareTable.SelectedRows[0].Cells["SoftID"].Value;
                    // warn that all dependent links will be deleted
                    if (MessageBox.Show("Are you sure you want to delete selected row? All dependent links will be deleted. (row number: " + softID + ")", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // if user clicks confirm, find software in the databse
                        Software software = (from f in db.Softwares
                                       where f.SoftID == softID
                                       select f).FirstOrDefault();
                        // if software found
                        if (software != null)
                        {
                            // find all links associated with software
                            IQueryable<Link> links = from f in db.Links
                                         where f.SoftID == softID
                                         select f;
                            // if links are found
                            if (links != null)
                            {
                                // remove all links
                                foreach (Link link in links)
                                {
                                    db.Links.Remove(link);
                                }
                            }
                            // remove software and save database changes
                            db.Softwares.Remove(software);
                            db.SaveChanges();
                            // refresh tables
                            loadTables();
                        }
                        else
                        {
                            // throw exception if software not found
                            throw new Exception("SOftware not found");
                        }
                    }
                    else
                    {
                        // user clicked no, do nothing
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
            // check that only one row was selected
            if (softwareTable.SelectedRows.Count == 1)
            {
                // get row ID
                int softID = (int)softwareTable.SelectedRows[0].Cells["SoftID"].Value;
                // find software 
                Software software = (from f in db.Softwares where f.SoftID == softID select f).FirstOrDefault();
                // if software found
                if (software != null)
                {
                    // setup initial api url
                    string api = @"https://services.nvd.nist.gov/rest/json/cves/2.0?";
                    string url = api;
                    // add os name to url
                    if (software.OSname.Contains("Windows 10"))
                    {
                        url += "cpeName=cpe:2.3:o:microsoft:windows_10";
                    }
                    else
                    {
                        url += "cpeName=cpe:2.3:o:microsoft:windows_11";
                    }
                    // add os version to url
                    string version = software.Version.Substring(2);
                    url += ":" + software.Version;
                    // open vulnerability check form
                    VulnerabilityCheck newForm = new VulnerabilityCheck(url);
                    newForm.Show();
                }
                else
                {
                    // throw exception if software not found
                    throw new Exception("Software not found");
                }
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
                    // find software 
                    Software software = (from f in db.Softwares
                                         where f.SoftID == softID
                                         select f).FirstOrDefault();
                    // if software found, open add link form
                    if (software != null)
                    {
                        // open add link form
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
                    // get the IDs from the row
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

        private void deleteLinkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (linksTable.SelectedRows.Count == 1)
                {
                    // get the IDs from the row
                    int softID = (int)linksTable.SelectedRows[0].Cells["linkSoftID"].Value;
                    int assID = (int)linksTable.SelectedRows[0].Cells["AssID"].Value;
                    // find link
                    Link link = (from f in db.Links
                                 where f.SoftID == softID && f.AssID == assID
                                 select f).FirstOrDefault();
                    // if link found, delete link
                    if (link != null)
                    {
                        // remove link and save database changes
                        db.Links.Remove(link);
                        db.SaveChanges();
                        // refresh tables
                        loadTables();
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
