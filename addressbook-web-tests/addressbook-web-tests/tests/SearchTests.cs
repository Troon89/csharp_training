using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            app.Contacts.UseSearch("User2");
            int NumberOfSearchResults = app.Contacts.GetNumberOfSearchResults();
            int NumberOfString = app.Contacts.GetNumberOfDesplayedSrting();
            Assert.AreEqual(NumberOfSearchResults, NumberOfString);
        }
    }
}
