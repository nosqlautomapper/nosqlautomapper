﻿using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoSqlAutomapper.Adapters.Raven;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;

namespace NoSqlAutomapper.Test.DomainTests
{
    [TestClass]
    public class DomainTestBase
    {
        private static IDocumentStore Database { get; set; }

        protected static IDocumentSession Session { get; set; }

        protected IConfiguration Configuration { get; set; }

        [AssemblyInitialize]
        public static void InitDatabase(TestContext context)
        {
            Database = new DocumentStore() { ConnectionStringName = "defaultDatabase", DefaultDatabase = "Test"};
            Database.Initialize();

            NoSqlMapper.Init(new RavenDbAdapter(() => Session, Database));
        }

        [AssemblyCleanup]
        public static void DisposeDatabse()
        {
            Database.Dispose();
        }

        [TestInitialize]
        public void TestInit()
        {
            Session = Database.OpenSession();
            Mapper.Reset();
            Configuration = Mapper.Configuration;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Database.DatabaseCommands.DeleteByIndex("Raven/DocumentsByEntityName",
                new IndexQuery(),
                allowStale: false
            );

            Session.Dispose();
        }
    }
}
