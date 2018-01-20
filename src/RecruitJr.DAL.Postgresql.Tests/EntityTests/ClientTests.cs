using System;
using System.Threading.Tasks;
using RecruitJr.Core.Models;
using RecruitJr.Core.Interfaces.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Abstractions;
using RecruitJr.DAL.Postgresql;
using RecruitJr.DAL.Postgresql.Repositories;

namespace RecruitJr.DAL.Postgresql.Tests.EntityTests
{
    [TestClass]
    public class ClientTests : TestBase
    {
        IClientRepository repo;

        [TestInitialize]
        public void TestInitializeClient() {
            repo = serviceProvider.GetService<IClientRepository>();
        }

        [TestMethod]
        public async Task UnknownIdShouldReturnEmpty()
        {
            var maybeClient = await repo.GetById("9db424a0-587a-4c9f-8cc9-d72d3e19a35d");
            Assert.IsTrue(maybeClient.HasNoValue);
        }

        [TestMethod]
        public async Task AddedClientShouldBeRetrieved()
        {
            string clientId = "edcf1ae4-86fc-48f4-9715-80cf7af3e5c9";

            var newClient = new Client {
                Id = clientId,
                Name="Test Client",
                Code="TEST_CLIENT"
            };
            var maybeClient = await repo.Add(newClient);
            Assert.IsTrue(maybeClient.HasValue);
        }
    }
}
