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
            // TODO: This line of code loads data into the 'softwareBindingSource.Software' table. You can move, or remove it, as needed.
            this.softwareTableAdapter.Fill(this.softwareBindingSource.Software);
            // TODO: This line of code loads data into the 'assetBindingSource.Asset' table. You can move, or remove it, as needed.
            this.assetTableAdapter.Fill(this.assetBindingSource.Asset);

        }
    }
}
