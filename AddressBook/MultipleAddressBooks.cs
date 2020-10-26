﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AddressBook
{
    class MultipleAddressBooks
    {
        Dictionary<string, Address_Book> addressBooksCollection = new Dictionary<string, Address_Book>();
        public Dictionary<string, List<ContactDetails>> ContactByCity;
        public Dictionary<string, List<ContactDetails>> ContactByState;
        List<string> cities;
        List<string> states;
        public MultipleAddressBooks()
        {
            addressBooksCollection = new Dictionary<string, Address_Book>();
            ContactByCity = new Dictionary<string, List<ContactDetails>>();
            ContactByState = new Dictionary<string, List<ContactDetails>>();
            cities = new List<string>();
            states = new List<string>();

        }
        public void AddAddressBook(string name)
        {
            Address_Book addressBook = new Address_Book();
            if (addressBooksCollection.ContainsKey(name) == false)
            {
                addressBooksCollection.Add(name, addressBook);
                Console.WriteLine("Address Book Added Successfully");
            }
            else
            {
                Console.WriteLine("Address Book Already Exist");
            }

        }
        public Address_Book GetAddressBook(string name)
        {
            if (addressBooksCollection.ContainsKey(name))
            {
                return addressBooksCollection[name];
            }
            return null;
        }
        public void GetDistinctCityAndStateList()
        {
            foreach (var addressBook in addressBooksCollection)
            {
                foreach (var contact in addressBook.Value.contactList)
                {
                    if (cities.Contains(contact.City) == false)
                    {
                        cities.Add(contact.City);
                    }
                    if (states.Contains(contact.State) == false)
                    {
                        states.Add(contact.State);
                    }

                }
            }
        }
        public void SetContactByCityDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string city in cities)
            {
                List<ContactDetails> ContactDetails = new List<ContactDetails>();
                foreach (var addressBook in addressBooksCollection)
                {
                    ContactDetails.AddRange(addressBook.Value.GetPersonByCityOrState(city));
                }
                if (ContactByCity.ContainsKey(city))
                {
                    ContactByCity[city] = ContactDetails;
                }
                else
                {
                    ContactByCity.Add(city, ContactDetails);
                }
            }

        }
        public void SetContactByStateDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string state in states)
            {
                List<ContactDetails> ContactDetails = new List<ContactDetails>();
                foreach (var addressBook in addressBooksCollection)
                {
                    ContactDetails.AddRange(addressBook.Value.GetPersonByCityOrState(state));
                }
                if (ContactByState.ContainsKey(state))
                {
                    ContactByState[state] = ContactDetails;
                }
                else
                {
                    ContactByState.Add(state, ContactDetails);
                }
            }

        }
        public void ViewPersonsByCity(string city)
        {
            if (ContactByCity.ContainsKey(city))
            {
                foreach (ContactDetails contact in ContactByCity[city])
                {
                    contact.ToString();
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
        public void ViewPersonsByState(string state)
        {
            if (ContactByState.ContainsKey(state))
            {
                foreach (ContactDetails contact in ContactByState[state])
                {
                    contact.ToString();
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }

    }
}