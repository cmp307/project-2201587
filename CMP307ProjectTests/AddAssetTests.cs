using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;

namespace CMP307ProjectTests
{
    [TestClass]
    public class AddAssetTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Asset>> mockAsset;
        private AddAsset addAssetForm;

        [TestInitialize]
        public void Setup()
        {
            mockDB = new Mock<mssql2201587Entities>();
            mockAsset = new Mock<DbSet<Asset>>();
            mockDB.Setup(m => m.Assets).Returns(mockAsset.Object);
            addAssetForm = new AddAsset(mockDB.Object);
        }

        [TestMethod]
        public void AddAsset_WithNoEmployeeID_ShouldNotSaveToDatabase()
        {
            // Arrange
            addAssetForm.sysNameTB.Text = "TestPC";
            addAssetForm.employeeNum.Value = 0;

            // Act
            addAssetForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Never(),
                "SaveChanges should not be called when employee ID is 0");
            mockDB.Verify(m => m.Assets.Add(It.IsAny<Asset>()), Times.Never(),
                "Add should not be called when employee ID is 0");
        }

        [TestMethod]
        public void AddAsset_WithValidData_ShouldSaveToDatabase()
        {
            // Arrange
            addAssetForm.sysNameTB.Text = "TestPC";
            addAssetForm.modelTB.Text = "TestModel";
            addAssetForm.manuTB.Text = "TestManufacturer";
            addAssetForm.typeTB.Text = "Desktop";
            addAssetForm.ipTB.Text = "192.168.1.1";
            addAssetForm.employeeNum.Value = 1;
            addAssetForm.notesTB.Text = "Test Notes";

            Asset savedAsset = null;
            mockAsset.Setup(m => m.Add(It.IsAny<Asset>()))
                .Callback<Asset>(asset => savedAsset = asset);

            // Act
            addAssetForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedAsset, "Asset should be saved");
            Assert.AreEqual("TestPC", savedAsset.SystemName);
            Assert.AreEqual("TestModel", savedAsset.Model);
            Assert.AreEqual("TestManufacturer", savedAsset.Manufacturer);
            Assert.AreEqual("Desktop", savedAsset.Type);
            Assert.AreEqual("192.168.1.1", savedAsset.IPAddress);
            Assert.AreEqual(1, savedAsset.EmployeeID);
            Assert.AreEqual("Test Notes", savedAsset.Notes);
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void AddAsset_WithPurchaseDate_ShouldSaveDateCorrectly()
        {
            // Arrange
            addAssetForm.sysNameTB.Text = "TestPC";
            addAssetForm.employeeNum.Value = 1;
            addAssetForm.dateCB.Checked = true;
            var testDate = new DateTime(2024, 1, 1);
            addAssetForm.datePick.Value = testDate;

            Asset savedAsset = null;
            mockAsset.Setup(m => m.Add(It.IsAny<Asset>()))
                .Callback<Asset>(asset => savedAsset = asset);

            // Act
            addAssetForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedAsset);
            Assert.AreEqual(testDate, savedAsset.PurchaseDate);
        }

        [TestMethod]
        public void AddAsset_WithoutPurchaseDate_ShouldSaveNullDate()
        {
            // Arrange
            addAssetForm.sysNameTB.Text = "TestPC";
            addAssetForm.employeeNum.Value = 1;
            addAssetForm.dateCB.Checked = false;

            Asset savedAsset = null;
            mockAsset.Setup(m => m.Add(It.IsAny<Asset>()))
                .Callback<Asset>(asset => savedAsset = asset);

            // Act
            addAssetForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedAsset);
            Assert.IsNull(savedAsset.PurchaseDate);
        }

        [TestMethod]
        public void AddAsset_WithEmptyRequiredFields_ShouldThrowException()
        {
            // Set up mock DB to throw exception on SaveChanges when data is invalid
            mockDB.Setup(m => m.SaveChanges())
                .Throws(new System.Data.Entity.Validation.DbEntityValidationException("Validation failed"));

            // Set up initial data
            addAssetForm.sysNameTB.Text = "TestPC";
            addAssetForm.modelTB.Text = null;
            addAssetForm.manuTB.Text = "TestManufacturer";
            addAssetForm.typeTB.Text = "Desktop";
            addAssetForm.employeeNum.Value = 1;

            // Act
            addAssetForm.addBtn_Click(null, EventArgs.Empty);

            // Verify that Add was called but SaveChanges threw an exception
            mockAsset.Verify(m => m.Add(It.IsAny<Asset>()), Times.Once(),
                $"Add should be called even when a required field is empty");
            mockDB.Verify(m => m.SaveChanges(), Times.Once(),
                $"SaveChanges should be called when a required field is empty, but should throw an exception");
            
        }
    }
}