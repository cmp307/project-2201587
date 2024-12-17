using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP307Project
{
    public partial class EditLink : Form
    {
        // setup global variables and database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private Link link;
        private int employeeID;
        public EditLink(Link link, int employeeID = 0)
        {
            InitializeComponent();
            this.link = link;
            this.employeeID = employeeID;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close form
            this.Close();
        }

        private void EditLink_Load(object sender, EventArgs e)
        {
            // on load, fill in labels to clarify which link is being edited
            string softText = "Link for Software: ";
            softText += link.SoftID;
            softwareLbl.Text = softText;
            string assetText = "On Asset: ";
            assetText += link.AssID;
            assetLbl.Text = assetText;
            // determine if box should be checked or not according to current value
            if (link.Active == true)
            {
                activeCB.Checked = true;
            }
            else
            {
                activeCB.Checked = false;
            }

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get link to edit
                Link updateLink = (from f in db.Links where f.AssID == link.AssID && f.SoftID == link.SoftID select f).FirstOrDefault();
                // if link found
                if (updateLink != null)
                {
                    // find asset in link
                    Asset asset = (from f in db.Assets where f.AssID == updateLink.AssID select f).FirstOrDefault();
                    // if asset found
                    if (asset != null)
                    {
                        // and employee non IT
                        if (employeeID != 0)
                        {
                            // if asset does not belong to employee
                            if (asset.EmployeeID != employeeID)
                            {
                                // throw exception as employees can only edit links of assets assigned to them
                                throw new Exception("Cannot Assign link to asset assigned to other employee");
                            }
                        }
                        // get checkbox status and update attribute accordingly
                        if (activeCB.Checked == true)
                        {
                            updateLink.Active = true;
                        }
                        else
                        {
                            updateLink.Active = false;
                        }
                    }
                    else
                    {
                        // throw exception is asset not found
                        throw new Exception("Asset not found");
                    }
                }
                else
                {
                    // throw exception if link not found
                    throw new Exception("Link not found");
                }
                // update link and save database changes
                db.SaveChanges();
                link = updateLink;
                // confirmation message and hide form
                MessageBox.Show("link updated successfully!");
                this.Hide();
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }
    }
}
