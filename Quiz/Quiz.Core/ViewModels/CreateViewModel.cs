using Quiz.Core.Core;
using Quiz.Core.Repository;
using Quiz.Core.Services;
using Quiz.Core.UserControls.ViewModels;
using System;
using System.Collections.ObjectModel;

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

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
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
            CreateQuizzCommand = new RelayCommand(o => CreateQuizz(), o => true);
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
            Console.WriteLine("Saved");
            SQLiteDataAccess.CreateQuizz(this);
            ClearCreator();
        }

        public void ClearCreator()
        {
            Name = string.Empty;
            NewQuestionList.Clear();
            AddNewQuestion();
        }
    }
}
