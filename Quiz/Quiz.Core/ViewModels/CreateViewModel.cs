using Quiz.Core.Core;
using Quiz.Core.Repository;
using Quiz.Core.Services;
using Quiz.Core.UserControls.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Quiz.Core.ViewModels
{
    public class CreateViewModel : ViewModel
    {
        //Properties
        public ObservableCollection<NewQuestionViewModel> NewQuestionList { get; set; } = new ObservableCollection<NewQuestionViewModel>();

        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation; 
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        private string? _name;
        [Required(ErrorMessage = "Must not be empty.")]
        [RegularExpression("^[^\\d\\s].*", ErrorMessage = "Name cannot start with a number")]
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                if (value == null) return;
                CustomValidator.TryValidateProperty(value, nameof(Name), out var errorMessage, this);
                //if (!string.IsNullOrEmpty(errorMessage))
                //{
                //    throw new ValidationException(errorMessage);
                //}
            }
        }


        //Commands
        public RelayCommand NavigateToMainViewCommand { get; set; }
        public RelayCommand AddNewQuestionCommand { get; set; }
        public RelayCommand CreateQuizzCommand { get; set; }


        //Constructor
        public CreateViewModel(INavigationService navigation)
        {
            Navigation = navigation;

            AddNewQuestion();

            NavigateToMainViewCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>();  }, o => true);
            AddNewQuestionCommand = new RelayCommand(o => AddNewQuestion(), o => true);
            CreateQuizzCommand = new RelayCommand(o => CreateQuizz(), o => IsValid());

            NewQuestionViewModel.RemoveQuestionEvent += RemoveQuestion;

        }

        private void RemoveQuestion(object question)
        {
            NewQuestionList.Remove((NewQuestionViewModel)question);
        }

        //Methods
        public void AddNewQuestion()
        {
            var newQuestion = new NewQuestionViewModel
            {
                QuestionNumber = NewQuestionList.Count + 1,
            };
            NewQuestionList.Add(newQuestion);
        }

        public void CreateQuizz()
        {
            SQLiteDataAccess.CreateQuizz(this);
            ClearCreator();
        }

        public void ClearCreator()
        {
            Name = null;
            NewQuestionList.Clear();
            AddNewQuestion();
        }

        public bool IsValid()
        {
            CustomValidator.TryValidateObject(this, out var errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return false;
            }

            foreach (var question in NewQuestionList)
            {
                CustomValidator.TryValidateObject(question, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return false;
                }

                if (!question.Answers.Any(a => a.IsCorrect))
                {
                    return false;
                }

                foreach (var answer in question.Answers)
                {
                    CustomValidator.TryValidateObject(answer, out errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
