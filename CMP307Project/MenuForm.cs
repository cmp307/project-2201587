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
    public partial class MenuForm : Form
    {
        string username;
        public MenuForm(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void assetsBtn_Click(object sender, EventArgs e)
        {
            AssetsForm newForm = new AssetsForm();
            MessageBox.Show("Successful");
            newForm.Show();
        }

        private void employeesBtn_Click(object sender, EventArgs e)
        {
            EmployeesForm newForm = new EmployeesForm();
            MessageBox.Show("Successful");
            newForm.Show();
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            ProfileForm newForm = new ProfileForm(username);
            MessageBox.Show("Successful");
            newForm.Show();
        }
    }
}
