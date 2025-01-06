using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;

namespace CMP307ProjectTests
{
    [TestClass]
    public class AddLinkTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Link>> mockLink;
        private Mock<DbSet<Asset>> mockAsset;
        private AddLink addLinkForm;
        private Software testSoftware;
        private Asset testAsset;
        private Link testLink;

        [TestInitialize]
        public void Setup()
        {
            // Initialise mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockLink = new Mock<DbSet<Link>>();
            mockAsset = new Mock<DbSet<Asset>>();

            // Create test data
            testSoftware = new Software
            {
                SoftID = 1,
                OSname = "Windows 10 Pro",
                Version = "22H2",
                manufacturer = "Microsoft"
            };

            testAsset = new Asset
            {
                AssID = 1,
                SystemName = "TestPC",
                Model = "TestModel",
                Manufacturer = "TestManufacturer",
                Type = "Desktop",
                EmployeeID = 1
            };

            testLink = new Link
            {
                AssID = 1,
                SoftID = 2,  // Different software
                Date = DateTime.Now,
                Active = true
            };

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

            mockDB.Setup(m => m.Links).Returns(mockLink.Object);
            mockDB.Setup(m => m.Assets).Returns(mockAsset.Object);

            // Initialise form with test software
            addLinkForm = new AddLink(mockDB.Object, testSoftware);
        }

        [TestMethod]
        public void AddLink_WithValidData_ShouldSaveToDatabase()
        {
            // Arrange
            addLinkForm.assetNum.Value = 1;
            addLinkForm.activeCB.Checked = true;

            Link savedLink = null;
            mockLink.Setup(m => m.Add(It.IsAny<Link>()))
                .Callback<Link>(link => savedLink = link);

            // Act
            addLinkForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedLink, "Link should be saved");
            Assert.AreEqual(1, savedLink.AssID);
            Assert.AreEqual(testSoftware.SoftID, savedLink.SoftID);
            Assert.IsTrue(savedLink.Active);
            mockDB.Verify(m => m.SaveChanges(), Times.AtLeastOnce());
        }

        [TestMethod]
        public void AddLink_WithNoAsset_ShouldNotSaveToDatabase()
        {
            // Arrange
            addLinkForm.assetNum.Value = 0;
            addLinkForm.activeCB.Checked = true;

            // Act
            addLinkForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            mockLink.Verify(m => m.Add(It.IsAny<Link>()), Times.Never());
            mockDB.Verify(m => m.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void AddLink_NonITEmployeeWithWrongAsset_ShouldNotSaveToDatabase()
        {
            // Arrange
            const int nonITEmployeeID = 2;
            var addLinkFormNonIT = new AddLink(mockDB.Object, testSoftware, nonITEmployeeID);
            addLinkFormNonIT.assetNum.Value = 1;  // Asset belongs to employee 1
            addLinkFormNonIT.activeCB.Checked = true;

            // Act
            addLinkFormNonIT.addBtn_Click(null, EventArgs.Empty);

            // Assert
            mockLink.Verify(m => m.Add(It.IsAny<Link>()), Times.Never());
            mockDB.Verify(m => m.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void AddLink_NewActiveLink_ShouldDeactivateOtherSoftwareOnAsset()
        {
            // Arrange
            addLinkForm.assetNum.Value = testLink.AssID;  // Same asset as existing link
            addLinkForm.activeCB.Checked = true;

            Link savedLink = null;
            mockLink.Setup(m => m.Add(It.IsAny<Link>()))
                .Callback<Link>(link => savedLink = link);

            // Act
            addLinkForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsNotNull(savedLink);
            Assert.IsTrue(savedLink.Active);
            // Verify that existing link for other software on same asset is now inactive
            Assert.IsFalse(testLink.Active);
            mockDB.Verify(m => m.SaveChanges(), Times.Exactly(2));
        }

        [TestMethod]
        public void AddLink_DuplicateLink_ShouldNotSaveToDatabase()
        {
            // Arrange - Create a preexisting link for the same software and asset
            testLink.SoftID = testSoftware.SoftID;
            addLinkForm.assetNum.Value = testLink.AssID;
            addLinkForm.activeCB.Checked = true;

            // Act
            addLinkForm.addBtn_Click(null, EventArgs.Empty);

            // Assert
            mockLink.Verify(m => m.Add(It.IsAny<Link>()), Times.Never());
            mockDB.Verify(m => m.SaveChanges(), Times.Never());
        }
    }
}