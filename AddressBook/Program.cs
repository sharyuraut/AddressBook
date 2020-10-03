using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");

            //created list for contact details 
            List <ContactDetails> contactDetails = new List<ContactDetails>();
            ContactDetails contact = new ContactDetails();

            //call addNewContact to add contact details
            contact.addNewContact();

            // call display method to display added details
            contact.display();


        }
    }
}
