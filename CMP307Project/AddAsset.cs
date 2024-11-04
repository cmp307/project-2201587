using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace CMP307Project
{
    public partial class AddAsset : Form
    {
        public AddAsset()
        {
            InitializeComponent();
        }

        private string getData(string name)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + name + " FROM Win32_ComputerSystem");
            
            foreach (ManagementObject obj in searcher.Get())
            {
                if (obj[name] != null)
                {
                    return obj[name].ToString();
                }
            }
            return "unknown";
        }

        private void autofillBtn_Click(object sender, EventArgs e)
        {
            sysNameTB.Text = Environment.MachineName;
            modelTB.Text = getData("Model");
            manuTB.Text = getData("Manufacturer");
            typeTB.Text = getData("SystemType");

        }
    }
}
