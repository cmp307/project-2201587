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
    public partial class MenuForm : Form
    {
        // setup global variables and database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private Employee employee;
        public MenuForm(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            // close application
            System.Windows.Forms.Application.Exit();
        }

        private void assetsBtn_Click(object sender, EventArgs e)
        {
            // open assets page
            AssetsForm newForm = new AssetsForm();
            newForm.Show();
        }

        private void employeesBtn_Click(object sender, EventArgs e)
        {
            // open employees page
            EmployeesForm newForm = new EmployeesForm();
            newForm.Show();
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            // open profile page
            ProfileForm newForm = new ProfileForm(employee);
            newForm.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            // on form load
            try
            {
                // find IT department
                Department itdep = (from f in db.Departments
                                    where f.DepartmentName == "IT Support"
                                    select f).FirstOrDefault();
                // if found
                if (itdep != null)
                {
                    // and employee is not assigned to IT department
                    if (employee.DepartmentID != itdep.DepartmentID)
                    {
                        // hide IT employee only pages
                        assetsBtn.Visible = false;
                        employeesBtn.Visible = false;
                        softwareBtn.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }

        private void softwareBtn_Click(object sender, EventArgs e)
        {
            // open software page
            SoftwareForm newForm = new SoftwareForm();
            newForm.Show();
        }
    }
}
