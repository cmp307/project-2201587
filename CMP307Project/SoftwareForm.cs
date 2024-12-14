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
    }
}
