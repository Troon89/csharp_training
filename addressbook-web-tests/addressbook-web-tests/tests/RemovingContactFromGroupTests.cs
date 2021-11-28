using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Linq;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        private ContactData contact;

        [Test]
        public void TestRemovingContactFromGroup()
        {
            app.Navigator.OpenHomePage();
            app.Contacts.CheckForAtLeastOneContact();

            app.Navigator.GoToGroupsPage();
            app.Groups.CheckForAtLeastOneGroup();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count != 0)
            {
                contact = oldList[0];
            }
            else
            {
                contact = ContactData.GetAll()[0];
                app.Contacts.AddContactToGroup(contact, group);
            }
            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
