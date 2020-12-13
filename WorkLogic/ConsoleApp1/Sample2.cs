using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{

    public class Sample2
    {
        List<Employee> employees = new List<Employee>()
           {
                new Employee {Group = 1, Name = "A" },
                new Employee {Group = 2, Name = "B" },
                new Employee {Group = 1, Name = "C" },
                new Employee {Group = 3, Name = "D" },
           };

        public void Logic()
        {
            var q = employees.GroupBy(c => c.Group)
                          .Select(g => new
                          {
                              Group = 1,
                              i1 = g.Where(c => c.Group == 1).Count(),
                              i2 = g.Where(c => c.Group == 2).Count(),
                              i3 = g.Where(c => c.Group == 3).Count()
                          }).GroupBy(t => t.Group)
                            .Select(s => new
                            {
                                m1 = s.Max(t => t.i1),
                                m2 = s.Max(t => t.i2),
                                m3 = s.Max(t => t.i3)
                            });

            foreach (var item in q)
            {
                Console.WriteLine("Group:{0}", item);
            }
        }
        public class Employee
        {
            public int Group { get; set; }
            public string Name { get; set; }
        }
    }
}