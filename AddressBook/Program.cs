using System;
using System.Collections.Generic;
using System.Security.Cryptography;

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

            string name = "";
            int choice = 0;
            

            MultipleAddressBooks multipleAddressBooks = new MultipleAddressBooks();
            Address_Book addressBook = null;
            while (true)
            {
                int option = 0;
                while (choice == 0)
                {
                    Console.WriteLine("Choose any one.");
                    Console.WriteLine("1.Add Address Book\n2.Open Address Book");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        if(choice!=1 || choice!=2)
                        {
                            Console.WriteLine("Invalid choice");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Enter a valid Input");
                        choice = 0;
                    }
                }
                Console.WriteLine("Enter name of Address Book");
                name = Console.ReadLine();
                if (choice == 1)
                {
                    multipleAddressBooks.AddAddressBook(name);
                    addressBook = multipleAddressBooks.GetAddressBook(name);
                }
                else if (choice == 2)
                {
                    addressBook = multipleAddressBooks.GetAddressBook(name);
                    if (addressBook == null)
                    {
                        Console.WriteLine("No such Address Book");
                        option = 5;
                    }
                }
                choice = 0;

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
}
