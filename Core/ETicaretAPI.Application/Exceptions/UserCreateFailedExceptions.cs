using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class UserCreateFailedExceptions : Exception
    {
        public UserCreateFailedExceptions(string? message) : base(message)
        {
        }

        public UserCreateFailedExceptions(string? message, Exception innerException) : base(message, innerException)
        {
        }

        public UserCreateFailedExceptions() : base("User Create Failed")
        {
        }
    }
}
