using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;

namespace CMP307ProjectTests
{
    [TestClass]
    public class EditSoftwareTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Software>> mockSoftware;
        private EditSoftware editSoftwareForm;
        private Software testSoftware;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockSoftware = new Mock<DbSet<Software>>();

            // Create test software
            testSoftware = new Software
            {
                SoftID = 1,
                OSname = "Windows 10 Pro",
                Version = "22H2",
                manufacturer = "Microsoft"
            };

            // Setup mock database operations
            var queryable = new[] { testSoftware }.AsQueryable();
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            mockDB.Setup(m => m.Softwares).Returns(mockSoftware.Object);

            // Initialize form with test software
            editSoftwareForm = new EditSoftware(mockDB.Object, testSoftware);
        }

        [TestMethod]
        public void EditSoftware_WithValidData_ShouldUpdateDatabase()
        {
            // Arrange
            editSoftwareForm.osNameTB.Text = "Windows 11 Pro";
            editSoftwareForm.versionTB.Text = "23H2";
            editSoftwareForm.manuTB.Text = "Microsoft Corp";

            // Act
            editSoftwareForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
            var updatedSoftware = mockDB.Object.Softwares.FirstOrDefault(s => s.SoftID == testSoftware.SoftID);
            Assert.IsNotNull(updatedSoftware);
            Assert.AreEqual("Windows 11 Pro", updatedSoftware.OSname);
            Assert.AreEqual("23H2", updatedSoftware.Version);
            Assert.AreEqual("Microsoft Corp", updatedSoftware.manufacturer);
        }

        [TestMethod]
        public void EditSoftware_WithEmptyRequiredField_ShouldNotSaveToDatabase()
        {
            // Set up DB mock to throw exception on SaveChanges when data is invalid
            mockDB.Setup(m => m.SaveChanges())
                .Throws(new System.Data.Entity.Validation.DbEntityValidationException("Validation failed"));

            // Arrange
            editSoftwareForm.osNameTB.Text = "";  // Empty required field
            editSoftwareForm.versionTB.Text = testSoftware.Version;
            editSoftwareForm.manuTB.Text = testSoftware.manufacturer;

            // Act
            editSoftwareForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Once(),
                "SaveChanges should be called when a required field is empty, but should throw an exception");
        }

        [TestMethod]
        public void EditSoftware_LoadExistingSoftware_ShouldPopulateFieldsCorrectly()
        {
            // Act
            editSoftwareForm.EditSoftware_Load(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(testSoftware.OSname, editSoftwareForm.osNameTB.Text);
            Assert.AreEqual(testSoftware.Version, editSoftwareForm.versionTB.Text);
            Assert.AreEqual(testSoftware.manufacturer, editSoftwareForm.manuTB.Text);
        }
    }
}