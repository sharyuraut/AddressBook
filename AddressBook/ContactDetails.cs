using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBook
{
    class ContactDetails
    {
        public string firstName, lastName, address, city, state, zipCode, phoneNo, eMail;

        public ContactDetails()
        {
            firstName = "";
            lastName = "";
            address = "";
            city = "";
            state = "";
            zipCode = "";
            phoneNo = "";
            eMail = "";
        }
        public ContactDetails(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.phoneNo = phoneNo;
            this.eMail = eMail;
        }
        public override string ToString()
        {
            return "Name :" + firstName + " " + lastName + "\nAddress :" + address + "   ZipCode :" + zipCode + "\nPhone No :" + phoneNo + "   Email :" + eMail;
        }
    }
}
