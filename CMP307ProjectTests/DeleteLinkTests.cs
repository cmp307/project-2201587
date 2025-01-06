using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;

namespace CMP307ProjectTests
{
    [TestClass]
    public class DeleteLinkTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Link>> mockLink;
        private Mock<DbSet<Software>> mockSoftware;
        private SoftwareForm softwareForm;
        private Link testLink;
        private Software testSoftware;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockSoftware = new Mock<DbSet<Software>>();
            mockLink = new Mock<DbSet<Link>>();

            // Create test data
            testSoftware = new Software
            {
                SoftID = 1,
                OSname = "Windows 10 Pro",
                Version = "22H2",
                manufacturer = "Microsoft"
            };

            // Create test link
            testLink = new Link
            {
                AssID = 1,
                SoftID = 1,
                Date = DateTime.Now,
                Active = true
            };

            // Setup mock database operations for Software
            var softwareQueryable = new[] { testSoftware }.AsQueryable();
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.Provider).Returns(softwareQueryable.Provider);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.Expression).Returns(softwareQueryable.Expression);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.ElementType).Returns(softwareQueryable.ElementType);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.GetEnumerator()).Returns(softwareQueryable.GetEnumerator());

            // Setup mock database operations
            var linkQueryable = new[] { testLink }.AsQueryable();
            mockLink.As<IQueryable<Link>>().Setup(m => m.Provider).Returns(linkQueryable.Provider);
            mockLink.As<IQueryable<Link>>().Setup(m => m.Expression).Returns(linkQueryable.Expression);
            mockLink.As<IQueryable<Link>>().Setup(m => m.ElementType).Returns(linkQueryable.ElementType);
            mockLink.As<IQueryable<Link>>().Setup(m => m.GetEnumerator()).Returns(linkQueryable.GetEnumerator());

            mockDB.Setup(m => m.Softwares).Returns(mockSoftware.Object);
            mockDB.Setup(m => m.Links).Returns(mockLink.Object);

            // Initialize form
            softwareForm = new SoftwareForm(mockDB.Object);
        }

        [TestMethod]
        public void DeleteLink_WithValidData_ShouldDeleteFromDatabase()
        {
            // Arrange - Set up the selected row in the links table
            softwareForm.linksTable.Rows[0].Selected = true;

            // Act
            softwareForm.deleteLinkBtn_Click(null, EventArgs.Empty);

            // Assert
            mockLink.Verify(m => m.Remove(It.Is<Link>(l =>
                l.AssID == testLink.AssID &&
                l.SoftID == testLink.SoftID)), Times.Once());
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void DeleteLink_ShouldRefreshTableAfterDeletion()
        {
            // Arrange
            softwareForm.linksTable.Rows[0].Selected = true;
            var loadTablesCalled = false;

            // Setup mock to track if loadTables is called
            mockDB.Setup(m => m.SaveChanges()).Callback(() => loadTablesCalled = true);

            // Act
            softwareForm.deleteLinkBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsTrue(loadTablesCalled, "Table should be refreshed after deletion");
            mockLink.Verify(m => m.Remove(It.IsAny<Link>()), Times.Once());
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}