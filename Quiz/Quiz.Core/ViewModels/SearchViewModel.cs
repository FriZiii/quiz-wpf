using Quiz.Core.Core;
using Quiz.Core.Repository;
using Quiz.Core.Services;
using Quiz.Core.UserControls.ViewModels;
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

        //Commands
        public RelayCommand NavigateToMainViewCommand { get; set; }

        //Constructor
        public SearchViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToMainViewCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);
        }

        //Methods
        public static void SearchQuizzes()
        {
            FoundedQuizzes.Clear();
            SQLiteDataAccess.GetQuizz().ForEach(x => FoundedQuizzes.Add(x));
        }
    }
}
