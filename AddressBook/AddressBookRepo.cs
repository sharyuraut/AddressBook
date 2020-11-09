using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook
{
    class AddressBookRepo
    {
        public static string connectionString = @"Data Source='(LocalDb)\AddressBook';Initial Catalog=AddressBook;Integrated Security=True";
        public SqlConnection connection = new SqlConnection(connectionString);

        public static ContactDatabase GetAllContacts()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                ContactDatabase cdb = new ContactDatabase();

                string query = @"select c.first_name, c.last_name, c.city, c.phone_no, b.bk_name, b.bk_type 
                                 from contact c inner join booknametype b on c.book_id = b.book_id WHERE LOWER(c.first_name)='sharyu';";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cdb.firstname = reader.GetString(0);
                        cdb.lastname = reader.GetString(1);
                        cdb.city = reader.GetString(2);
                        cdb.phone = reader.GetString(3);
                        cdb.B_Name = reader.GetString(4);
                        cdb.B_Type = reader.GetString(5);
                    }
                }
                else
                {
                    Console.WriteLine("Rows doesn't exist!");
                }
                reader.Close();
                return cdb;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Close();
            }
        }
    }
}
