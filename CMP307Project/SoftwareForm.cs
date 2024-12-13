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
    public partial class SoftwareForm : Form
    {
        public SoftwareForm()
        {
            InitializeComponent();
        }

        private void SoftwareForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'softwareBindingSource.Software' table. You can move, or remove it, as needed.
            this.softwareTableAdapter.Fill(this.softwareBindingSource.Software);

        }
    }
}
