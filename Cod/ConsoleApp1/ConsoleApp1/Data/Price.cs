using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data
{
    public record Price
    {
        public decimal Value { get; }
        public Price(decimal value)
        {
            if (value > 0)
            {
                Value = value;
            }

        }
        public Price Round()
        {
            var roundedValue = Math.Round(Value);
            return new Price(roundedValue);
        }
        public override string ToString()
        {
            return $"{Value:0.##}";
        }

        public static bool TryParsePret(string gradeString, out Price price)
        {
            bool isValid = false;
            price = null;
            if (decimal.TryParse(gradeString, out decimal priceNumerical))
            {
                if (IsValid(priceNumerical))
                {
                    isValid = true;
                    price = new(priceNumerical);
                }
            }

            return isValid;
        }

        private static bool IsValid(decimal priceNumerical) => priceNumerical > 0;
    }
}
