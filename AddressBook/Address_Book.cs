using System;
using System.Collections.Generic;
using System.IO;
using System.Dynamic;
using System.Text;

namespace AddressBook
{
    class Address_Book
    {
        public List<ContactDetails> contactList;


        public Address_Book()
        {
            contactList = new List<ContactDetails>();

        }
        public string AddContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            if (CheckName(firstName, lastName) == false)
            {
                ContactDetails contact = new ContactDetails(firstName, lastName, address, city, state, zipCode, phoneNo, eMail);
                contactList.Add(contact);
                return "Details Added Successfully";
            }
            return "Name already exists";
        }
        public void EditContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            foreach (ContactDetails c in contactList)
            {
                if (c.firstName.Equals(firstName))
                {
                    c.lastName = lastName;
                    c.address = address;
                    c.city = city;
                    c.state = state;
                    c.zipCode = zipCode;
                    c.phoneNo = phoneNo;
                    c.eMail = eMail;

                    return;
                }
            }
        }
        public void RemoveContact(string firstName, string lastName)
        {
            foreach (ContactDetails c in contactList)
            {
                if (c.firstName.Equals(firstName) && c.lastName.Equals(lastName))
                {
                    contactList.Remove(c);

                    return;
                }
            }
        }
        public bool CheckName(string firstName, string lastName)
        {

            foreach (ContactDetails contact in contactList.FindAll(e => e.firstName.Equals(firstName) && e.lastName.Equals(lastName)))
            {
                return true;
            }
            return false;
        }
        public List<ContactDetails> GetPersonByCityOrState(string cityOrState)
        {
            List<ContactDetails> contact = new List<ContactDetails>();
            foreach (ContactDetails c in contactList.FindAll(e => e.city.Equals(cityOrState) || e.state.Equals(cityOrState)))
            {
                contact.Add(c);
            }
            return contact;
        }
        public void SortByName()
        {
            contactList.Sort((contact1, contact2) => contact1.firstName.CompareTo(contact2.firstName));
            foreach (ContactDetails c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void SortByCity()
        {
            contactList.Sort((contact1, contact2) => contact1.city.CompareTo(contact2.city));
            foreach (ContactDetails c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void SortByState()
        {
            contactList.Sort((contact1, contact2) => contact1.state.CompareTo(contact2.state));
            foreach (ContactDetails c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void SortByZipCode()
        {
            contactList.Sort((contact1, contact2) => contact1.zipCode.CompareTo(contact2.zipCode));
            foreach (ContactDetails c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }


    }
}
