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
    public partial class AddSoftware : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private int employeeID; 
        public AddSoftware(int employeeID = 0)
        {
            InitializeComponent();
            this.employeeID = employeeID;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        // get data value according to attribute name given
        private string getData(string name)
        {
            // run query to find attribute with the name given
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + name + " FROM Win32_OperatingSystem");

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
            osNameTB.Text = getData("Caption");
            versionTB.Text = getData("Version");
            manuTB.Text = getData("Manufacturer");
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get new asset details and send to database
                Software newSoft = new Software();
                newSoft.OSname = osNameTB.Text;
                newSoft.Version = versionTB.Text;
                newSoft.manufacturer = manuTB.Text;
                
                Link newLink = new Link();
                if (Decimal.ToInt32(assetNum.Value) == 0)
                {
                    throw new Exception("Software must have asset");
                }
                else if (employeeID != 0)
                {
                    IQueryable<Asset> assets = from f in db.Assets where f.EmployeeID == employeeID select f;
                    bool found = false;
                    foreach (Asset asset in assets)
                    {
                        if (Decimal.ToInt32(assetNum.Value) == asset.AssID)
                        {
                            found = true;
                            newLink.AssID = Decimal.ToInt32(assetNum.Value);
                        }
                    }
                    if (!found)
                    {
                        throw new Exception("Cannot assign software to asset asigned to other users");
                    }
                }
                else
                {
                    newLink.AssID = Decimal.ToInt32(assetNum.Value);
                }
                // send new spftware to database and save changes
                db.Softwares.Add(newSoft);
                db.SaveChanges();

                newLink.SoftID = newSoft.SoftID;
                newLink.Date = DateTime.Now;
                newLink.Active = true;
                db.Links.Add(newLink);
                db.SaveChanges();
                
                IQueryable<Link> links = from f in db.Links select f;
                foreach (Link link in links)
                {
                    if (link.AssID == newLink.AssID && link.SoftID != newLink.SoftID)
                    {
                        link.Active = false;
                    }
                }
                db.SaveChanges();
                // confirmation message and hide form
                MessageBox.Show("Software added successfully!");
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
