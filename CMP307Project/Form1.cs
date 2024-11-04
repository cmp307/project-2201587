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
    public partial class LoginForm : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get all user profiles
                IQueryable<Employee> allEmployees = from f in db.Employees
                                                   select f;
                // get user inputs if they are not empty, admin password can be empty
                if (usernameTB.Text != null)
                {
                    string username = usernameTB.Text;
                    if (passwordTB.Text != null)
                    {
                        string password = passwordTB.Text;
                        //string adminpass = adminPass.Text;
                        // find user in database with matching username and password
                        Employee user = (from f in db.Employees
                                            where f.Email == username && f.Password == password
                                            select f).FirstOrDefault();
                        // if user found
                        if (user != null)
                        {
                            // login and send to profile with username and determine whether the user is logged in as admin or not
                            //bool admin = false;
                            /*
                            if (adminpass == "admin123")
                            {
                                admin = true;
                            }
                            */
                            //Form2 newForm = new Form2(username, admin);
                            MessageBox.Show("Successful");
                            //this.Hide();
                            //newForm.Show();

                        }
                        else
                        {
                            // if no user found, display error
                            MessageBox.Show("Wrong Credentials");
                        }
                    }
                    else
                    {
                        // handle empty password
                        MessageBox.Show("Password cannot be empty");
                    }
                }
                else
                {
                    // handle empty username
                    MessageBox.Show("username cannot be empty");
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
