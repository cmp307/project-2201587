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

        // constructor for testing
        public LoginForm(mssql2201587Entities dbContext)
        {
            InitializeComponent();
            this.db = dbContext;
        }

        public void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get user inputs if they are not empty
                if (emailTB.Text != null)
                {
                    string email = emailTB.Text;
                    if (passwordTB.Text != null)
                    {
                        string password = passwordTB.Text;
                        // find user in database with matching email
                        Employee employee = (from f in db.Employees
                                            where f.Email == email
                                            select f).FirstOrDefault();
                        // if employee found
                        if (employee != null)
                        {
                            // verify password
                            if (BCrypt.Net.BCrypt.Verify(password, employee.Password))
                            {
                                // login and send to menu form
                                MenuForm newForm = new MenuForm(employee);
                                // confirmation message and hide form
                                MessageBox.Show("Successful");
                                this.Hide();
                                newForm.Show();
                            } 
                            else
                            {
                                // if password doesnt match display error
                                MessageBox.Show("Wrong Credentials");
                            }

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

        public void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            // if show password checkbox is checked, show password
            if (showPassword.Checked == true)
            {
                //https://stackoverflow.com/questions/17871910/how-do-i-reset-a-passwordchar 
                passwordTB.PasswordChar = '\0';
            } 
            else
            {
                // else, use * as password character
                passwordTB.PasswordChar = '*';
            }
        }
    }
}
