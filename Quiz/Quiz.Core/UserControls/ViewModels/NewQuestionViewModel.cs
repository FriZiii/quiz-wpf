using Quiz.Core.Core;
using Quiz.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Core.UserControls.ViewModels
{
    public class NewQuestionViewModel : ViewModel
    {
        //Properties
        public ObservableCollection<AnswerModel> Answers { get; set; } = new ObservableCollection<AnswerModel>();
        public int QuestionNumber { get; set; }

        private string _question;
        [Required(ErrorMessage = "Must not be empty.")]
        [RegularExpression("^[^\\d\\s].*", ErrorMessage = "Name cannot start with a number")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be at least 3 characters")]
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


        //Constructor
        public NewQuestionViewModel()
        {
            for (int i = 0; i<4; i++)
            {
                Answers.Add(new AnswerModel());
            }
        }
    }
}
