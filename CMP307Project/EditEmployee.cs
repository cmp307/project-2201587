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
    }
}
