using Quiz.Core.Core;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Core.Models
{
    public class AnswerModel : ViewModel
    {
        //Properties
        private string _answer;
        [Required(ErrorMessage = "Must not be empty.")]
        [RegularExpression("^[^\\d\\s].*", ErrorMessage = "Name cannot start with a number")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be at least 3 characters")]
        public string Answer
        {
            get => _answer;
            set
            { 
                _answer = value;
                OnPropertyChanged();
                CustomValidator.TryValidateProperty(value, nameof(Answer), out var errorMessage, this);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new ValidationException(errorMessage);
                }
            }
        }

        public bool IsCorrect { get; set; } = false;
    }
}
