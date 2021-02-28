using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class EmployeeListNotFounddException : Exception
    {
        public EmployeeListNotFounddException()
        {

        }

        public EmployeeListNotFounddException(string message)
        : base(message)
        {
           
        }

        public EmployeeListNotFounddException(string message, Exception inner)
        : base(message,inner)
        {
            Console.WriteLine(message, inner);
        }

    }
}
