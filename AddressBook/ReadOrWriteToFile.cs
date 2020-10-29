using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class ReadOrWriteToFile
    {
        string path = @"C:\Users\Gharat\source\repos\AddressBook\Address Book ContactDetails.txt";
        string csvPath = @"C:\Users\Gharat\source\repos\AddressBook\AddressBookContacts.csv";
        string jsonPath = @"C:\Users\Gharat\source\repos\AddressBook\AddressBookDetails.json";
        public void WriteToFile(string addressBookName, List<ContactDetails> contactList)
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
        public void WriteToCSV(List<ContactDetails> contactList)
        {
            if (FileExitsts(csvPath))
            {
                using (var writer = new StreamWriter(csvPath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(contactList);
                }

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
                Console.WriteLine("File Does Not Exist");
            }
        }
        public void WriteToJsonFile(List<ContactDetails> contactList)
        {
            if (FileExitsts(jsonPath))
            {
                using (StreamWriter r = new StreamWriter(jsonPath))
                {
                    string json = JsonConvert.SerializeObject(contactList);
                    r.WriteLine(json);
                }
            }
            else
                Console.WriteLine("File Does Not Exist");
        }
        public void ReadFromJsonFile()
        {
            if (FileExitsts(jsonPath))
            {
                using (StreamReader r = new StreamReader(jsonPath))
                {
                    string json = r.ReadToEnd();
                    List<ContactDetails> records = JsonConvert.DeserializeObject<List<ContactDetails>>(json);
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
                Console.WriteLine("File Does Not Exist");
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