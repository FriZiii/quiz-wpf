using Quiz.Core.Core;
using Quiz.Core.Repository;
using Quiz.Core.Services;
using Quiz.Core.UserControls.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Quiz.Core.ViewModels
{
    public class SearchViewModel :ViewModel
    {
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

        public ObservableCollection<FoundSingleQuizViewModel> FoundedQuizzes { get; set; } = new ObservableCollection<FoundSingleQuizViewModel>();
        public RelayCommand NavigateToMainViewCommand { get; set; }
        public SearchViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            SearchQuizzes();
            NavigateToMainViewCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);
        }

        public void SearchQuizzes()
        {
            foreach (var quiz in SQLiteDataAccess.GetQuizz())
            {
                FoundedQuizzes.Add(quiz);
            }
        }
    }
}
