using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using CMP307Project;
using System.Data.Entity;
using System.Linq;

namespace CMP307ProjectTests
{
    [TestClass]
    public class EditLinkTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Link>> mockLink;
        private Mock<DbSet<Asset>> mockAsset;
        private EditLink editLinkForm;
        private Link testLink;
        private Asset testAsset;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockLink = new Mock<DbSet<Link>>();
            mockAsset = new Mock<DbSet<Asset>>();

            // Create test data
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
                AssID = testAsset.AssID,
                SoftID = 1,
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

            // Initialize form with test link
            editLinkForm = new EditLink(mockDB.Object, testLink);
        }

        [TestMethod]
        public void EditLink_WithValidData_ShouldUpdateDatabase()
        {
            // Arrange
            editLinkForm.activeCB.Checked = false;  // Change from initial true state

            // Act
            editLinkForm.editBtn_Click(null, EventArgs.Empty);

            // Assert
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsFalse(testLink.Active);
        }

        [TestMethod]
        public void EditLink_LoadExistingLink_ShouldPopulateFieldsCorrectly()
        {
            // Act
            editLinkForm.EditLink_Load(null, EventArgs.Empty);

            // Assert
            Assert.IsTrue(editLinkForm.activeCB.Checked);
            Assert.AreEqual($"Link for Software: {testLink.SoftID}", editLinkForm.softwareLbl.Text);
            Assert.AreEqual($"On Asset: {testLink.AssID}", editLinkForm.assetLbl.Text);
        }
    }
}