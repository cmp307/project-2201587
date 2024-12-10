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
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private Employee employee;
        public EditEmployee(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get updated employee details and send to database
                Employee updateEmployee = (from f in db.Employees
                                     where f.EmployeeID == employee.EmployeeID
                                     select f).FirstOrDefault();
                if (updateEmployee != null)
                {
                    updateEmployee.FirstName = firstNameTB.Text;
                    updateEmployee.LastName = lastNameTB.Text;
                    updateEmployee.Email = emailTB.Text;
                    updateEmployee.Password = passwordTB.Text;
                    // department ID on the form is automatically set to 0. if it is 0 when the form is submitted, throw an exception as employees must be assigned to a departmnet. if there is a value other than 0, add that as the department ID
                    if (Decimal.ToInt32(departmentNum.Value) == 0)
                    {
                        throw new Exception("Employee must have department");
                    }
                    else
                    {
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
                    throw new Exception("Employee not Found");
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            firstNameTB.Text = employee.FirstName;
            lastNameTB.Text = employee.LastName;
            emailTB.Text = employee.Email;
            passwordTB.Text = employee.Password;
            departmentNum.Value = employee.DepartmentID.Value;
        }
    }
}
