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
            // get data from the database and update the employees table on the form
            db = new mssql2201587Entities();
            IQueryable<Employee> employees = from f in db.Employees select f;
            employeesTable.DataSource = employees.ToList();
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            // load data from the database as soon as the form opens
            loadTable();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // refresh table data
            loadTable();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            // close employees page
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // open add employee form
            AddEmployee newForm = new AddEmployee();
            newForm.Show();
        }
    }
}
