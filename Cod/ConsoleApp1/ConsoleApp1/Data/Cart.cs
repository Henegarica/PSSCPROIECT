using ConsoleApp1.Models;
using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data
{
    [AsChoice]
    public static partial class Cart
    {
        public interface ICart { }

        public record EmptyCart() : ICart;

        public record CosNevalidat : ICart
        {
            public IReadOnlyCollection<ProductNotValidated> ListProducts { get; }
            public CosNevalidat(IReadOnlyCollection<ProductNotValidated> listProducts)
            {
                ListProducts = listProducts;
            }
        }

        public record CosInvalidat : ICart
        {
            public IReadOnlyCollection<ProductNotValidated> ListProducts { get; }
            public string Motiv { get; }
            internal CosInvalidat(IReadOnlyCollection<ProductNotValidated> listProducts, string motiv)
            {
                ListProducts = listProducts;
                Motiv = motiv;
            }
        }


        public record CosValidat : ICart
        {
            public IReadOnlyCollection<ProductValidated> ListProducts { get; }

            internal CosValidat(IReadOnlyCollection<ProductValidated> listProducts)
            {
                ListProducts = listProducts;
            }

        }

        public record CosPlatit : ICart
        {
            public IReadOnlyCollection<ProductValidated> ListProducts { get; }
            public DateTime DataPlata { get; }
            public string Csv { get; }

            internal CosPlatit(IReadOnlyCollection<ProductValidated> listProducts, string csv, DateTime dataPlata)
            {
                ListProducts = listProducts;
                DataPlata = dataPlata;
                Csv = csv;
            }
        }
    }
}
