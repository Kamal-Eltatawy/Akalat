using Aklat.Models.Context;
using System.ComponentModel.DataAnnotations;

namespace Akalat.Models.CustomVaildation
{
    public class UniqueCategoryName: ValidationAttribute
    {
        private readonly CategoryReposatory context;

        public UniqueCategoryName(CategoryReposatory context)
        {
            this.context = context;
        }







        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {


            string uniqueName = (string)value;


            Category? categoryName = context.GetAll().FirstOrDefault(e => (e.Name == uniqueName));



            if (categoryName == null)
            {
                return ValidationResult.Success;
            }


            return new ValidationResult("Name is Already Taken");
        }
    }
}
