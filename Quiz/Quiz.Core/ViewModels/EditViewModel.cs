using System;
using System.Collections.ObjectModel;
using Quiz.Core.Core;
using Quiz.Core.Models;
using Quiz.Core.Repository;
using Quiz.Core.Services;

namespace Quiz.Core.ViewModels
{
    public class EditViewModel : ViewModel
    {
        //Properties
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
        public static string QuizName { get; set; }
        public static ObservableCollection<QuestionModel> QuestionsList { get; set; } = new ObservableCollection<QuestionModel>();

        //Commands
        public RelayCommand NavigateToSearchViewCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }
        public RelayCommand DiscardChangesCommand { get; set; }
        public RelayCommand GetQuestionCommand { get; set; }

        //Constructor
        public EditViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToSearchViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SearchViewModel>(); }, o => true);
            SaveChangesCommand = new RelayCommand(o => { Console.WriteLine("SAVE"); }, o => true);
            DiscardChangesCommand = new RelayCommand(o => { Console.WriteLine("DISCARD"); }, o => true);
            GetQuestionCommand = new RelayCommand(o => PrintQuestion(), o => true);
        }

        //Methods
        public void PrintQuestion()
        {
            Console.WriteLine("XD");
        }

        public static void InitializeEditMode(int quizID, string quizName)
        {
            QuestionsList.Clear();
            SQLiteDataAccess.GetQuestions(quizID).ForEach(x => QuestionsList.Add(x));
            foreach (var x in QuestionsList)
            {
                Console.WriteLine(x.QuestionNumber);
            }
            QuizName = quizName;
        }
    }
}
