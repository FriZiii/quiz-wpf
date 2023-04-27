using Quiz.Core.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Core.Models
{
    public class QuestionModel : ObservableObject
    {
        //Properties
        public int ID { get; set; }
        private string _question;
        [Required(ErrorMessage = "Must not be empty.")]
        [RegularExpression("^[^\\d\\s].*", ErrorMessage = "Name cannot start with a number")]
        public string Question
        {
            get => _question;
            set
            {
                _question = value;
                OnPropertyChanged();
                CustomValidator.TryValidateProperty(value, nameof(Question), out var errorMessage, this);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new ValidationException(errorMessage);
                }
            }
        }

        private int questionNumber;
        public int QuestionNumber
        {
            get { return questionNumber; }
            set 
            { 
                questionNumber = value; 
                OnPropertyChanged(nameof(QuestionNumber));
            }
        }

        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();
    }
}
