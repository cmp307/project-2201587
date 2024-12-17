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
using System.Net;

namespace CMP307Project
{
    public partial class AddAsset : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private int employeeID;
        public AddAsset(int employeeID = 0)
        {
            InitializeComponent();
            this.employeeID = employeeID;
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
                if (employeeID != 0)
                {
                    newAsset.EmployeeID = employeeID;
                }
                else
                {
                    if (Decimal.ToInt32(employeeNum.Value) == 0)
                    {
                        throw new Exception("Asset must be assigned to employee");
                    }
                    else
                    {
                        newAsset.EmployeeID = Decimal.ToInt32(employeeNum.Value);
                    }
                }
                // send new asset to database and save changes
                db.Assets.Add(newAsset);
                db.SaveChanges();
                // confirmation message and hide form
                MessageBox.Show("System added successfully!");
                this.Hide();
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        private void AddAsset_Load(object sender, EventArgs e)
        {
            dateLbl.Visible = false;
            datePick.Visible = false;
            if (employeeID != 0)
            {
                employeeIDLbl.Visible = false;
                employeeNum.Visible = false;
            }
        }

        private void dateCB_CheckedChanged(object sender, EventArgs e)
        {
            if (!dateCB.Checked)
            {
                dateLbl.Visible = false;
                datePick.Visible = false;
            } 
            else
            {
                dateLbl.Visible = true;
                datePick.Visible = true;
            }
        }
    }
}
