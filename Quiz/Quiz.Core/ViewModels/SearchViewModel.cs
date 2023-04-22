using Quiz.Core.Core;
using Quiz.Core.Services;

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
        public RelayCommand NavigateToCreateViewCommand { get; set; }
        public SearchViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToCreateViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateViewModel>(); }, o => true);
        }
    }
}
