using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.Core
{
    public static class CustomValidator
    {
        public static bool TryValidateObject<T>(T obj, out string errorMessage)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            if (!isValid)
            {
                var errorMessages = new System.Collections.Generic.List<string>();
                foreach (var validationResult in validationResults)
                {
                    errorMessages.Add(validationResult.ErrorMessage);
                }
                errorMessage = string.Join(" ", errorMessages);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool TryValidateProperty<T>(T value, string propertyName, out string errorMessage, object instance = null)
        {
            var validationContext = new ValidationContext(instance);
            validationContext.MemberName = propertyName;
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(value, validationContext, validationResults);

            if (!isValid)
            {
                var errorMessages = new System.Collections.Generic.List<string>();
                foreach (var validationResult in validationResults)
                {
                    errorMessages.Add(validationResult.ErrorMessage);
                }
                errorMessage = string.Join(" ", errorMessages);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
