using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecruitJr.DAL.Postgresql.Tests
{
    public class TestBase
    {
        protected RsPostgresContext ctx;

        [TestInitialize]
        public void TestInitialize() {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("Test");
            var options = optionsBuilder.Options;
            ctx = new RsPostgresContext(options);
        }

        [TestCleanup]
        public void TestCleanup() {
            ctx = null;
        }
    }
}