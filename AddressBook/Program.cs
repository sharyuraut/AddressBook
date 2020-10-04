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
            List<ContactDetails> contactDetails = new List<ContactDetails>();
            ContactDetails contact = new ContactDetails();

            int option = 0;
            while (option != 4)
            {
                Console.WriteLine("\n1. Display All Contacts\n2. Add New Contact\n3. Edit a Contact\n4. Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Displaying Contacts");
                        contact.display();
                        break;

                    case 2:
                        Console.WriteLine("Add New Contact.");
                        contact.addNewContact();
                        break;

                    case 3:
                        contact.editContact();
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Enter valid option.");
                        break;
                }
            }

        }
    }
}
