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
                        Software software = (from f in db.Softwares where f.SoftID == link.SoftID select f).FirstOrDefault();
                        softwareList.Add(software);
                    }
                }
            }
            softwareTable.DataSource = softwareList;
            linksTable.DataSource = links;
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
            AddSoftware newForm = new AddSoftware();
            newForm.Show();
        }
    }
}
