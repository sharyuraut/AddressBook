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
            while (option != 5)
            {
                Console.WriteLine("\n1. Display all contacts\n2. Add new contact\n3. Edit a contact\n4. Delete a contact\n5. Exit");
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
                        contact.deleteContact();
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("Enter valid option.");
                        break;
                }
            }

        }
    }
}
