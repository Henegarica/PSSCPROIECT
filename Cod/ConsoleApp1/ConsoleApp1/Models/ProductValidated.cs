using ConsoleApp1.Data;
using LanguageExt.TypeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public record ProductValidated(Product Product, Address Adress, Price Price);
}
