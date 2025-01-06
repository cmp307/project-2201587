using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;

namespace CMP307ProjectTests
{
    [TestClass]
    public class EditEmployeeTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Employee>> mockEmployee;
        private EditEmployee editEmployeeForm;
        private Employee testEmployee;

        [TestInitialize]
        public void Setup()
        {
            // Initialise mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockEmployee = new Mock<DbSet<Employee>>();

            // Create a test employee
            testEmployee = new Employee
            {
                EmployeeID = 1,
                FirstName = "Original",
                LastName = "User",
                Email = "original@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("originalpass"),
                DepartmentID = 1
            };

            // Setup mock database operations
            var queryable = new[] { testEmployee }.AsQueryable();
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            mockDB.Setup(m => m.Employees).Returns(mockEmployee.Object);

            // Initialise form with test employee
            editEmployeeForm = new EditEmployee(mockDB.Object, testEmployee);
        }

        [TestMethod]
        public void EditEmployee_WithValidData_ShouldUpdateDatabase()
        {
            // Arrange
            editEmployeeForm.firstNameTB.Text = "Updated";
            editEmployeeForm.lastNameTB.Text = "Name";
            editEmployeeForm.emailTB.Text = "updated@example.com";
            editEmployeeForm.passwordTB.Text = "newpassword";
            editEmployeeForm.departmentNum.Value = 2;

            // Act
            editEmployeeForm.updateBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
            var updatedEmployee = mockDB.Object.Employees.FirstOrDefault(e => e.EmployeeID == testEmployee.EmployeeID);
            Assert.IsNotNull(updatedEmployee);
            Assert.AreEqual("Updated", updatedEmployee.FirstName);
            Assert.AreEqual("Name", updatedEmployee.LastName);
            Assert.AreEqual("updated@example.com", updatedEmployee.Email);
            Assert.AreEqual(2, updatedEmployee.DepartmentID);
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify("newpassword", updatedEmployee.Password));
        }

        [TestMethod]
        public void EditEmployee_WithNoDepartment_ShouldNotSaveToDatabase()
        {
            // Arrange
            editEmployeeForm.departmentNum.Value = 0;

            // Act
            editEmployeeForm.updateBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Never(),
                "SaveChanges should not be called when department ID is 0");
        }

        [TestMethod]
        public void EditEmployee_WithEmptyRequiredField_ShouldNotSaveToDatabase()
        {
            // Set up DB mock to throw exception on SaveChanges when data is invalid
            mockDB.Setup(m => m.SaveChanges())
                .Throws(new System.Data.Entity.Validation.DbEntityValidationException("Validation failed"));

            // Arrange
            editEmployeeForm.firstNameTB.Text = "";  // Empty required field
            editEmployeeForm.lastNameTB.Text = testEmployee.LastName;
            editEmployeeForm.emailTB.Text = testEmployee.Email;
            editEmployeeForm.passwordTB.Text = testEmployee.Password;
            editEmployeeForm.departmentNum.Value = testEmployee.DepartmentID;

            // Act
            editEmployeeForm.updateBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Once(),
                "SaveChanges should be called when a required field is empty, but should throw an exception");
        }

        [TestMethod]
        public void EditEmployee_LoadExistingEmployee_ShouldPopulateFieldsCorrectly()
        {
            // Act
            editEmployeeForm.EditEmployee_Load(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(testEmployee.FirstName, editEmployeeForm.firstNameTB.Text);
            Assert.AreEqual(testEmployee.LastName, editEmployeeForm.lastNameTB.Text);
            Assert.AreEqual(testEmployee.Email, editEmployeeForm.emailTB.Text);
            Assert.AreEqual(testEmployee.Password, editEmployeeForm.passwordTB.Text);
            Assert.AreEqual(testEmployee.DepartmentID, editEmployeeForm.departmentNum.Value);
        }

        [TestMethod]
        public void EditEmployee_ShouldHashNewPassword()
        {
            // Arrange
            string newPassword = "newpassword123";
            editEmployeeForm.firstNameTB.Text = testEmployee.FirstName;
            editEmployeeForm.lastNameTB.Text = testEmployee.LastName;
            editEmployeeForm.emailTB.Text = testEmployee.Email;
            editEmployeeForm.passwordTB.Text = newPassword;
            editEmployeeForm.departmentNum.Value = testEmployee.DepartmentID;

            // Act
            editEmployeeForm.updateBtn_Click(null, EventArgs.Empty);

            // Assert
            var updatedEmployee = mockDB.Object.Employees.FirstOrDefault(e => e.EmployeeID == testEmployee.EmployeeID);
            Assert.IsNotNull(updatedEmployee);
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(newPassword, updatedEmployee.Password));
            Assert.AreNotEqual(newPassword, updatedEmployee.Password);
        }
    }
}