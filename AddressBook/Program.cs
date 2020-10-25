﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            string addBookName = "";

            MultipleAddressBooks multipleAddressBooks = new MultipleAddressBooks();
            OperationOnAddressBook operation = new OperationOnAddressBook();
            Address_Book addressBook = null;

            Console.WriteLine("Welcome to Address Book Program");
            while (true)
            {

                Console.WriteLine("1.Add Address Book\n2.Edit Or Add Contact in Address Book\n3.View Persons By City\n4.View Persons By State\n5.Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name of Address Book");
                        addBookName = Console.ReadLine();
                        multipleAddressBooks.AddAddressBook(addBookName);

                        break;
                    case 2:
                        Console.WriteLine("Enter name of Address Book");
                        addBookName = Console.ReadLine();
                        addressBook = multipleAddressBooks.GetAddressBook(addBookName);

                        if (addressBook != null)
                        {
                            operation.EditAddOrDeleteContact(addressBook);

                        }
                        else
                        {
                            Console.WriteLine("No such Adress Book");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter City");
                        string city = Console.ReadLine();
                        multipleAddressBooks.SetContactByCityDictionary();

                        multipleAddressBooks.ViewPersonsByCity(city);
                        break;
                    case 4:
                        Console.WriteLine("Enter State");
                        string state = Console.ReadLine();

                        multipleAddressBooks.SetContactByStateDictionary();
                        multipleAddressBooks.ViewPersonsByState(state);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
