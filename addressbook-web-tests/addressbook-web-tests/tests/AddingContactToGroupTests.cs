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
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {

                app.Navigator.OpenHomePage();
                app.Contacts.CheckForAtLeastOneContact();

                app.Navigator.GoToGroupsPage();
                app.Groups.CheckForAtLeastOneGroup();

                List<GroupData> groups = GroupData.GetAll();
                GroupData group = groups[0];

                List<ContactData> oldList = ContactData.GetAll();
                ContactData contact = oldList[0];                
                int numberOfGroups = groups.Count();
                for (int i = 0; i < numberOfGroups; i++)
                {
                    group = groups[i];
                    oldList = group.GetContacts();
                    try
                    {
                        contact = ContactData.GetAll().Except(oldList).First();
                        break;
                    }
                    catch (InvalidOperationException)
                    {
                        if ((numberOfGroups - 1) == i)
                        {
                            app.Contacts.Add(new ContactData("Test1", "User1"));
                            contact = ContactData.GetAll()[0 + oldList.Count];
                        }
                    }
                }

                app.Contacts.AddContactToGroup(contact, group);

                List<ContactData> newList = group.GetContacts();
                oldList.Add(contact);
                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);
            }
        }
}