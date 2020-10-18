using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBook
{
    class ContactDetails
    {
        List<ContactDetails> contacts = new List<ContactDetails>();

        //get and set accessor for each contact details field
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public long phoneNumber { get; set; }
        public string email { get; set; }


        public ContactDetails(string firstName, string lastName, string address, string city, string state, int zipCode, long phoneNumber, string emailId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.phoneNumber = phoneNumber;
            this.email = emailId;

        }

        public ContactDetails()
        {
        }

        public void display()
        {
            Console.WriteLine("\nDisplaying Contacts - \nFirst Name | Last Name | Address |  City  | State | ZIP Code | Phone Number | EmailId");
            foreach (ContactDetails contact in contacts)
            {
                Console.WriteLine(contact.firstName + "\t" + contact.lastName + "\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zipCode + "\t\t" + contact.phoneNumber + "\t" + contact.email);
            }
        }

        //Adding new contact details after taking user input
        public void addNewContact()
        {
            ContactDetails contact = new ContactDetails();
            string namePattern = "^[a-zA-Z ]+$";
            string addressPattern = "^[a-z A-Z 0-9]+$";
            string zipPattern = "[0-9]{6}";
            string phonePattern = "[0-9]{10}";
            string mailPattern = @"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";


            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            if (!Regex.IsMatch(firstName, namePattern))
                throw new Exception("Name should be alphabetical!");
            else
                contact.firstName = firstName;


            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            if (!Regex.IsMatch(lastName, namePattern))
                throw new Exception("Name should be alphabetical!");
            else
                contact.lastName = lastName;


            Console.Write("Enter Address:");
            string address = Console.ReadLine();
            if (!Regex.IsMatch(address, addressPattern))
                throw new Exception("Address should be in proper format!");
            else
                contact.address = address;


            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            if (!Regex.IsMatch(city, namePattern))
                throw new Exception("City name should be in proper format!");
            else
                contact.city = city;


            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            if (!Regex.IsMatch(state, namePattern))
                throw new Exception("State should be in proper format!");
            else
                contact.state = state;


            Console.Write("Enter ZIP Code: ");
            string zip = Console.ReadLine();
            if (!Regex.IsMatch(zip, zipPattern))
                throw new Exception("ZIP Code should be a 6 digit number");
            else
                contact.zipCode = int.Parse(zip);


            Console.Write("Enter Phone Number: ");
            string phNumber = Console.ReadLine();
            if (!Regex.IsMatch(phNumber, phonePattern))
                throw new Exception("Phone number must be a 10 digit number!");
            else
                contact.phoneNumber = long.Parse(phNumber);


            Console.Write("Enter Email Id: ");
            string mailId = Console.ReadLine();
            if (!Regex.IsMatch(mailId, mailPattern))
                throw new Exception("Check Mail address");
            else
                contact.email = mailId;


            contacts.Add(contact);
            Console.WriteLine("New Contact Details added successfully");
        }


        public void editContact()
        {
            Console.WriteLine("Enter the first name of the person you want to edit information of: ");
            String editName = Console.ReadLine();

            foreach (ContactDetails i in contacts)
            {
                if (i.firstName.Equals(editName))
                {
                    int choiceofedit = 0;
                    while (choiceofedit != 9)
                    {
                        Console.WriteLine("Enter your choice of edit: ");
                        Console.WriteLine("1. Edit First Name");
                        Console.WriteLine("2. Edit Last Name");
                        Console.WriteLine("3. Edit Address");
                        Console.WriteLine("4. Edit City");
                        Console.WriteLine("5. Edit State");
                        Console.WriteLine("6. Edit Zip");
                        Console.WriteLine("7. Edit Phone Number");
                        Console.WriteLine("8. Edit E-mail");
                        Console.WriteLine("9. Exit");
                        choiceofedit = Convert.ToInt32(Console.ReadLine());

                        switch (choiceofedit)
                        {
                            case 1:
                                Console.WriteLine("1. Edit First Name");
                                string fname = Console.ReadLine();
                                i.firstName = fname;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 2:
                                Console.WriteLine("1. Edit Last Name");
                                string lname = Console.ReadLine();
                                i.lastName = lname;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 3:
                                Console.WriteLine("1. Edit Address Name");
                                string aAddress = Console.ReadLine();
                                i.address = aAddress;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 4:
                                Console.WriteLine("1. Edit City Name");
                                string cCity = Console.ReadLine();
                                i.city = cCity;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 5:
                                Console.WriteLine("1. Edit State");
                                string sState = Console.ReadLine();
                                i.state = sState;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 6:
                                Console.WriteLine("1. Edit Zip");
                                int zCode = Convert.ToInt32(Console.ReadLine());
                                i.zipCode = zCode;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 7:
                                Console.WriteLine("1. Edit Phone Number");
                                long phNum = Convert.ToInt64(Console.ReadLine());
                                i.phoneNumber = phNum;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 8:
                                Console.WriteLine("1. Edit Email");
                                string mail = Console.ReadLine();
                                i.email = mail;
                                Console.WriteLine("Edited Successfully");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Name does not match! Please enter valid name.");
                }
            }
        }

        public void deleteContact()
        {
            Console.WriteLine("Enter the first name of the person to delete the contact: ");
            string deleteName = Console.ReadLine();
            List<ContactDetails> contacts1 = new List<ContactDetails>();
            foreach (ContactDetails i in contacts)
            {
                if (i.firstName.Equals(deleteName))
                {
                    contacts1.Add(i);
                }
            }
            contacts.RemoveAll(i => contacts1.Contains(i));
            Console.WriteLine("Successfully Deleted Contact!");
        }
    }
}
