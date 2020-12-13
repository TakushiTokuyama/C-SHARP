using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    // DefaultIfEmpty
    public static class Sample2
    {
        private class Parameter
        {
            public int ID { get; set; }
            public int Age { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return string.Format("ID:{0}, Age{1}, Name:{2}", ID, Age, Name);
            }
        }

        public static void Logic()
        {
            Parameter[] parametersA = new Parameter[]
        {
            new Parameter { ID = 0, Age = 52, Name = "正一郎" },
            new Parameter { ID = 8, Age = 28, Name = "清次郎" },
            new Parameter { ID = 3, Age = 20, Name = "誠三郎" },
            new Parameter { ID = 4, Age = 18, Name = "征史郎" },
        };

            Parameter[] parametersB = new Parameter[] { };
            Parameter defaultparameter = new Parameter() { ID = -1, Age = 0, Name = "名無し" };

            IEnumerable<Parameter> parametersAPlus = parametersA.DefaultIfEmpty(defaultparameter);
            IEnumerable<Parameter> parametersBPlus = parametersB.DefaultIfEmpty(defaultparameter);

            Console.WriteLine("numberA :{0}", parametersA.Text());
            Console.WriteLine("numberAPlus :{0}", parametersAPlus.Text());
            Console.WriteLine("numberB :{0}", parametersB.Text());
            Console.WriteLine("numberBPlus :{0}", parametersBPlus.Text());
        }

        public static string Text(this IEnumerable i_source)
        {
            string text = string.Empty;

            foreach (var value in i_source)
            {
                text += string.Format("[{0}], ", value);
            }

            return text;
        }
    }
}
