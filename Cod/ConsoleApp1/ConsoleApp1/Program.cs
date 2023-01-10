using ConsoleApp1.Data;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var list = ReadList().ToArray();

            Console.WriteLine("Te salut!");
        }

        private static List<Address> ReadList()
        {
            List<Address> list = new();

            do
            {
                var name = ReadValue("Name: ");
                if (string.IsNullOrEmpty(name))
                {
                    break;
                }

                var lastname = ReadValue("Last Name: ");
                if (string.IsNullOrEmpty(lastname))
                {
                    break;
                }

                var town = ReadValue("Town: ");
                if (string.IsNullOrEmpty(town))
                {
                    break;
                }

                var street = ReadValue("Street: ");
                if (string.IsNullOrEmpty(street))
                {
                    break;
                }

                var county = ReadValue("County: ");
                if (string.IsNullOrEmpty(county))
                {
                    break;
                }

                var zipcode = ReadValue("Zipcode: ");
                if (string.IsNullOrEmpty(zipcode))
                {
                    break;
                }

                list.Add(new Address(name,lastname,town,street,county,zipcode));
            } while(true);

            return list;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}