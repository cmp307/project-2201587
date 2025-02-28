﻿using System;
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
    public partial class AddEmployee : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public AddEmployee()
        {
            InitializeComponent();
        }

        // constructor for testing
        public AddEmployee(mssql2201587Entities dbContext)
        {
            InitializeComponent();
            this.db = dbContext;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        public void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get new employee details to send to database
                Employee newEmp = new Employee();
                newEmp.FirstName = firstNameTB.Text;
                newEmp.LastName = lastNameTB.Text;
                newEmp.Email = emailTB.Text;
                // hash password
                newEmp.Password = BCrypt.Net.BCrypt.HashPassword(passwordTB.Text);
                // department ID on the form is automatically set to 0
                if (Decimal.ToInt32(departmentNum.Value) == 0)
                {
                    // if it is 0 when the form is submitted, throw an exception as employees must be assigned to a departmnet
                    throw new Exception("Employee must have department");
                }
                else
                {
                    // if there is a value other than 0, add that as the department ID
                    newEmp.DepartmentID = Decimal.ToInt32(departmentNum.Value);
                }
                // send new employee to database and save changes
                db.Employees.Add(newEmp);
                db.SaveChanges();
                // confirmation message and hide form
                MessageBox.Show("Employee added successfully!");
                this.Hide();
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }
    }
}
