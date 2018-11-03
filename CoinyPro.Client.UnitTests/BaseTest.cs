using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinyPro.Client.UnitTests
{
    [TestClass]
    public class BaseTest
    {
        protected static CoinyProClient Client;
        [AssemblyInitialize]
        public static void TestContext(TestContext testContext)
        {
            Client = new CoinyProClient("08d609b8-8d4e-c9b6-ed2d-0af43353cb58", "1KAyraZ2raVbZmebPQvnubUDbpOQHvEpMwjFbEG+8XE=");
        }
    }
}
