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
    public class AddAssetTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Asset>> mockAsset;
        private Mock<DbSet<Employee>> mockEmployee;
        private AddAsset addAssetForm;
        private Employee testEmployee;

        [TestInitialize]
        public void Setup()
        {
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

            // Setup mock database operations for Employee
            var employeeQueryable = new[] { testEmployee }.AsQueryable();
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(employeeQueryable.Provider);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(employeeQueryable.Expression);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(employeeQueryable.ElementType);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(employeeQueryable.GetEnumerator());

            mockDB.Setup(m => m.Assets).Returns(mockAsset.Object);
            mockDB.Setup(m => m.Employees).Returns(mockEmployee.Object);
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
            mockAsset.Verify(m => m.Add(It.IsAny<Asset>()), Times.Never(),
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
            addAssetForm.employeeNum.Value = testEmployee.EmployeeID;
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
            Assert.AreEqual(testEmployee.EmployeeID, savedAsset.EmployeeID);
            Assert.AreEqual("Test Notes", savedAsset.Notes);
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void AddAsset_WithPurchaseDate_ShouldSaveDateCorrectly()
        {
            // Arrange
            addAssetForm.sysNameTB.Text = "TestPC";
            addAssetForm.employeeNum.Value = testEmployee.EmployeeID;
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
            addAssetForm.employeeNum.Value = testEmployee.EmployeeID;
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
            addAssetForm.employeeNum.Value = testEmployee.EmployeeID;

            // Act
            addAssetForm.addBtn_Click(null, EventArgs.Empty);

            // Verify that Add was called but SaveChanges threw an exception
            mockAsset.Verify(m => m.Add(It.IsAny<Asset>()), Times.Once(),
                "Add should be called even when a required field is empty");
            mockDB.Verify(m => m.SaveChanges(), Times.Once(),
                "SaveChanges should be called even when a required field is empty, but should throw an exception");
        }

        [TestMethod]
        public void AddAsset_WithNonExistentEmployee_ShouldNotSaveToDatabase()
        {
            // Arrange
            addAssetForm.sysNameTB.Text = "TestPC";
            addAssetForm.modelTB.Text = "TestModel";
            addAssetForm.manuTB.Text = "TestManufacturer";
            addAssetForm.typeTB.Text = "Desktop";
            addAssetForm.ipTB.Text = "192.168.1.1";
            addAssetForm.employeeNum.Maximum = 1000; // Set maximum value
            addAssetForm.employeeNum.Value = 100; // Use a valid number that doesn't match existing employee
            addAssetForm.notesTB.Text = "Test Notes";

            // Setup mock for employee query to return null
            var emptyEmployees = new List<Employee>().AsQueryable();
            var mockEmptyEmployee = new Mock<DbSet<Employee>>();
            mockEmptyEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(emptyEmployees.Provider);
            mockEmptyEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(emptyEmployees.Expression);
            mockEmptyEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(emptyEmployees.ElementType);
            mockEmptyEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(emptyEmployees.GetEnumerator());

            mockDB.Setup(m => m.Employees).Returns(mockEmptyEmployee.Object);

            // Act
            addAssetForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Never(),
                "SaveChanges should not be called when employee doesn't exist");
            mockAsset.Verify(m => m.Add(It.IsAny<Asset>()), Times.Never(),
                "Add should not be called when employee doesn't exist");
        }
    }
}