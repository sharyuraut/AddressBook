using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Address_Book
    {
        List<ContactDetails> contactList;

        public Address_Book()
        {
            contactList = new List<ContactDetails>();
        }
        public void addContact(string firstName, string lastName, string address, string city, string state, int zipCode, long phoneNumber, string email)
        {
            ContactDetails contact = new ContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
            contactList.Add(contact);
        }
        public void editContact(string firstName, string lastName, string address, string city, string state, int zipCode, long phoneNumber, string email)
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
                    c.phoneNumber = phoneNumber;
                    c.email = email;
                    return;
                }
            }
        }
        public void RemoveContact(string name)
        {
            foreach (ContactDetails c in contactList)
            {
                if (c.firstName.Equals(name))
                {
                    contactList.Remove(c);
                    return;
                }
            }
        }
        public bool checkName(string firstName)
        {
            foreach (ContactDetails c in contactList)
            {
                if (c.firstName.Equals(firstName))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
