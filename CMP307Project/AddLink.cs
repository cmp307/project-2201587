﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP307Project
{
    public partial class AddLink : Form
    {
        mssql2201587Entities db = new mssql2201587Entities();
        private Software software;
        private int employeeID;
        public AddLink(Software software, int employeeID = 0)
        {
            InitializeComponent();
            this.software = software;
            this.employeeID = employeeID;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Decimal.ToInt32(assetNum.Value) != 0)
                {
                    Asset asset = (from f in db.Assets where f.AssID == assetNum.Value select f).FirstOrDefault();
                    if (asset != null)
                    {
                        if (employeeID != 0 && asset.EmployeeID != employeeID)
                        {
                            throw new Exception("Cannot link software to asset assgined to other employee");
                        }
                        else
                        {
                            Link link = (from f in db.Links where f.AssID == assetNum.Value && f.SoftID == software.SoftID select f).FirstOrDefault();
                            if (link == null)
                            {
                                Link newLink = new Link();
                                newLink.AssID = Decimal.ToInt32(assetNum.Value);
                                newLink.SoftID = software.SoftID;
                                newLink.Date = DateTime.Now;
                                if (activeCB.Checked == true)
                                {
                                    newLink.Active = true;
                                }
                                else
                                {
                                    newLink.Active = false;
                                }
                                db.Links.Add(newLink);
                                db.SaveChanges();
                                if (newLink.Active == true)
                                {
                                    IQueryable<Link> links = from f in db.Links where f.AssID == newLink.AssID select f;
                                    foreach (Link oldlink in links)
                                    {
                                        if (oldlink.SoftID != newLink.SoftID)
                                        {
                                            oldlink.Active = false;
                                        }
                                    }
                                    db.SaveChanges();
                                }
                                MessageBox.Show("Link added Successfully!");
                                this.Hide();
                            }
                            else
                            {
                                throw new Exception("link already exists");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Asset not found");
                    }
                }
                else
                {
                    throw new Exception("Link must have asset");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddLink_Load(object sender, EventArgs e)
        {
            softwareLbl.Text = "Link for Software: " + software.SoftID;
        }
    }
}
