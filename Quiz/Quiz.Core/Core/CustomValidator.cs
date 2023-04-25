using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Core.Core
{
    public static class CustomValidator
    {
        public static bool TryValidateObject<T>(T obj, out string errorMessage)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            if (!isValid)
            {
                var errorMessages = validationResults.Select(x => x.ErrorMessage);

                errorMessage = string.Join(" ", errorMessages);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool TryValidateProperty<T>(T value, string propertyName, out string errorMessage, object instance = null)
        {
            var validationContext = new ValidationContext(instance)
            {
                MemberName = propertyName
            };
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(value, validationContext, validationResults);

            if (!isValid)
            {
                var errorMessages = validationResults.Select(x => x.ErrorMessage).ToList();

                errorMessage = string.Join(", ", errorMessages);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
