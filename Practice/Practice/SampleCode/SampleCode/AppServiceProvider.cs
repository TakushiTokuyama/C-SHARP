using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    public class AppServiceProvider
    {
        public void Register()
        {
            var input = Console.ReadLine().ToString();

            User user;

            if (input == "test")
            {
                user = new DummyUserRepository().FindUserByToken("123");

                Console.WriteLine(user.Name);
            }
            else
            {
                var token = Console.ReadLine().ToString();

                user = new UserRepository().FindUserByToken(token);

                Console.WriteLine(user.Name);
            }
        }
    }
}
