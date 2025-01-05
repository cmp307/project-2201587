using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;

namespace CMP307ProjectTests
{
    [TestClass]
    public class EditAssetTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Asset>> mockAsset;
        private EditAsset editAssetForm;
        private Asset testAsset;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockAsset = new Mock<DbSet<Asset>>();

            // Create a test asset
            testAsset = new Asset
            {
                AssID = 1,
                SystemName = "OriginalPC",
                Model = "OriginalModel",
                Manufacturer = "OriginalManufacturer",
                Type = "Desktop",
                IPAddress = "192.168.1.1",
                EmployeeID = 1,
                Notes = "Original Notes"
            };

            // Setup mock database operations
            var queryable = new[] { testAsset }.AsQueryable();
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            mockDB.Setup(m => m.Assets).Returns(mockAsset.Object);

            // Initialize form with test asset
            editAssetForm = new EditAsset(mockDB.Object, testAsset);
        }

        [TestMethod]
        public void EditAsset_WithValidData_ShouldUpdateDatabase()
        {
            // Arrange
            editAssetForm.sysNameTB.Text = "UpdatedPC";
            editAssetForm.modelTB.Text = "UpdatedModel";
            editAssetForm.manuTB.Text = "UpdatedManufacturer";
            editAssetForm.typeTB.Text = "Laptop";
            editAssetForm.ipTB.Text = "192.168.1.2";
            editAssetForm.employeeNum.Value = 2;
            editAssetForm.notesTB.Text = "Updated Notes";

            // Act
            editAssetForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Once);
            Assert.AreEqual("UpdatedPC", testAsset.SystemName);
            Assert.AreEqual("UpdatedModel", testAsset.Model);
            Assert.AreEqual("UpdatedManufacturer", testAsset.Manufacturer);
            Assert.AreEqual("Laptop", testAsset.Type);
            Assert.AreEqual("192.168.1.2", testAsset.IPAddress);
            Assert.AreEqual(2, testAsset.EmployeeID);
            Assert.AreEqual("Updated Notes", testAsset.Notes);
        }

        [TestMethod]
        public void EditAsset_WithNoEmployeeID_ShouldNotSaveToDatabase()
        {
            // Arrange
            editAssetForm.employeeNum.Value = 0;

            // Act
            editAssetForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Never,
                "SaveChanges should not be called when employee ID is 0");
        }

        [TestMethod]
        public void EditAsset_WithNonITEmployee_ShouldHideEmployeeIDFields()
        {
            // Arrange
            const int nonITEmployeeID = 2;
            var editForm = new EditAsset(testAsset, nonITEmployeeID);

            // Act
            editForm.EditAsset_Load(null, EventArgs.Empty);

            // Assert
            Assert.IsFalse(editForm.employeeIDLbl.Visible);
            Assert.IsFalse(editForm.employeeNum.Visible);
        }

        [TestMethod]
        public void EditAsset_WithPurchaseDate_ShouldUpdateDateCorrectly()
        {
            // Arrange
            var testDate = new DateTime(2024, 1, 1);
            editAssetForm.dateCB.Checked = true;
            editAssetForm.datePick.Value = testDate;
            editAssetForm.employeeNum.Value = 1;

            // Act
            editAssetForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            var updatedAsset = mockDB.Object.Assets.FirstOrDefault(a => a.AssID == testAsset.AssID);
            Assert.IsNotNull(updatedAsset);
            Assert.AreEqual(testDate, updatedAsset.PurchaseDate);
            mockDB.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void EditAsset_LoadExistingAsset_ShouldPopulateFieldsCorrectly()
        {
            // Act
            editAssetForm.EditAsset_Load(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual("OriginalPC", editAssetForm.sysNameTB.Text);
            Assert.AreEqual("OriginalModel", editAssetForm.modelTB.Text);
            Assert.AreEqual("OriginalManufacturer", editAssetForm.manuTB.Text);
            Assert.AreEqual("Desktop", editAssetForm.typeTB.Text);
            Assert.AreEqual("192.168.1.1", editAssetForm.ipTB.Text);
            Assert.AreEqual(1, editAssetForm.employeeNum.Value);
            Assert.AreEqual("Original Notes", editAssetForm.notesTB.Text);
        }
    }
}