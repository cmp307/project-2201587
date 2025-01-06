using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;

namespace CMP307ProjectTests
{
    [TestClass]
    public class AddEmployeeTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Employee>> mockEmployee;
        private AddEmployee addEmployeeForm;
        private Employee testEmployee;

        [TestInitialize]
        public void Setup()
        {
            mockDB = new Mock<mssql2201587Entities>();
            mockEmployee = new Mock<DbSet<Employee>>();
            mockDB.Setup(m => m.Employees).Returns(mockEmployee.Object);
            addEmployeeForm = new AddEmployee(mockDB.Object);

            testEmployee = new Employee
            {
                EmployeeID = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@example.com",
                Password = "password123",
                DepartmentID = 1
            };
        }

        [TestMethod]
        public void AddEmployee_WithValidData_ShouldSaveToDatabase()
        {
            // Arrange
            addEmployeeForm.firstNameTB.Text = testEmployee.FirstName;
            addEmployeeForm.lastNameTB.Text = testEmployee.LastName;
            addEmployeeForm.emailTB.Text = testEmployee.Email;
            addEmployeeForm.passwordTB.Text = testEmployee.Password;
            addEmployeeForm.departmentNum.Value = testEmployee.DepartmentID;

            Employee savedEmployee = null;
            mockEmployee.Setup(m => m.Add(It.IsAny<Employee>()))
                .Callback<Employee>(employee => savedEmployee = employee);

            // Act
            addEmployeeForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedEmployee, "Employee should be saved");
            Assert.AreEqual("John", savedEmployee.FirstName);
            Assert.AreEqual("Smith", savedEmployee.LastName);
            Assert.AreEqual("john.smith@example.com", savedEmployee.Email);
            Assert.AreEqual(1, savedEmployee.DepartmentID);
            // Verify password was hashed
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify("password123", savedEmployee.Password));
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void AddEmployee_WithNoDepartment_ShouldNotSaveToDatabase()
        {
            // Arrange
            addEmployeeForm.firstNameTB.Text = "John";
            addEmployeeForm.lastNameTB.Text = "Smith";
            addEmployeeForm.emailTB.Text = "john.smith@example.com";
            addEmployeeForm.passwordTB.Text = "password123";
            addEmployeeForm.departmentNum.Value = 0;

            // Act
            addEmployeeForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Never(),
                "SaveChanges should not be called when department ID is 0");
            mockDB.Verify(m => m.Employees.Add(It.IsAny<Employee>()), Times.Never(),
                "Add should not be called when department ID is 0");
        }

        [TestMethod]
        public void AddEmployee_WithEmptyRequiredField_ShouldNotSaveToDatabase()
        {
            // Set up DB mock to throw exception on SaveChanges when data is invalid
            mockDB.Setup(m => m.SaveChanges())
                .Throws(new System.Data.Entity.Validation.DbEntityValidationException("Validation failed"));

            // Set up valid initial data
            addEmployeeForm.firstNameTB.Text = "";
            addEmployeeForm.lastNameTB.Text = testEmployee.LastName;
            addEmployeeForm.emailTB.Text = testEmployee.Email;
            addEmployeeForm.passwordTB.Text = testEmployee.Password;
            addEmployeeForm.departmentNum.Value = testEmployee.DepartmentID;

            // Act
            addEmployeeForm.addBtn_Click(null, EventArgs.Empty);

            // Verify that Add was called but SaveChanges threw an exception
            mockEmployee.Verify(m => m.Add(It.IsAny<Employee>()), Times.Once(),
                $"Add should be called even when a required field is empty");
            mockDB.Verify(m => m.SaveChanges(), Times.Once(),
                $"SaveChanges should be called even when a required field is empty, but should throw an exception");
        }

        [TestMethod]
        public void AddEmployee_ShouldHashPassword()
        {
            // Arrange
            addEmployeeForm.firstNameTB.Text = testEmployee.FirstName;
            addEmployeeForm.lastNameTB.Text = testEmployee.LastName;
            addEmployeeForm.emailTB.Text = testEmployee.Email;
            addEmployeeForm.passwordTB.Text = testEmployee.Password;
            addEmployeeForm.departmentNum.Value = testEmployee.DepartmentID;

            Employee savedEmployee = null;
            mockEmployee.Setup(m => m.Add(It.IsAny<Employee>()))
                .Callback<Employee>(employee => savedEmployee = employee);

            // Act
            addEmployeeForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedEmployee);
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(testEmployee.Password, savedEmployee.Password));
        }
    }
}