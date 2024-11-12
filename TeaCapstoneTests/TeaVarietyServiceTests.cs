using Microsoft.EntityFrameworkCore;
using Moq;
using TeaCapstone.Data;
using TeaCapstone.Models;
using TeaCapstone.Services;


namespace TeaCapstoneTests
{
    [TestClass]
    public class TeaVarietyServiceTests
    {
        //private readonly Mock<DbSet<TeaVariety>> _mockDbSet;
        private readonly ApplicationDbContext _mockDbContext;
        private readonly TeaVarietyService _teaVarietyService;

        public TeaVarietyServiceTests()
        {
            // Set up in-memory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            // Initialize the DbContext with the in-memory database
            _mockDbContext = new ApplicationDbContext(options);

            // Seed the database with test data
            SeedDatabase(_mockDbContext);

            // Initialize the service with the real DbContext
            _teaVarietyService = new TeaVarietyService(_mockDbContext);
        }

        private void SeedDatabase(ApplicationDbContext context)
        {

            context.TeaVariety.RemoveRange(context.TeaVariety);
            context.SaveChanges();

            context.TeaVariety.Add(new TeaVariety { Id = 4, Name = "Earl Grey", CaffeineContent = 55, TeaTypeId = 1 });
            context.TeaVariety.Add(new TeaVariety { Id = 25, Name = "Hibiscus", CaffeineContent = 0, TeaTypeId = 3 });
            context.TeaVariety.Add(new TeaVariety { Id = 14, Name = "Gyokuro", CaffeineContent = 70, TeaTypeId = 2 });
            context.SaveChanges();
        }
        [TestMethod]
        public void GetTeaVarietyById_ShouldReturnEarlGrey()
        {
            //testing using Earl Grey, Id = 4
            var result = _teaVarietyService.GetById(4);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Id);
            Assert.AreEqual("Earl Grey", result.Name);
        }
        
       

        [TestMethod]
        public void GetIdByName_ReturnsCorrectId_WhenNameExists()
        {
            int result = _teaVarietyService.GetIdByName("Gyokuro");

            Assert.AreEqual(14, result);
        }



    }
}