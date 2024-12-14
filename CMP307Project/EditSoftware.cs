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
    public partial class EditSoftware : Form
    {
        // setup global variables and database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private Software software;
        private Link link;
        public EditSoftware(Software software, Link link)
        {
            InitializeComponent();
            this.software = software;
            this.link = link;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        private void EditSoftware_Load(object sender, EventArgs e)
        {
            osNameTB.Text = software.OSname;
            versionTB.Text = software.Version;
            manuTB.Text = software.manufacturer;
            assetNum.Value = link.AssID;
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
                // get updated asset details and send to database
                Software updateSoftware = (from f in db.Softwares
                                     where f.SoftID == software.SoftID
                                     select f).FirstOrDefault();
                if (updateSoftware != null)
                {
                    updateSoftware.OSname = osNameTB.Text;
                    updateSoftware.Version = versionTB.Text;
                    updateSoftware.manufacturer = manuTB.Text;

                    Link updateLink = (from f in db.Links
                                 where f.SoftID == software.SoftID
                                 select f).FirstOrDefault();
                    if (updateLink != null)
                    {
                        if (activeCB.Checked == true)
                        {
                            updateLink.Active = true;
                        }
                        else
                        {
                            updateLink.Active = false;
                        }
                        // comment
                        //if (Decimal.ToInt32(assetNum.Value) == 0)
                        //{
                        //    throw new Exception("Software must belong to asset");
                        //}
                        //else
                        //{
                        //    updateLink.AssID = Decimal.ToInt32(assetNum.Value);
                        //}
                        // send updated asset to database and save changes
                        db.SaveChanges();
                        software = updateSoftware;
                        link = updateLink;
                        // confirmation message and hide form
                        MessageBox.Show("System updated successfully!");
                        this.Hide();
                    }
                }
                else
                {
                    throw new Exception("Asset not Found");
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
