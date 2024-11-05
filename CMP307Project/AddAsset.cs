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
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
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

            if (searcher != null)
            {
                searcher.Dispose();
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get new asset details and send to database
                Asset newAsset = new Asset();
                newAsset.SystemName = sysNameTB.Text;
                newAsset.Model = modelTB.Text;
                newAsset.Manufacturer = manuTB.Text;
                newAsset.Type = typeTB.Text;
                newAsset.IPAddress = ipTB.Text;
                newAsset.PurchaseDate = datePick.Value;
                newAsset.Notes = notesTB.Text;
                if (Decimal.ToInt32(employeeNum.Value) == 0 ) 
                {
                    newAsset.EmployeeID = null;
                }
                else
                {
                    newAsset.EmployeeID = Decimal.ToInt32(employeeNum.Value);
                }
                db.Assets.Add(newAsset);
                db.SaveChanges();

                MessageBox.Show("System added successfully!");
                this.Hide();
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }
    }
}
