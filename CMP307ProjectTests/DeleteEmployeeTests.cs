using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace CMP307ProjectTests
{
    [TestClass]
    public class EmployeeFormTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Employee>> mockEmployee;
        private Mock<DbSet<Asset>> mockAsset;
        private Mock<DbSet<Link>> mockLink;
        private EmployeesForm employeesForm;
        private Employee testEmployee;
        private Asset testAsset;
        private Link testLink;

        [TestInitialize]
        public void Setup()
        {
            // Initialise mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockEmployee = new Mock<DbSet<Employee>>();
            mockAsset = new Mock<DbSet<Asset>>();
            mockLink = new Mock<DbSet<Link>>();

            // Create test data
            testEmployee = new Employee
            {
                EmployeeID = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@example.com",
                Password = "password123",
                DepartmentID = 1
            };

            testAsset = new Asset
            {
                AssID = 1,
                SystemName = "TestPC",
                Model = "TestModel",
                Manufacturer = "TestManufacturer",
                Type = "Desktop",
                EmployeeID = testEmployee.EmployeeID
            };

            testLink = new Link
            {
                AssID = testAsset.AssID,
                SoftID = 1,
                Date = DateTime.Now,
                Active = true
            };

            // Setup mock database operations for Employee
            var employeeQueryable = new[] { testEmployee }.AsQueryable();
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(employeeQueryable.Provider);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(employeeQueryable.Expression);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(employeeQueryable.ElementType);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(employeeQueryable.GetEnumerator());

            // Setup mock database operations for Asset
            var assetQueryable = new[] { testAsset }.AsQueryable();
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.Provider).Returns(assetQueryable.Provider);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.Expression).Returns(assetQueryable.Expression);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.ElementType).Returns(assetQueryable.ElementType);
            mockAsset.As<IQueryable<Asset>>().Setup(m => m.GetEnumerator()).Returns(assetQueryable.GetEnumerator());

            // Setup mock database operations for Link
            var linkQueryable = new[] { testLink }.AsQueryable();
            mockLink.As<IQueryable<Link>>().Setup(m => m.Provider).Returns(linkQueryable.Provider);
            mockLink.As<IQueryable<Link>>().Setup(m => m.Expression).Returns(linkQueryable.Expression);
            mockLink.As<IQueryable<Link>>().Setup(m => m.ElementType).Returns(linkQueryable.ElementType);
            mockLink.As<IQueryable<Link>>().Setup(m => m.GetEnumerator()).Returns(linkQueryable.GetEnumerator());

            mockDB.Setup(m => m.Employees).Returns(mockEmployee.Object);
            mockDB.Setup(m => m.Assets).Returns(mockAsset.Object);
            mockDB.Setup(m => m.Links).Returns(mockLink.Object);

            // Initialise form
            employeesForm = new EmployeesForm(mockDB.Object);
        }

        [TestMethod]
        public void DeleteEmployee_ShouldDeleteEmployeeAssetsAndLinks()
        {
            // Arrange
            employeesForm.employeesTable.Rows[0].Selected = true;

            // Act
            employeesForm.deleteBtn_Click(null, EventArgs.Empty);

            // Assert
            // Verify links are deleted first
            mockLink.Verify(m => m.Remove(It.Is<Link>(l => l.AssID == testAsset.AssID)), Times.Once());

            // Verify assets are deleted second
            mockAsset.Verify(m => m.Remove(It.Is<Asset>(a => a.EmployeeID == testEmployee.EmployeeID)), Times.Once());

            // Verify employee is deleted last
            mockEmployee.Verify(m => m.Remove(It.Is<Employee>(e => e.EmployeeID == testEmployee.EmployeeID)), Times.Once());

            // Verify changes are saved
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}