using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP307Project
{
    public partial class AddLink : Form
    {
        // setup global variables and database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private Software software;
        private int employeeID;
        public AddLink(Software software, int employeeID = 0)
        {
            InitializeComponent();
            this.software = software;
            this.employeeID = employeeID;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // make sure an asset number is entered
                if (Decimal.ToInt32(assetNum.Value) != 0)
                {
                    // check that asset with this ID exists
                    Asset asset = (from f in db.Assets where f.AssID == assetNum.Value select f).FirstOrDefault();
                    if (asset != null)
                    {
                        // if true, and this employee is not IT, and the selected asset doesnt belong to them
                        if (employeeID != 0 && asset.EmployeeID != employeeID)
                        {
                            // throw exception as non IT employees cannot assign software to assets not assigned to them
                            throw new Exception("Cannot link software to asset assgined to other employee");
                        }
                        else
                        {
                            // if the employee is either IT or the asset belongs to them, check that link doesnt already exists
                            Link link = (from f in db.Links where f.AssID == assetNum.Value && f.SoftID == software.SoftID select f).FirstOrDefault();
                            // if link doesnt exist
                            if (link == null)
                            {
                                // create new link
                                Link newLink = new Link();
                                newLink.AssID = Decimal.ToInt32(assetNum.Value);
                                newLink.SoftID = software.SoftID;
                                // add current date
                                newLink.Date = DateTime.Now;
                                // check if link is marked as active
                                if (activeCB.Checked == true)
                                {
                                    newLink.Active = true;
                                }
                                else
                                {
                                    newLink.Active = false;
                                }
                                // send link to database and save changes
                                db.Links.Add(newLink);
                                db.SaveChanges();
                                // if the new link is active
                                if (newLink.Active == true)
                                {
                                    // find all previous links of softwares on this hardware
                                    IQueryable<Link> links = from f in db.Links where f.AssID == newLink.AssID select f;
                                    // set each old link to inactive
                                    foreach (Link oldlink in links)
                                    {
                                        if (oldlink.SoftID != newLink.SoftID)
                                        {
                                            oldlink.Active = false;
                                        }
                                    }
                                    // save database changes
                                    db.SaveChanges();
                                }
                                // confirmation message and hide form
                                MessageBox.Show("Link added Successfully!");
                                this.Hide();
                            }
                            else
                            {
                                // throw exception if link already exists
                                throw new Exception("link already exists");
                            }
                        }
                    }
                    else
                    {
                        // throw exception if asset isnt found
                        throw new Exception("Asset not found");
                    }
                }
                else
                {
                    // throw exception if an asset isnt selected
                    throw new Exception("Link must have asset");
                }
            }
            catch (Exception ex)
            {
                // handle exceptions
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddLink_Load(object sender, EventArgs e)
        {
            softwareLbl.Text = "Link for Software: " + software.SoftID;
        }
    }
}
