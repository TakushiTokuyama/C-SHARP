using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void ProcessString(string s) 
        {
            if (s == null) 
            {
                throw new EmployeeListNotFounddException("aaaa");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                
                string s = null;
                ProcessString(s);

            }
            catch (EmployeeListNotFounddException ex)
            {
                Console.WriteLine("{0} First exception caught.", ex.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("{0} Second exception caught.", ex);
            }

        }
    }
}
