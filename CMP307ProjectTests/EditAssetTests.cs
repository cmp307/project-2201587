﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var updatedAsset = mockDB.Object.Assets.FirstOrDefault(a => a.AssID == testAsset.AssID);
            Assert.IsNotNull(updatedAsset);
            Assert.AreEqual("UpdatedPC", updatedAsset.SystemName);
            Assert.AreEqual("UpdatedModel", updatedAsset.Model);
            Assert.AreEqual("UpdatedManufacturer", updatedAsset.Manufacturer);
            Assert.AreEqual("Laptop", updatedAsset.Type);
            Assert.AreEqual("192.168.1.2", updatedAsset.IPAddress);
            Assert.AreEqual(2, updatedAsset.EmployeeID);
            Assert.AreEqual("Updated Notes", updatedAsset.Notes);
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
            mockDB.Verify(m => m.SaveChanges(), Times.Once);
            var updatedAsset = mockDB.Object.Assets.FirstOrDefault(a => a.AssID == testAsset.AssID);
            Assert.IsNotNull(updatedAsset);
            Assert.AreEqual(testDate, updatedAsset.PurchaseDate);
        }

        [TestMethod]
        public void EditAsset_LoadExistingAsset_ShouldPopulateFieldsCorrectly()
        {
            // Act
            editAssetForm.EditAsset_Load(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(testAsset.SystemName, editAssetForm.sysNameTB.Text);
            Assert.AreEqual(testAsset.Model, editAssetForm.modelTB.Text);
            Assert.AreEqual(testAsset.Manufacturer, editAssetForm.manuTB.Text);
            Assert.AreEqual(testAsset.Type, editAssetForm.typeTB.Text);
            Assert.AreEqual(testAsset.IPAddress, editAssetForm.ipTB.Text);
            Assert.AreEqual(testAsset.EmployeeID, editAssetForm.employeeNum.Value);
            Assert.AreEqual(testAsset.Notes, editAssetForm.notesTB.Text);
        }
    }
}