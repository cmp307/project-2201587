using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CMP307ProjectTests
{
    [TestClass]
    public class LoginFormTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Employee>> mockEmployee;
        private LoginForm loginForm;
        private Employee testEmployee;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockEmployee = new Mock<DbSet<Employee>>();

            // Create a test employee with hashed password
            testEmployee = new Employee
            {
                EmployeeID = 1,
                FirstName = "Test",
                LastName = "User",
                Email = "test@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("testpassword"),
                DepartmentID = 1
            };

            // Setup mock database operations
            var queryable = new[] { testEmployee }.AsQueryable();
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            mockDB.Setup(m => m.Employees).Returns(mockEmployee.Object);

            // Initialize form
            loginForm = new LoginForm(mockDB.Object);
        }

        [TestMethod]
        public void Login_WithValidCredentials_ShouldSucceed()
        {
            // Arrange
            loginForm.emailTB.Text = testEmployee.Email;
            loginForm.passwordTB.Text = "testpassword";

            // Act
            loginForm.loginBtn_Click(null, EventArgs.Empty);

            // Assert
            var employee = mockDB.Object.Employees.FirstOrDefault(a => a.Email == loginForm.emailTB.Text);
            Assert.IsNotNull(employee);
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(loginForm.passwordTB.Text, employee.Password));
        }

        [TestMethod]
        public void Login_WithIncorrectPassword_ShouldFail()
        {
            // Arrange
            loginForm.emailTB.Text = testEmployee.Email;
            loginForm.passwordTB.Text = "wrongpassword";

            // Act
            loginForm.loginBtn_Click(null, EventArgs.Empty);

            // Assert
            var employee = mockDB.Object.Employees.FirstOrDefault(a => a.Email == loginForm.emailTB.Text);
            Assert.IsNotNull(employee);
            Assert.IsFalse(BCrypt.Net.BCrypt.Verify(loginForm.passwordTB.Text, employee.Password));
        }

        [TestMethod]
        public void Login_WithNonExistentEmail_ShouldFail()
        {
            // Arrange
            loginForm.emailTB.Text = "nonexistent@example.com";
            loginForm.passwordTB.Text = testEmployee.Password;

            // Act
            loginForm.loginBtn_Click(null, EventArgs.Empty);

            // Assert
            var employee = mockDB.Object.Employees.FirstOrDefault(a => a.Email == loginForm.emailTB.Text);
            Assert.IsNull(employee);
        }

        [TestMethod]
        public void Login_WithEmptyField_ShouldShowError()
        {
            // Arrange
            loginForm.emailTB.Text = "";
            loginForm.passwordTB.Text = testEmployee.Password;

            // Act
            loginForm.loginBtn_Click(null, EventArgs.Empty);

            // Assert
            var employee = mockDB.Object.Employees.FirstOrDefault(a => a.Email == loginForm.emailTB.Text);
            Assert.IsNull(employee);
        }

        [TestMethod]
        public void ShowPassword_WhenChecked_ShouldShowPasswordCharacters()
        {
            // Arrange
            loginForm.passwordTB.Text = testEmployee.Password;

            // Act
            loginForm.showPassword.Checked = true;
            loginForm.showPassword_CheckedChanged(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual('\0', loginForm.passwordTB.PasswordChar);
        }

        [TestMethod]
        public void ShowPassword_WhenUnchecked_ShouldHidePasswordCharacters()
        {
            // Arrange
            loginForm.passwordTB.Text = testEmployee.Password;
            loginForm.showPassword.Checked = true;
            loginForm.showPassword_CheckedChanged(null, EventArgs.Empty);

            // Act
            loginForm.showPassword.Checked = false;
            loginForm.showPassword_CheckedChanged(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual('*', loginForm.passwordTB.PasswordChar);
        }
    }
}