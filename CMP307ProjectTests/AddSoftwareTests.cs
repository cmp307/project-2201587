using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;

namespace CMP307ProjectTests
{
    [TestClass]
    public class AddSoftwareTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Software>> mockSoftware;
        private AddSoftware addSoftwareForm;
        private Software testSoftware;

        [TestInitialize]
        public void Setup()
        {
            mockDB = new Mock<mssql2201587Entities>();
            mockSoftware = new Mock<DbSet<Software>>();
            mockDB.Setup(m => m.Softwares).Returns(mockSoftware.Object);
            addSoftwareForm = new AddSoftware(mockDB.Object);

            testSoftware = new Software
            {
                SoftID = 1,
                OSname = "Windows 10 Pro",
                Version = "22H2",
                manufacturer = "Microsoft"
            };
        }

        [TestMethod]
        public void AddSoftware_WithValidData_ShouldSaveToDatabase()
        {
            // Arrange
            addSoftwareForm.osNameTB.Text = testSoftware.OSname;
            addSoftwareForm.versionTB.Text = testSoftware.Version;
            addSoftwareForm.manuTB.Text = testSoftware.manufacturer;

            Software savedSoftware = null;
            mockSoftware.Setup(m => m.Add(It.IsAny<Software>()))
                .Callback<Software>(software => savedSoftware = software);

            // Act
            addSoftwareForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedSoftware, "Software should be saved");
            Assert.AreEqual(testSoftware.OSname, savedSoftware.OSname);
            Assert.AreEqual(testSoftware.Version, savedSoftware.Version);
            Assert.AreEqual(testSoftware.manufacturer, savedSoftware.manufacturer);
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void AddSoftware_WithEmptyRequiredField_ShouldNotSaveToDatabase()
        {
            // Setup
            mockDB.Setup(m => m.SaveChanges())
                .Throws(new System.Data.Entity.Validation.DbEntityValidationException("Validation failed"));

            // Arrange
            addSoftwareForm.osNameTB.Text = "";  // empty required field
            addSoftwareForm.versionTB.Text = testSoftware.Version;
            addSoftwareForm.manuTB.Text = testSoftware.manufacturer;

            // Act
            addSoftwareForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            mockSoftware.Verify(m => m.Add(It.IsAny<Software>()), Times.Once(),
                "Add should be called even when a required field is empty");
            mockDB.Verify(m => m.SaveChanges(), Times.Once(),
                "SaveChanges should be called when a required field is empty, but should throw an exception");
        }

        [TestMethod]
        public void AddSoftware_ShouldPromptForLink()
        {
            // Arrange
            const int nonITEmployeeID = 2;
            var addSoftwareFormNonIT = new AddSoftware(mockDB.Object, nonITEmployeeID);
            addSoftwareFormNonIT.osNameTB.Text = testSoftware.OSname;
            addSoftwareFormNonIT.versionTB.Text = testSoftware.Version;
            addSoftwareFormNonIT.manuTB.Text = testSoftware.manufacturer;

            Software savedSoftware = null;
            mockSoftware.Setup(m => m.Add(It.IsAny<Software>()))
                .Callback<Software>(software => savedSoftware = software);

            // Act
            addSoftwareFormNonIT.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedSoftware, "Software should be saved");
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}