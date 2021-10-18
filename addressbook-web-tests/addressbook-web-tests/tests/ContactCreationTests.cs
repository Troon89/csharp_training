using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("User1", "Test1");
            contact.Middlename = "Middlename1";
            contact.Notes = "123";
            contact.Address = "TestAddress";
            contact.HomePhone = "+79630000000";
            contact.MobilePhone = "+79630000001";
            contact.WorkPhone = "+79630000002";


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Add(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Middlename = "";
            contact.Notes = "";

            app.Contacts.Add(contact);
        }
        //не получилось добавить сравнение списка в этот тест 
        //если в списке имеется пуcтой контакт, сравение падает с ошибкой: Индекс находился вне границ массива.  
    }
}
