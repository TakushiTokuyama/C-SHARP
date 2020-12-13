using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Sample01
{
    public class Sample01ViewModel : IValidatableObject
    {
        public string num { get; set; }

        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }


        /// <summary>
        /// 条件付きのValidation
        /// </summary>
        /// <param name="validationContext">validationContext</param>
        /// <returns>message</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (num == "1")
            {
                yield return new ValidationResult("必須項目", new[] { nameof(num) });
            }
        }
    }
}
