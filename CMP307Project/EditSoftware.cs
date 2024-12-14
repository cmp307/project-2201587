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
    }
}
