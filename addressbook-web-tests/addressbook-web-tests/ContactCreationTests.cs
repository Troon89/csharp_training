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
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.AddNewContact();
            ContactData contact = new ContactData("User1", "Test1");
            contact.Middlename = "Middlename1";
            contact.Notes = "123";
            contactHelper.FillContactForm(contact);
            navigator.ReturnToHomePage();
            loginHelper.Logout();
        }
    }
}
