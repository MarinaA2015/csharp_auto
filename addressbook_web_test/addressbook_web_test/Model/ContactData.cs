using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public ContactData() { }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "MiddleName")]
        public string MiddleName { get; set; }

        [Column(Name = "LastName")]
        public string LastName { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "photo")]
        public string Photo { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string HomePage { get; set; }

        public string BDay { get; set; }

        public string BMonth { get; set; }

        public string BYear { get; set; }

        public string ADay { get; set; }

        public string AMonth { get; set; }

        public string AYear { get; set; }

        public string SecAddress { get; set; }

        public string SecHome { get; set; }

        public string SecNotes { get; set; }


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
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
                return "";
            else
                return Regex.Replace(phone, "[ --()]", "") + "\r\n";

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
            return (FirstName == other.FirstName && LastName == other.LastName);
        }

        public override int GetHashCode()
        {
            if (Id == null)
                return FirstName.GetHashCode() + LastName.GetHashCode();
            else
                return Id.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            string nf = FirstName + LastName;
            return nf.CompareTo(other.FirstName + other.LastName);
        }

        public string Summary()
        {
            string res =  ( 
                            StringConverter(FirstName + MiddleName + LastName, "")
                            + StringConverter(Title, "")
                            + StringConverter(Company, "")
                            + StringConverter(Address, "") + "\r\n"
                            + StringConverter(HomePhone, "H:")
                            + StringConverter(MobilePhone, "M:")
                            + StringConverter(WorkPhone, "W:")
                            + StringConverter(Fax, "F:") + "\r\n"
                            + StringConverter(Email, "")
                            + StringConverter(Email2, "")
                            + StringConverter(Email3, "") + "\r\n"
                            + DateConverter(BDay, BMonth, BYear, "Birthday")
                            + DateConverter(ADay, AMonth, AYear, "Anniversary") + "\r\n"
                            + StringConverter(SecAddress, "") + "\r\n"
                            + StringConverter(SecHome, "P:")
                            + StringConverter(SecNotes, "")
                                                            ).Trim().Replace(" ", "");
            //Console.WriteLine(res);
            return res;
        }

        private string DateConverter(string bDay, string bMonth, string bYear, string v)
        {
            string bDayF = (bDay != null && bDay != "") ? bDay + "." : "";
            string bMonthF = (bMonth != null && bMonth != "-") ? bMonth : "";
            string bYearF = (bYear != null && bYear != "") ? bYear + "(" + (DateTime.Now.Year - int.Parse(bYear)) + ")" + "\r\n" : "";
            return v + bDayF + bMonthF + bYearF;
        }

        private string StringConverter(string value, string prefix)
        {
            return (value != null && value != "") ? prefix + value.Trim() + "\r\n" : "";
        }

        public override string ToString()
        {
            return "FirstName = " + FirstName + ", LastName = " + LastName + ", Company = " + Company + ", Address = " + Address;
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts where c.Deprecated == "0000-00-00 00:00:00" select c ).ToList();
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            ContactData other = (ContactData)obj;

            return ((FirstName == other.FirstName && LastName == other.LastName && Id == null) || Id == other.Id);
        }

       
      
       
    }
}
