using System.Collections.Generic;
using System.Linq;

namespace SampleCode
{
    public class Service
    {
        public User getUser(string token)
        {
            var list = new List<User>
            {
                new User{ id = 1, Name = "A", Token = "123"},
                new User{ id = 2, Name = "B", Token = "567"},
                new User{ id = 3, Name = "C", Token = "345"}
            };

            return list.Where(user => user.Token == token).FirstOrDefault() == null ?
                   new User { id = 5, Name = "E", Token = "999" } : list.Where(user => user.Token == token).FirstOrDefault();
        }
    }
}
