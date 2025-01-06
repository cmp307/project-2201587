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
    public class AssetsFormTests
    {
        private Mock<mssql2201587Entities> mockDB;
        private Mock<DbSet<Asset>> mockAsset;
        private Mock<DbSet<Link>> mockLink;
        private AssetsForm assetsForm;
        private Asset testAsset;
        private Link testLink;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mocks
            mockDB = new Mock<mssql2201587Entities>();
            mockAsset = new Mock<DbSet<Asset>>();
            mockLink = new Mock<DbSet<Link>>();

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
                AssID = 1,
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

            mockDB.Setup(m => m.Assets).Returns(mockAsset.Object);
            mockDB.Setup(m => m.Links).Returns(mockLink.Object);

            // Initialize form
            assetsForm = new AssetsForm(mockDB.Object);
        }

        [TestMethod]
        public void DeleteAsset_ShouldDeleteAssetAndLinks()
        {
            // Arrange
            assetsForm.assetsTable.Rows[0].Selected = true;

            // Act
            assetsForm.deleteBtn_Click(null, EventArgs.Empty);

            // Assert
            mockLink.Verify(m => m.Remove(It.Is<Link>(l => l.AssID == testAsset.AssID)), Times.Once());
            mockAsset.Verify(m => m.Remove(It.Is<Asset>(a => a.AssID == testAsset.AssID)), Times.Once());
            mockDB.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}