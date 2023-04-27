using Quiz.Core.Core;
using Quiz.Core.Models;
using Quiz.Core.ViewModels;
using System;
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

        //Commands
        public RelayCommand RemoveQuestionCommand { get; set; }    

        //Events
        public static Action<object> RemoveQuestionEvent { get; set; }
        //Constructor
        public NewQuestionViewModel()
        {
            RemoveQuestionCommand = new RelayCommand(o => { RemoveQuestionEvent?.Invoke(this); }, o => true);
            for (int i = 0; i<4; i++)
            {
                Answers.Add(new AnswerModel());
            }
        }
    }
}
