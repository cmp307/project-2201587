using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        mssql2201587Entities db = new mssql2201587Entities();
        private Link link;
        public EditLink(Link link)
        {
            InitializeComponent();
            this.link = link;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditLink_Load(object sender, EventArgs e)
        {
            string softText = "Link for Software: ";
            softText += link.SoftID;
            softwareLbl.Text = softText;
            string assetText = "On Asset: ";
            assetText += link.AssID;
            assetLbl.Text = assetText;
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
                Link updateLink = (from f in db.Links where f.AssID == link.AssID && f.SoftID == link.SoftID select f).FirstOrDefault();
                if (updateLink != null)
                {
                    if (activeCB.Checked == true)
                    {
                        link.Active = true;
                    }
                    else
                    {
                        link.Active = false;
                    }
                }
                else
                {
                    throw new Exception("Link not found");
                }
                db.SaveChanges();
                link = updateLink;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
