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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.AddNewContact();
            ContactData contact = new ContactData("User1", "Test1");
            contact.Middlename = "Middlename1";
            contact.Notes = "123";
            app.Contacts.FillContactForm(contact);
            app.Navigator.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}
