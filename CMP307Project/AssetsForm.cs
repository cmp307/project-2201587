using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CMP307Project
{
    public partial class AssetsForm : Form
    {
        // setup database connection
        mssql2201587Entities db = new mssql2201587Entities();
        public AssetsForm()
        {
            InitializeComponent();
        }

        private void loadTable()
        {
            IQueryable<Asset> assets = from f in db.Assets select f;
            assetsTable.DataSource = assets.ToList();
        }

        private void AssetsForm_Load(object sender, EventArgs e)
        {
            loadTable();

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddAsset newForm = new AddAsset();
            newForm.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            EditAsset newForm = new EditAsset();
            newForm.Show();
        }
    }
}
