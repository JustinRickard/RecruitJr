using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecruitJr.DAL.Postgresql;
using RecruitJr.DAL.Postgresql.Repositories;

namespace RecruitJr.DAL.Postgresql.Tests.EntityTests
{
    [TestClass]
    public class ClientTests : TestBase
    {
        ClientRepository repo;

        [TestInitialize]
        public void TestInitializeClient() {
            repo = new ClientRepository(ctx);
        }

        [TestMethod]
        public void UnknownIdShouldReturnEmpty()
        {
            var unknownId = Guid.NewGuid().ToString();
            var maybeClient = repo.GetById(unknownId);
            Assert.IsTrue(maybeClient.HasNoValue);
        }
    }
}
