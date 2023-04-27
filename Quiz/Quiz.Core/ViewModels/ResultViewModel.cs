using Quiz.Core.Core;
using Quiz.Core.Services;

namespace Quiz.Core.ViewModels
{
    public class ResultViewModel : ViewModel
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

        public static string Result { get; set; }
        public static string Time { get; set; }
        //Commands
        public RelayCommand NavigateToMainCommand { get; set; }    
        public RelayCommand NavigateToSearchCommand { get; set; }   

        //Constructor
        public ResultViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToMainCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);
            NavigateToSearchCommand = new RelayCommand(o => { Navigation.NavigateTo<SearchViewModel>(); }, o => true);
        }

        //Methods
        public static void InicializeResult(int questionsCout, int userCorrectAnswers, string time)
        {
            Result = $"You have scored {userCorrectAnswers} points out of {questionsCout}!";
            Time = $"At time {time}";
        }
    }
}
