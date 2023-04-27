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
        public RelayCommand GoBackCommand { get; set; }    

        //Constructor
        public ResultViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            GoBackCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);
        }

        //Methods
        public static void InicializeResult(int questionsCout, int userCorrectAnswers, string time)
        {
            Result = $"You have scored {userCorrectAnswers} points out of {questionsCout}!";
            Time = $"At time {time}";
        }
    }
}
