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
    public partial class EmployeesForm : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public EmployeesForm()
        {
            InitializeComponent();
        }

        private void loadTable()
        {
            // get data from the database and update the assets table on the form
            db = new mssql2201587Entities();
            IQueryable<Employee> employees = from f in db.Employees select f;
            employeesTable.DataSource = employees.ToList();
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            loadTable();
        }



    }
}
