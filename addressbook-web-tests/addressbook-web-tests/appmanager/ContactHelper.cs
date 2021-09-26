using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper Add(ContactData contact)
        {
            AddNewContact();
            FillContactForm(contact);
            SubmitContactAdding();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            if (!IsElementPresent(By.XPath("//*[@title='Edit'][1]")))
            {
                ContactData contact = new ContactData("User1", "Test1");
                contact.Middlename = "Middlename1";
                contact.Notes = "123";
                Add(contact);
            }
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            if (!IsElementPresent(By.XPath("//*[@title='Edit'][1]")))
            {
                ContactData contact = new ContactData("User1", "Test1");
                contact.Middlename = "Middlename1";
                contact.Notes = "123";
                Add(contact);
            }
            SelectContact(v);
            RemoveContact();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//*[@type='button' and @value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SubmitContactAdding()
        {
            driver.FindElement(By.XPath("//input[@type='submit' and @value = 'Enter']")).Click();
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//*[@title='Edit'])["+ index +"]")).Click();
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//*[@class='center']//*[@type='checkbox'])["+ index +"]")).Click();
            return this;
        }
    }
}
