using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();
            ContactData contact = new ContactData("User1", "Test1");
            contact.Middlename = "Middlename1";
            contact.Notes = "123";
            FillContactForm(contact);
            ReturnToHomePage();
            Logout();
        }
    }
}
