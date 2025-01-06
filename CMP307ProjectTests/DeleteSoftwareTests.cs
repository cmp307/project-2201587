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
    public class SoftwareFormTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Software>> mockSoftware;
        private Mock<DbSet<Link>> mockLink;
        private SoftwareForm softwareForm;
        private Software testSoftware;
        private Link testLink;

        [TestInitialize]
        public void Setup()
        {
            // Initialise mocks
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

            testLink = new Link
            {
                SoftID = 1,
                AssID = 1,
                Date = DateTime.Now,
                Active = true
            };

            // Setup mock database operations for Software
            var softwareQueryable = new[] { testSoftware }.AsQueryable();
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.Provider).Returns(softwareQueryable.Provider);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.Expression).Returns(softwareQueryable.Expression);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.ElementType).Returns(softwareQueryable.ElementType);
            mockSoftware.As<IQueryable<Software>>().Setup(m => m.GetEnumerator()).Returns(softwareQueryable.GetEnumerator());

            // Setup mock database operations for Link
            var linkQueryable = new[] { testLink }.AsQueryable();
            mockLink.As<IQueryable<Link>>().Setup(m => m.Provider).Returns(linkQueryable.Provider);
            mockLink.As<IQueryable<Link>>().Setup(m => m.Expression).Returns(linkQueryable.Expression);
            mockLink.As<IQueryable<Link>>().Setup(m => m.ElementType).Returns(linkQueryable.ElementType);
            mockLink.As<IQueryable<Link>>().Setup(m => m.GetEnumerator()).Returns(linkQueryable.GetEnumerator());

            mockDB.Setup(m => m.Softwares).Returns(mockSoftware.Object);
            mockDB.Setup(m => m.Links).Returns(mockLink.Object);

            // Initialise form
            softwareForm = new SoftwareForm(mockDB.Object);
        }

        [TestMethod]
        public void DeleteSoftware_ShouldDeleteSoftwareAndLinks()
        {
            // Arrange
            softwareForm.softwareTable.Rows[0].Selected = true;

            // Act
            softwareForm.deleteBtn_Click(null, EventArgs.Empty);

            // Assert
            mockLink.Verify(m => m.Remove(It.Is<Link>(l => l.SoftID == testSoftware.SoftID)), Times.Once());
            mockSoftware.Verify(m => m.Remove(It.Is<Software>(s => s.SoftID == testSoftware.SoftID)), Times.Once());
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}