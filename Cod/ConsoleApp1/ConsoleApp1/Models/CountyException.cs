using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class CountyException : Exception
    {
        public CountyException()
        {
        }

        public CountyException(string? message) : base(message)
        {
        }

        public CountyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CountyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
