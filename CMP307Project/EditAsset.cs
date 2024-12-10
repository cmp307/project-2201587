using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP307Project
{
    public partial class EditAsset : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public EditAsset()
        {
            InitializeComponent();
        }

        // get data value according to attribute name given
        private string getData(string name)
        {
            // run query to find attribute with the name given
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + name + " FROM Win32_ComputerSystem");

            // loop through searcher to find the attribute
            foreach (ManagementObject obj in searcher.Get())
            {
                // if found and has value, return value as string
                if (obj[name] != null)
                {
                    return obj[name].ToString();
                }
            }

            // if searcher isnt empty, dispose
            if (searcher != null)
            {
                searcher.Dispose();
            }
            // if attribute or value not found, return "unknown"
            return "unknown";
        }

        private void autofillBtn_Click(object sender, EventArgs e)
        {
            // autofill field values
            sysNameTB.Text = Environment.MachineName;
            modelTB.Text = getData("Model");
            manuTB.Text = getData("Manufacturer");
            typeTB.Text = getData("SystemType");
            // get ip address on network
            string ipAdd = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            // if ip not null autofill value, else fill "unavailable"
            if (ipAdd != null)
            {
                ipTB.Text = ipAdd;
            }
            else
            {
                ipTB.Text = "unavailable";
            }
        }
    }
}
