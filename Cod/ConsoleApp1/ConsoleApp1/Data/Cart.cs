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
            public CosNevalidat(IReadOnlyCollection<ProdusAlesNevalidat> listProducts)
            {
                ListProducts = listProducts;
            }

            public IReadOnlyCollection<ProdusAlesNevalidat> ListProducts { get; }
        }

        public record CosInvalidat : ICart
        {
            internal CosInvalidat(IReadOnlyCollection<ProdusAlesNevalidat> listProducts, string motiv)
            {
                ListProducts = listProducts;
                Motiv = motiv;
            }

            public IReadOnlyCollection<ProdusAlesNevalidat> ListProducts { get; }
            public string Motiv { get; }
        }


        public record CosValidat : ICart
        {
            internal CosValidat(IReadOnlyCollection<ProdusAlesValidat> listProducts)
            {
                ListProducts = listProducts;
            }

            public IReadOnlyCollection<ProdusAlesValidat> ListProducts { get; }
        }

        public record CosPlatit : ICart
        {
            internal CosPlatit(IReadOnlyCollection<ProdusAlesValidat> listProducts, string csv, DateTime dataPlata)
            {
                ListProducts = listProducts;
                DataPlata = dataPlata;
                Csv = csv;
            }
            public IReadOnlyCollection<ProdusAlesValidat> ListProducts { get; }
            public DateTime DataPlata { get; }
            public string Csv { get; }
        }
    }
}
