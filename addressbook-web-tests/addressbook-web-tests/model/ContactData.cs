using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContactInformation;
        private string allDetails;

        public ContactData()
        {
        }
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        override public int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }
        public override string ToString()
        {
            return "First name=" + FirstName + "\nLast name=" + LastName + "\nMiddlename=" + Middlename + "\nNotes=" + Notes + "\nAddress=" + Address + "\nHomePhone=" + HomePhone + "\nMobilePhone=" + MobilePhone + "\nWorkPhone=" + WorkPhone;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compare = this.LastName.CompareTo(other.LastName);

            if (compare == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            else
            {
                return compare;
            }
        }

        public string StringHomePage(string homepage)
        {
            if (homepage == null || homepage == "")
            {
                return "";
            }
            return "Homepage:" + "\r\n" + homepage;
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Byear { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string Details { get; set; }

        public string AllPhones
        {
            get
            { 
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
            } 
            set
            {
                allPhones = value; 
            }
         }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (EndLineSymbols(Email) + EndLineSymbols(Email2) + EndLineSymbols(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return Details.Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }

        public string AllContactInformation
        {
            get
            {
                if (allContactInformation != null)
                {
                    return allContactInformation;
                }
                else
                {
                    return (EndLineSymbols(EndLineSymbols(ContactDetailsList(
                        FirstName, Middlename, LastName, Nickname, Title, Company, Address)))
                        + EndLineSymbols(EndLineSymbols(GetTelephoneList(HomePhone, MobilePhone, WorkPhone)))
                        + EndLineSymbols(EndLineSymbols(GetEmailList(Email, Email2, Email3, Homepage)))
                        + StartLineSymbols(Notes)).Trim();
                }
            }
            set
            {
                allContactInformation = value;
            }
        }

        public string StartLineSymbols(string line)
        {
            if (line == null || line == "")
            {
                return "";
            }
            return "\r\n" + line;
        }
        public string EndLineSymbols(string line)
        {
            if (line == null || line == "")
            {
                return "";
            }
            return line + "\r\n";
        }

        public string GetFullName(string firstname, string middlename, string lastname)
        {
            string form = "";

            if (firstname != null && firstname != "")
            {
                form = FirstName + " ";
            }
            if (middlename != null && middlename != "")
            {
                form = form + Middlename + " ";
            }
            if (lastname != null && lastname != "")
            {
                form = form + LastName + " ";
            }
            return form.Trim();
        }

        public string ContactDetailsList(
          string firstname,
          string middlename,
          string lastname,
          string nickname,
          string title,
          string company,
          string address)
        {
            return (EndLineSymbols(GetFullName(firstname, middlename, lastname))
                + EndLineSymbols(nickname)
                + EndLineSymbols(title)
                + EndLineSymbols(company)
                + EndLineSymbols(address)).Trim();
        }

        public string GetTelephoneList(string home, string mobile, string work)
        {
            string form = "";

            if (home != null && home != "")
            {
                form = form + "H: " + EndLineSymbols(HomePhone);
            }
            if (mobile != null && mobile != "")
            {
                form = form + "M: " + EndLineSymbols(MobilePhone);
            }
            if (work != null && work != "")
            {
                form = form + "W: " + EndLineSymbols(WorkPhone);
            }
            return form.Trim();
        }

        public string GetEmailList(string email, string email2, string email3, string homepage)
        {
            string form = "";

            if (email != null && email != "")
            {
                form = form + EndLineSymbols(email);
            }
            if (email2 != null && email2 != "")
            {
                form = form + EndLineSymbols(email2);
            }
            if (email3 != null && email3 != "")
            {
                form = form + EndLineSymbols(email3);
            }
            if (homepage != null && homepage != "")
            {
                form = form + EndLineSymbols(StringHomePage(homepage));
            }
            return form.Trim();
        }


        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return  Regex.Replace(phone, "[ -()]","") + "\r\n";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "00.00.0000 0:00:00") select c).ToList();
            }
        }
    }
}
