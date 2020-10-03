using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");

            List <ContactDetails> contactDetails = new List<ContactDetails>();
            ContactDetails contact = new ContactDetails();

            contact.addNewContact();

            contact.display();


        }
    }
}
