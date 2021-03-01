using Moq;
using NUnit.Framework;
using PersonDataCollection.DAL;
using PersonDataCollection.Models;
using PersonDataCollection.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PersonDataCollectionTests.Services
{
    [TestFixture]
    public class PersonServiceTest
    {
        private IPersonService _personService;
        private Mock<IContext> _mockContext;
        private Mock<DbSet<Staff>> _mockSet;
        private IQueryable<Staff> staffList;

        [OneTimeSetUp]
        public void Initialize()
        {
            staffList = new List<Staff>
            {
                new Staff() {  Id = 1, Forename = "John", Surname = "Smith", DateOfBirth = DateTime.Today }
            }.AsQueryable();

            _mockSet = new Mock<DbSet<Staff>>();
            _mockSet.As<IQueryable<Staff>>().Setup(m => m.Provider).Returns(staffList.Provider);
            _mockSet.As<IQueryable<Staff>>().Setup(m => m.Expression).Returns(staffList.Expression);
            _mockSet.As<IQueryable<Staff>>().Setup(m => m.ElementType).Returns(staffList.ElementType);
            _mockSet.As<IQueryable<Staff>>().Setup(m => m.GetEnumerator()).Returns(staffList.GetEnumerator());

            _mockContext = new Mock<IContext>();
            _mockContext.Setup(c => c.Set<Staff>()).Returns(_mockSet.Object);
            _mockContext.Setup(c => c.Staff).Returns(_mockSet.Object);

            _personService = new PersonService(_mockContext.Object);
        }

        [TestCase]
        public void Can_Add_Staff()
        {
            //Arrange
            int id = 1;
            Staff staff = new Staff() { Forename = "John" };
            _mockSet.Setup(m => m.Add(staff)).Returns((Staff s) =>
                {
                    s.Id = id;
                    return s;
                });

            //Act
            _personService.CreateStaff(staff);

            //Assert
            Assert.AreEqual(id, staff.Id);
            _mockContext.Verify(mocks => mocks.SaveChangesAsync(), Times.Once());
        }
    }
}