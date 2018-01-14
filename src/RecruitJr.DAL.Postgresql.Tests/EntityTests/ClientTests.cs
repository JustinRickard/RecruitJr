using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecruitJr.DAL.Postgresql;

namespace RecruitJr.DAL.Postgresql.Tests.EntityTests
{
    [TestClass]
    public class ClientTests : TestBase
    {      
        [TestMethod]
        public void ShouldAdd()
        {
            using (var ctx = new RsPostgresContext(options)) {
                
            }
        }
    }
}
