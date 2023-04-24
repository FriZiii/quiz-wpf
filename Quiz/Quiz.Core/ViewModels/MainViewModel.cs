using Quiz.Core.Core;
using Quiz.Core.Services;

namespace Quiz.Core.ViewModels
{
    public class MainViewModel :ViewModel
    {
        //Properties
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get { return _navigation; }
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public RelayCommand NavigateToCreateCommand { get; set; }
        public RelayCommand NavigateToSearchCommand { get; set; }

        //Constructor
        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToCreateCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateViewModel>(); }, o => true);
            NavigateToSearchCommand = new RelayCommand(o => { Navigation.NavigateTo<SearchViewModel>(); SearchViewModel.SearchQuizzes(); }, o => true);
        }
    }
}
