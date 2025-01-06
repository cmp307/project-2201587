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
        // setup global variables and database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public int employeeID;
        public AddAsset(int employeeID = 0)
        {
            InitializeComponent();
            this.employeeID = employeeID;
        }

        // constructor for testing
        public AddAsset(mssql2201587Entities dbContext, int employeeID = 0)
        {
            InitializeComponent();
            this.employeeID = employeeID;
            this.db = dbContext;
        }

        // get data value according to attribute name given
        public string getData(string name)
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

        public void autofillBtn_Click(object sender, EventArgs e)
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

        public void addBtn_Click(object sender, EventArgs e)
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
                // check if asset has date label
                if (dateCB.Checked == true)
                {
                    // if yes, add selected date
                    newAsset.PurchaseDate = datePick.Value;
                }
                else
                {
                    // if no, set date to null
                    newAsset.PurchaseDate = null;
                }
                newAsset.Notes = notesTB.Text;
                // if called by non IT employe
                if (employeeID != 0)
                {
                    newAsset.EmployeeID = employeeID;
                }
                else
                {
                    // if called by IT employee
                    if (Decimal.ToInt32(employeeNum.Value) == 0)
                    {
                        // throw exception as an employee ID must be selected for the asset
                        throw new Exception("Asset must be assigned to employee");
                    }
                    else
                    {
                        // check that employee exists
                        Employee employee = (from f in db.Employees
                                            where f.EmployeeID == employeeID
                                            select f).FirstOrDefault();
                        if (employee != null)
                        {
                            // assign employee ID
                            newAsset.EmployeeID = Decimal.ToInt32(employeeNum.Value);
                        } 
                        else
                        {
                            throw new Exception("Employee does not exist");
                        }
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
            // set date label and picker to not visible on load
            dateLbl.Visible = false;
            datePick.Visible = false;
            // if called by non IT employee, hide employee ID label and input
            if (employeeID != 0)
            {
                employeeIDLbl.Visible = false;
                employeeNum.Visible = false;
            }
        }

        public void dateCB_CheckedChanged(object sender, EventArgs e)
        {
            // if date check box isnt checked
            if (!dateCB.Checked)
            {
                // hide date label and picker
                dateLbl.Visible = false;
                datePick.Visible = false;
            } 
            else
            {
                // if checked, show 
                dateLbl.Visible = true;
                datePick.Visible = true;
            }
        }
    }
}
