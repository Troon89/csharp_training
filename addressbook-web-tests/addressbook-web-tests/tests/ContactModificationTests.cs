using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("User2", "Test2");
            newData.Middlename = "Middlename2";
            newData.Notes = null;

            app.Contacts.CheckForAtLeastOneContact();
            app.Contacts.Modify(1, newData);
        }
    }
}
