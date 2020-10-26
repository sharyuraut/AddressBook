using CsvHelper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class Address_Book
    {
        public List<ContactDetails> contactList;
        string path = @"C:\Users\HP LAPTOP\source\repos\AddressBook\AddressBook";
        string csvPath = @"C:\Users\HP LAPTOP\source\repos\AddressBook\AddressBook";
        public Address_Book()
        {
            contactList = new List<ContactDetails>();

        }
        public string AddContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            if (CheckName(firstName, lastName) == false)
            {
                ContactDetails contact = new ContactDetails(firstName, lastName, address, city, state, zipCode, phoneNo, eMail);
                contactList.Add(contact);
                return "Details Added Successfully";
            }
            return "Name already exists";
        }
        public void EditContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            foreach (ContactDetails c in contactList)
            {
                if (c.FirstName.Equals(firstName))
                {
                    c.LastName = lastName;
                    c.Address = address;
                    c.City = city;
                    c.State = state;
                    c.ZipCode = zipCode;
                    c.PhoneNo = phoneNo;
                    c.EMail = eMail;

                    return;
                }
            }
        }
        public void RemoveContact(string firstName, string lastName)
        {
            foreach (ContactDetails c in contactList)
            {
                if (c.FirstName.Equals(firstName) && c.LastName.Equals(lastName))
                {
                    contactList.Remove(c);

                    return;
                }
            }
        }
        public bool CheckName(string firstName, string lastName)
        {

            foreach (ContactDetails contact in contactList.FindAll(e => e.FirstName.Equals(firstName) && e.LastName.Equals(lastName)))
            {
                return true;
            }
            return false;
        }
        public List<ContactDetails> GetPersonByCityOrState(string cityOrState)
        {
            List<ContactDetails> contact = new List<ContactDetails>();
            foreach (ContactDetails c in contactList.FindAll(e => e.City.Equals(cityOrState) || e.State.Equals(cityOrState)))
            {
                contact.Add(c);
            }
            return contact;
        }
        public void SortByName()
        {
            contactList.Sort((contact1, contact2) => contact1.FirstName.CompareTo(contact2.FirstName));
            foreach (ContactDetails c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void SortByCity()
        {
            contactList.Sort((contact1, contact2) => contact1.City.CompareTo(contact2.City));
            foreach (ContactDetails c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void SortByState()
        {
            contactList.Sort((contact1, contact2) => contact1.State.CompareTo(contact2.State));
            foreach (ContactDetails c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void SortByZipCode()
        {
            contactList.Sort((contact1, contact2) => contact1.ZipCode.CompareTo(contact2.ZipCode));
            foreach (ContactDetails c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void WriteToFile(string addressBookName)
        {
            if (FileExitsts(path))
            {
                int count = 0;

                using (StreamWriter sr = File.AppendText(path))
                {
                    sr.WriteLine(addressBookName + ":");
                    foreach (ContactDetails c in contactList)
                    {
                        sr.WriteLine(++count + " " + c.ToString() + "\n");

                    }
                    sr.Close();
                }
                Console.WriteLine("Written to file successfully");
            }
            else
            {
                Console.WriteLine("File Does Not Exist");
            }

        }
        public void ReadFromFile()
        {
            if (FileExitsts(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    String s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

            }
        }
        public void WriteToCSV()
        {
            if (FileExitsts(csvPath))
            {
                using (var writer = new StreamWriter(csvPath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(contactList);
                }
                Console.WriteLine("Records Added Successfully");
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        public void ReadFromCSV()
        {
            if (FileExitsts(csvPath))
            {
                using (var reader = new StreamReader(csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<ContactDetails>().ToList();
                    Console.WriteLine("Data reading done successfully");
                    foreach (ContactDetails ContactDetails in records)
                    {
                        Console.Write("\t" + ContactDetails.FirstName);
                        Console.Write("\t" + ContactDetails.LastName);
                        Console.Write("\t" + ContactDetails.Address);
                        Console.Write("\t" + ContactDetails.City);
                        Console.Write("\t" + ContactDetails.State);
                        Console.Write("\t" + ContactDetails.ZipCode);
                        Console.Write("\t" + ContactDetails.PhoneNo);
                        Console.Write("\t" + ContactDetails.EMail);
                        Console.Write("\n");

                    }
                }
            }
            else
            {
                Console.WriteLine("No such file found");
            }
        }
        public void ClearFile()
        {
            File.WriteAllText(path, string.Empty);
        }
        public bool FileExitsts(string filePath)
        {
            if (File.Exists(filePath))
                return true;
            return false;
        }

    }
}
