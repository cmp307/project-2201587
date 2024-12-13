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
    public partial class AddSoftware : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public AddSoftware()
        {
            InitializeComponent();
        }
    }
}
