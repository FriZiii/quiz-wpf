using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Quiz.Core.Core;
using Quiz.Core.Models;
using Quiz.Core.Repository;
using Quiz.Core.Services;
using Quiz.Core.UserControls.ViewModels;

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
        public static List<QuestionModel> QuestionsList { get; set; } = new List<QuestionModel>();
        public static ObservableCollection<SingleQuestionViewModel> SingleQuestions { get; set; } = new ObservableCollection<SingleQuestionViewModel>();
        public QuestionModel DisplayedQuestion { get; set; } = new QuestionModel();

        //Commands
        public RelayCommand NavigateToSearchViewCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }
        public RelayCommand DiscardChangesCommand { get; set; }

        //Constructor
        public EditViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToSearchViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SearchViewModel>(); }, o => true);
            SaveChangesCommand = new RelayCommand(o => { Console.WriteLine("SAVE"); }, o => true);
            DiscardChangesCommand = new RelayCommand(o => { Console.WriteLine("DISCARD"); }, o => true);
            SingleQuestionViewModel.ShowQuestionEvent += ShowQuestion;
        }

        private void ShowQuestion(QuestionModel question)
        {
            DisplayedQuestion = question;
            OnPropertyChanged(nameof(DisplayedQuestion));   
        }

        //Methods
        public static void InitializeEditMode(int quizID, string quizName)
        {
            QuestionsList.Clear();
            SQLiteDataAccess.GetQuestions(quizID).ForEach(x => QuestionsList.Add(x));
            QuestionsList.ForEach(x => SingleQuestions.Add(new SingleQuestionViewModel(x)));
            QuizName = quizName;
        }
    }
}
