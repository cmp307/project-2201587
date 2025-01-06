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
        public EditSoftware(Software software)
        {
            InitializeComponent();
            this.software = software;
        }

        // constructor for testing
        public EditSoftware(mssql2201587Entities dbContext, Software software)
        {
            InitializeComponent();
            this.db = dbContext;
            this.software = software;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        public void EditSoftware_Load(object sender, EventArgs e)
        {
            // autofill fields
            osNameTB.Text = software.OSname;
            versionTB.Text = software.Version;
            manuTB.Text = software.manufacturer;
        }

        public void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get software asset to update
                Software updateSoftware = (from f in db.Softwares
                                     where f.SoftID == software.SoftID
                                     select f).FirstOrDefault();
                // if software found
                if (updateSoftware != null)
                {
                    // update attributes
                    updateSoftware.OSname = osNameTB.Text;
                    updateSoftware.Version = versionTB.Text;
                    updateSoftware.manufacturer = manuTB.Text;
                    // send updated asset to database and save changes
                    db.SaveChanges();
                    software = updateSoftware;
                        
                    // confirmation message and hide form
                    MessageBox.Show("System updated successfully!");
                    this.Hide();
                }
                else
                {
                    // throw exception if software not found
                    throw new Exception("Software not Found");
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
