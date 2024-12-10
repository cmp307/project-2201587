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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (employeesTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row and confirm the user would like to delete this row
                    int empID = (int)employeesTable.SelectedRows[0].Cells["EmployeeID"].Value;
                    if (MessageBox.Show("Are you sure you want to delete selected row? (row number: " + empID + ")", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // if user clicks confirm, find employee in the databse
                        Employee emp = (from f in db.Employees
                                       where f.EmployeeID == empID
                                       select f).FirstOrDefault();
                        // if asset found, delete asset
                        if (emp != null)
                        {
                            db.Employees.Remove(emp);
                            db.SaveChanges();
                            loadTable();
                        }
                    }
                    else
                    {
                        // user clicked no
                    }
                }
                else
                {
                    // handle exception if user selects no rows or more than one row
                    MessageBox.Show("Can only delete one row at a time. Please select only one row and try again.");
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (employeesTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row
                    int empID = (int)employeesTable.SelectedRows[0].Cells["EmployeeID"].Value;
                    Employee emp = (from f in db.Employees
                                   where f.EmployeeID == empID
                                   select f).FirstOrDefault();
                    // if asset found, open edit form
                    if (emp != null)
                    {
                        // open edit asset form
                        EditAsset newForm = new EditAsset(emp);
                        newForm.Show();
                    }

                }
                else
                {
                    // handle exception if user selects no rows or more than one row
                    MessageBox.Show("Can only edit one row at a time. Please select only one row and try again.");
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }
    }
}
