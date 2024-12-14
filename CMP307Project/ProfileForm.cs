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

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linksBindingSource.Links' table. You can move, or remove it, as needed.
            this.linksTableAdapter.Fill(this.linksBindingSource.Links);
            // get data from the database and update the assets table on the form
            db = new mssql2201587Entities();
            IQueryable<Asset> assets = from f in db.Assets where f.EmployeeID == employee.EmployeeID select f;
            assetsTable.DataSource = assets.ToList();
            List<Software> softwareList = new List<Software>();
            foreach (Asset asset in assets)
            {
                Link link = (from f in db.Links where f.AssID == asset.AssID && f.Active == true select f).FirstOrDefault();
                if (link != null)
                {
                    Software software = (from f in db.Softwares where f.SoftID == link.SoftID select f).FirstOrDefault();
                    softwareList.Add(software);
                }
            }
            softwareTable.DataSource = softwareList;
        }
    }
}
