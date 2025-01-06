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
    public partial class EditEmployee : Form
    {
        // setup global variables and database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private Employee employee;
        public EditEmployee(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        // constructor for testing
        public EditEmployee(mssql2201587Entities dbContext, Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            this.db = dbContext;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        public void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get employee to update
                Employee updateEmployee = (from f in db.Employees
                                     where f.EmployeeID == employee.EmployeeID
                                     select f).FirstOrDefault();
                // if employee found
                if (updateEmployee != null)
                {
                    // update attributes
                    updateEmployee.FirstName = firstNameTB.Text;
                    updateEmployee.LastName = lastNameTB.Text;
                    updateEmployee.Email = emailTB.Text;
                    updateEmployee.Password = BCrypt.Net.BCrypt.HashPassword(passwordTB.Text);
                    // department ID on the form could be set to 0
                    if (Decimal.ToInt32(departmentNum.Value) == 0)
                    {
                        // if it is 0 when the form is submitted, throw an exception as employees must be assigned to a departmnet
                        throw new Exception("Employee must have department");
                    }
                    else
                    {
                        // if there is a value other than 0, add that as the department ID
                        updateEmployee.DepartmentID = Decimal.ToInt32(departmentNum.Value);
                    }
                    // send updated employee to database and save changes
                    db.SaveChanges();
                    employee = updateEmployee;
                    // confirmation message and hide form
                    MessageBox.Show("System updated successfully!");
                    this.Hide();
                }
                else
                {
                    // throw exception if employee not found
                    throw new Exception("Employee not Found");
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }

        public void EditEmployee_Load(object sender, EventArgs e)
        {
            // autofill fields on load
            firstNameTB.Text = employee.FirstName;
            lastNameTB.Text = employee.LastName;
            emailTB.Text = employee.Email;
            passwordTB.Text = employee.Password;
            departmentNum.Value = employee.DepartmentID;
        }
    }
}
