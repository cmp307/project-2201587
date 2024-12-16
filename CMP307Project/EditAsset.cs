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
        // setup global variables and database connection
        mssql2201587Entities db = new mssql2201587Entities();
        private Asset asset;
        public EditAsset(Asset asset)
        {
            InitializeComponent();
            this.asset = asset;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        private void EditAsset_Load(object sender, EventArgs e)
        {
            sysNameTB.Text = asset.SystemName;
            modelTB.Text = asset.Model;
            manuTB.Text = asset.Manufacturer;
            typeTB.Text = asset.Type;
            if (asset.IPAddress != null)
            {
                ipTB.Text = asset.IPAddress;
            }
            if (asset.PurchaseDate != null)
            {
                datePick.Value = asset.PurchaseDate.Value;
            }
            if (asset.Notes != null)
            {
                notesTB.Text = asset.Notes;
            }
            employeeNum.Value = asset.EmployeeID;

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get updated asset details and send to database
                Asset updateAsset = (from f in db.Assets
                                     where f.AssID == asset.AssID
                                     select f).FirstOrDefault();
                if (updateAsset != null)
                {
                    updateAsset.SystemName = sysNameTB.Text;
                    updateAsset.Model = modelTB.Text;
                    updateAsset.Manufacturer = manuTB.Text;
                    updateAsset.Type = typeTB.Text;
                    updateAsset.IPAddress = ipTB.Text;
                    updateAsset.PurchaseDate = datePick.Value;
                    updateAsset.Notes = notesTB.Text;
                    // employee ID on the form is automatically set to 0. if it is 0 when the form is submitted, set employee ID to null (belongs to no employee). if there is a value other than null, add that as the employee ID
                    if (Decimal.ToInt32(employeeNum.Value) == 0)
                    {
                        throw new Exception("Asset must be assigned to employee");
                    }
                    else
                    {
                        updateAsset.EmployeeID = Decimal.ToInt32(employeeNum.Value);
                    }
                    // send updated asset to database and save changes
                    db.SaveChanges();
                    asset = updateAsset;
                    // confirmation message and hide form
                    MessageBox.Show("System updated successfully!");
                    this.Hide();
                } else
                {
                    throw new Exception("Asset not Found");
                }
            }
            catch (Exception ex)
            {
                // exception handler
                MessageBox.Show(ex.Message);
            }
        }
    }
}
