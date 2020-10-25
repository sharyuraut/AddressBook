﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class OperationOnAddressBook
    {
        public void EditAddOrDeleteContact(Address_Book addressBook)
        {
            string[] name;
            int choice = 0;
            string[] details;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("1.Add Contact\n2.Edit Contact\n3.Remove a contact\n4.Sort By Name\n5.Sort By City\n6.Sort By State\n7.Sort By ZipCode\n8.Write To File\n9.Exit");
                Console.WriteLine("------------------------------------------------------------------------");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the details separated by comma");
                        Console.WriteLine("First Name, Last Name, Address, City, State, ZipCode,Phone No Email");
                        details = Console.ReadLine().Split(",");

                        string message = addressBook.AddContact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);

                        Console.WriteLine(message);

                        break;
                    case 2:
                        Console.WriteLine("Enter the name to edit");
                        name = Console.ReadLine().Split(" ");

                        if (addressBook.CheckName(name[0], name[1]) == true)
                        {
                            Console.WriteLine("Enter the following details separated by comma");
                            Console.WriteLine("FirstName,LastName,Address, City, State, ZipCode,Phone No Email");
                            details = Console.ReadLine().Split(",");
                            addressBook.EditContact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);
                            Console.WriteLine("Details editted successfully");
                        }
                        else
                        {
                            Console.WriteLine("No such contact found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the name to be removed");
                        name = Console.ReadLine().Split(" ");
                        if (addressBook.CheckName(name[0], name[1]) == true)
                        {
                            addressBook.RemoveContact(name[0], name[1]);
                            Console.WriteLine("Contact Removed Successfully");
                        }
                        else
                        {
                            Console.WriteLine("No such contact found");
                        }
                        break;
                    case 4:
                        addressBook.SortByName();
                        break;
                    case 5:
                        addressBook.SortByCity();
                        break;
                    case 6:
                        addressBook.SortByState();
                        break;
                    case 7:
                        addressBook.SortByZipCode();
                        break;
                    case 8:
                        addressBook.ClearFile();
                        addressBook.WriteToFile();
                        Console.WriteLine("Written to file successfully");
                        break;
                    case 9:
                        flag = false;
                        break;
                    default:
                        break;
                }

            }
        }

    }
}
