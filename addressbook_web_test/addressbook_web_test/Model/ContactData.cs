using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
       
        public ContactData(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public string Id { get; set; }
        
        public string MiddleName { get; set; }
       
        public string Photo { get; set; }
       
        public string Company { get; set;  }
       
        public string Title { get; set; }
        
        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }
       
        public string Fax { get; set; }
        
        public string Email { get; set; }

        public string Email2 { get; set; }
       
        public string Email3 { get; set; }
        
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
            return FirstName.GetHashCode() + LastName.GetHashCode();
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

        public override string ToString()
        {
            return "FirstName = " + FirstName + ", LastName = " + LastName;
        }
    }
}
