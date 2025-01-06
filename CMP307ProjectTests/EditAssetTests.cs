using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace CMP307ProjectTests
{
    [TestClass]
    public class EditAssetTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Asset>> mockAsset;
        private Mock<DbSet<Employee>> mockEmployee;
        private EditAsset editAssetForm;
        private Asset testAsset;
        private Employee testEmployee;

        [TestInitialize]
        public void Setup()
        {
            // Initialise mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockAsset = new Mock<DbSet<Asset>>();
            mockEmployee = new Mock<DbSet<Employee>>();

            // Create test employee
            testEmployee = new Employee
            {
                EmployeeID = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@test.com",
                Password = "password",
                DepartmentID = 1
            };

            // Create a test asset
            testAsset = new Asset
            {
                AssID = 1,
                SystemName = "OriginalPC",
                Model = "OriginalModel",
                Manufacturer = "OriginalManufacturer",
                Type = "Desktop",
                IPAddress = "192.168.1.1",
                EmployeeID = testEmployee.EmployeeID,
                Notes = "Original Notes"
            };

            // Setup mock database operations for Asset
            var assetQueryable = new[] { testAsset }.AsQueryable();
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.Provider).Returns(assetQueryable.Provider);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.Expression).Returns(assetQueryable.Expression);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.ElementType).Returns(assetQueryable.ElementType);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.GetEnumerator()).Returns(assetQueryable.GetEnumerator());

            // Setup mock database operations for Employee
            var employeeQueryable = new[] { testEmployee }.AsQueryable();
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(employeeQueryable.Provider);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(employeeQueryable.Expression);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(employeeQueryable.ElementType);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(employeeQueryable.GetEnumerator());

            mockDB.Setup(m => m.Assets).Returns(mockAsset.Object);
            mockDB.Setup(m => m.Employees).Returns(mockEmployee.Object);

            // Initialise form with test asset
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
            editAssetForm.employeeNum.Value = testEmployee.EmployeeID;
            editAssetForm.notesTB.Text = "Updated Notes";

            // Act
            editAssetForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
            var updatedAsset = mockDB.Object.Assets.FirstOrDefault(a => a.AssID == testAsset.AssID);
            Assert.IsNotNull(updatedAsset);
            Assert.AreEqual("UpdatedPC", updatedAsset.SystemName);
            Assert.AreEqual("UpdatedModel", updatedAsset.Model);
            Assert.AreEqual("UpdatedManufacturer", updatedAsset.Manufacturer);
            Assert.AreEqual("Laptop", updatedAsset.Type);
            Assert.AreEqual("192.168.1.2", updatedAsset.IPAddress);
            Assert.AreEqual(testEmployee.EmployeeID, updatedAsset.EmployeeID);
            Assert.AreEqual("Updated Notes", updatedAsset.Notes);
        }

        [TestMethod]
        public void EditAsset_WithNoEmployeeID_ShouldNotSaveToDatabase()
        {
            // Arrange
            editAssetForm.sysNameTB.Text = "UpdatedPC";
            editAssetForm.employeeNum.Maximum = 1000; // Set maximum value
            editAssetForm.employeeNum.Value = 0;

            // Setup mock for finding asset
            mockDB.Setup(m => m.Assets)
                  .Returns(mockAsset.Object);

            // Act
            editAssetForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Never(),
                "SaveChanges should not be called when employee ID is 0");
        }

        [TestMethod]
        public void EditAsset_WithNonExistentEmployee_ShouldNotSaveToDatabase()
        {
            // Arrange
            editAssetForm.sysNameTB.Text = "UpdatedPC";
            editAssetForm.modelTB.Text = "UpdatedModel";
            editAssetForm.manuTB.Text = "UpdatedManufacturer";
            editAssetForm.typeTB.Text = "Laptop";
            editAssetForm.ipTB.Text = "192.168.1.2";
            editAssetForm.employeeNum.Maximum = 1000; // Set maximum value
            editAssetForm.employeeNum.Value = 100; // Use a valid number that doesn't match existing employee
            editAssetForm.notesTB.Text = "Updated Notes";

            // Setup mock for finding asset
            mockDB.Setup(m => m.Assets)
                  .Returns(mockAsset.Object);

            // Setup mock for employee query to return null
            var emptyEmployees = new List<Employee>().AsQueryable();
            var mockEmptyEmployee = new Mock<DbSet<Employee>>();
            mockEmptyEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(emptyEmployees.Provider);
            mockEmptyEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(emptyEmployees.Expression);
            mockEmptyEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(emptyEmployees.ElementType);
            mockEmptyEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(emptyEmployees.GetEnumerator());

            mockDB.Setup(m => m.Employees).Returns(mockEmptyEmployee.Object);

            // Act
            editAssetForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Never(),
                "SaveChanges should not be called when employee doesn't exist");
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
            editAssetForm.employeeNum.Value = testEmployee.EmployeeID;

            // Act
            editAssetForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
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