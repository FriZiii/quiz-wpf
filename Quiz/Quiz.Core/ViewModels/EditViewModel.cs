using Quiz.Core.Core;
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
        public RelayCommand NavigateToSearchViewCommand { get; set; }
        public static int ID { get; set; }

        //Constructor
        public EditViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToSearchViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SearchViewModel>(); }, o => true);
        }
    }
}
