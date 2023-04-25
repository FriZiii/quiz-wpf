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
        public static int ID { get; set; }
        public static string QuizName { get; set; }
        public ObservableCollection<QuestionModel> QuestionsList { get; set; } = new ObservableCollection<QuestionModel>();

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
            ReadQuestions();
        }

        public void ReadQuestions()
        {
            SQLiteDataAccess.GetQuestions(ID).ForEach(x => QuestionsList.Add(x));
        }
    }
}
