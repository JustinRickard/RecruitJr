using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecruitJr.DAL.Postgresql.Tests
{
    public class TestBase
    {
        protected DbContextOptions options;

        [TestInitialize]
        public void TestInitialize() {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("Test");
            options = optionsBuilder.Options;
        }

        [TestCleanup]
        public void TestCleanup() {
            options = null;
        }
    }
}