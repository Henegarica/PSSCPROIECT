using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class TownException : Exception
    {
        public TownException()
        {
        }

        public TownException(string? message) : base(message)
        {
        }

        public TownException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TownException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
