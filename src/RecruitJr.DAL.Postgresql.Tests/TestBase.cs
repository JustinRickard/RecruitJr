using System;
using RecruitJr.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecruitJr.DAL.Postgresql.Tests
{
    public class TestBase
    {
        protected ServiceProvider serviceProvider;

        [TestInitialize]
        public void TestInitialize() {
            serviceProvider = ConfigurationHelper.BuildServiceProvider();
        }

        [TestCleanup]
        public void TestCleanup() {
            serviceProvider = null;
        }        
    }
}