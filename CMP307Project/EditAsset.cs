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
        private int employeeID;
        public EditAsset(Asset asset, int employeeID = 0)
        {
            InitializeComponent();
            this.asset = asset;
            this.employeeID = employeeID;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // close add page
            this.Close();
        }

        private void EditAsset_Load(object sender, EventArgs e)
        {
            // autofill fields on form load
            sysNameTB.Text = asset.SystemName;
            modelTB.Text = asset.Model;
            manuTB.Text = asset.Manufacturer;
            typeTB.Text = asset.Type;
            // fill in values of fields if they arent null
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
            // fill in assigned employee ID
            employeeNum.Value = asset.EmployeeID;
            // if editing employee not IT, hide employee ID and input to prevent changes
            if (employeeID != 0)
            {
                employeeIDLbl.Visible = false;
                employeeNum.Visible = false;
            }

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // get asset to update
                Asset updateAsset = (from f in db.Assets
                                     where f.AssID == asset.AssID
                                     select f).FirstOrDefault();
                // if asset found
                if (updateAsset != null)
                {
                    // update attributes
                    updateAsset.SystemName = sysNameTB.Text;
                    updateAsset.Model = modelTB.Text;
                    updateAsset.Manufacturer = manuTB.Text;
                    updateAsset.Type = typeTB.Text;
                    updateAsset.IPAddress = ipTB.Text;
                    updateAsset.PurchaseDate = datePick.Value;
                    updateAsset.Notes = notesTB.Text;
                    // employee ID on the form is could be set to 0
                    if (Decimal.ToInt32(employeeNum.Value) == 0)
                    {
                        // if it is 0 when the form is submitted, throw exception as asset must be assigned to employee
                        throw new Exception("Asset must be assigned to employee");
                    }
                    else
                    {
                        // if there is a value other than 0, add that as the employee ID
                        updateAsset.EmployeeID = Decimal.ToInt32(employeeNum.Value);
                    }
                    // send updated asset to database and save changes
                    db.SaveChanges();
                    asset = updateAsset;
                    // confirmation message and hide form
                    MessageBox.Show("System updated successfully!");
                    this.Hide();
                } 
                else
                {
                    // throw exception is asset not found
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
