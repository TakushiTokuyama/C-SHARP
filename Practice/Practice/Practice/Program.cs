using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Practice
{
    public class Program : IValidatableObject
    {
        static void Main(string[] args)
        {
            List<string> nameList = new List<string> { "A", "B", "C" };

            Validate(nameList);

        }

        private const int _classicYear = 1960;

        public int Id { get; set; }

        public string Name { get; set; }

        public static IEnumerable<ValidationResult> Validate(ValidationContext validationContext, List<String> list)
        {
            if (list.Contains("A")) {
                yield return default;
            }
        }
    }
}
