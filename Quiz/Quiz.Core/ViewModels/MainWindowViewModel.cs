using Quiz.Core.Core;
using Quiz.Core.Services;

namespace Quiz.Core.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
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

        public MainWindowViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            Navigation.NavigateTo<MainViewModel>();
        }
    }
}
