using Quiz.Core.Core;
using Quiz.Core.Repository;
using Quiz.Core.Services;
using Quiz.Core.UserControls.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Quiz.Core.ViewModels
{
    public class SearchViewModel : ViewModel
    {
        //Properties
        public static ObservableCollection<FoundSingleQuizViewModel> FoundedQuizzes { get; set; } = new ObservableCollection<FoundSingleQuizViewModel>();
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

        public static string? Title { get; set; } 

        //Commands
        public RelayCommand NavigateToMainViewCommand { get; set; }

        //Constructor
        public SearchViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToMainViewCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);

            FoundSingleQuizViewModel.StartQuizEvent += PlayQuiz;
            FoundSingleQuizViewModel.EditQuizEvent += EditQuiz;
        }

        //Methods
        public static void SearchQuizzes()
        {
            FoundedQuizzes.Clear();
            SQLiteDataAccess.GetQuizzes().ForEach(x => FoundedQuizzes.Add(new FoundSingleQuizViewModel
            {
                FoundSingleQuizModel = x,
            }));

            if (FoundedQuizzes.Count == 0)
                Title = "There are no quizzes in the database!";
            else
                Title = "Quizzes found in the database";
        }

        private void EditQuiz(int quizID, string quizName)
        {
            EditViewModel.InitializeEditMode(quizID, quizName);
            Navigation.NavigateTo<EditViewModel>();
        }

        private void PlayQuiz(int quizID)
        {
            AnswerViewModel.InitializeQuiz(quizID);
            Navigation.NavigateTo<AnswerViewModel>();
        }
    }
}
