using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Data
{
    public record Address
    {

        private static readonly Regex CharacterValid = new("[a-z]");
        private static readonly Regex ZipCodValid = new("[0-9]{6}");
        public string Name { get; }
        public string LastName { get; }
        public string Town { get; }
        public string Street { get; }
        public string County { get; }
        public string ZipCode { get; }


        private Address(string name, string lastname, string town, string street, string county, string zipcode)
        {

            if (CharacterValid.IsMatch(name))
            {
                Name = name;
            }

            if (CharacterValid.IsMatch(lastname))
            {
                LastName = lastname;
            }

            if (CharacterValid.IsMatch(town))
            {
                Town = town;
            }
            else
            {
                throw new TownException("");
            }


            if (CharacterValid.IsMatch(county))
            {
                County = county;
            }
            else
            {
                throw new CountyException("");
            }


            if (CharacterValid.IsMatch(street))
            {
                Street = street;
            }
            else
            {
                throw new StreetException("");
            }



            if (CharacterValid.IsMatch(zipcode))
            {
                ZipCode = zipcode;
            }
            else
            {
                throw new PostalCodeException("");
            }
        }


        private static bool IsValid(string stringValue) => stringValue.Length > 10;

        public override string ToString()
        {
            return Name + " " + LastName + " " + Town + " " + Street + " " + County + " " + ZipCode;
        }

        public static bool TryParseAddress(string stringValue, out Address address)
        {
            bool isValid = false;
            address = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                // address = new(stringValue);
            }

            return isValid;
        }
    }
}
