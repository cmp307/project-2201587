using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

        public EmployeesForm(mssql2201587Entities dbContext)
        {
            InitializeComponent();
            this.db = dbContext;
            loadTable(db);
        }

        private void loadTable()
        {
            // get data from the database and update the employees table on the form
            db = new mssql2201587Entities();
            IQueryable<Employee> employees = from f in db.Employees select f;
            employeesTable.DataSource = employees.ToList();
        }

        public void loadTable(mssql2201587Entities db)
        {
            // get data from the database and update the employees table on the form
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

        public void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // check if only one row has been selected
                if (employeesTable.SelectedRows.Count == 1)
                {
                    // get the ID of the row and confirm the user would like to delete this row
                    int empID = (int)employeesTable.SelectedRows[0].Cells["EmployeeID"].Value;
                    // warn that dependent links and assets will be deleted
                    if (MessageBox.Show("Are you sure you want to delete selected row? All dependent Assets and Links will be deleted. (row number: " + empID + ")", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // if user clicks confirm, find employee in the databse
                        Employee emp = (from f in db.Employees
                                       where f.EmployeeID == empID
                                       select f).FirstOrDefault();
                        // if employee found
                        if (emp != null)
                        {
                            // find all assets assigned to employee
                            IQueryable<Asset> assets = from f in db.Assets
                                                       where f.EmployeeID == emp.EmployeeID
                                                       select f;
                            // if any assets are found
                            if (assets != null)
                            {
                                foreach (Asset asset in assets)
                                {
                                    // find all links of each asset
                                    IQueryable<Link> links = from f in db.Links
                                                             where f.AssID == asset.AssID
                                                             select f;
                                    // if any links are found, remove all
                                    if (links != null)
                                    {
                                        foreach (Link link in links)
                                        {
                                            db.Links.Remove(link);
                                        }
                                    }
                                    // remove asset
                                    db.Assets.Remove(asset);
                                }
                            }
                            // remove employee and save database changes
                            db.Employees.Remove(emp);
                            db.SaveChanges();
                            // refresh table
                            loadTable();
                        }
                    }
                    else
                    {
                        // user clicked no, do nothing
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
                    // find employee
                    Employee emp = (from f in db.Employees
                                   where f.EmployeeID == empID
                                   select f).FirstOrDefault();
                    // if employee found, open edit form
                    if (emp != null)
                    {
                        // open edit employee form
                        EditEmployee newForm = new EditEmployee(emp);
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
