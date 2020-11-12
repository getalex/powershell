using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;
using Microsoft.SharePoint.Client;

namespace PnP.PowerShell.Tests.Lists
{
    [TestClass]
    public class GetListTests
    {
        private string listTitle;
        private PSTestScope scope;

        // #region Setup
        [TestInitialize]
        public void Initialize()
        {
            using (var context = TestCommon.CreateClientContext())
            {
                var lists = context.Web.Lists;
                context.Load(lists);
                context.ExecuteQueryRetry();

                listTitle = lists[0].Title;
            }
            scope = new PSTestScope(true);
        }

        [TestCleanup]
        public void Cleanup()
        {
            scope?.Dispose();
        }
        // #endregion

        #region Scaffolded Cmdlet Tests
        //TODO: This is a scaffold of the cmdlet - complete the unit test
        [TestMethod]
        public void GetPnPListTest()
        {
            var results = scope.ExecuteCommand("Get-PnPList");
            Assert.IsNotNull(results);
            // using (var scope = new PSTestScope(true))
            // {
            //     // Complete writing cmd parameters

            //     var results = scope.ExecuteCommand("Get-PnPList");
            //     Assert.IsNotNull(results);
            // }
        }

        [TestMethod]
        public void GetPnPSpecifiedListTest()
        {
            var results = scope.ExecuteCommand("Get-PnPList", new CommandParameter("Identity", listTitle));
            Assert.IsNotNull(results);

            // using(var scope = new PSTestScope())
            // {
            //     var results = scope.ExecuteCommand("Get-PnPList", new CommandParameter("Identity",listTitle));
            //     Assert.IsNotNull(results);
            // }
        }
        #endregion
    }
}