using Quiz.Core.Core;
using Quiz.Core.Services;
using Quiz.Core.UserControls.ViewModels;
using System.Collections.ObjectModel;

namespace Quiz.Core.ViewModels
{
    public class CreateViewModel :ViewModel
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
        public RelayCommand NavigateToMainViewCommand { get; set; }
        public RelayCommand AddNewQuestionCommand { get; set; } 
        public ObservableCollection<NewQuestionViewModel> NewQuestionList { get; set; } = new ObservableCollection<NewQuestionViewModel>();

        //Constructor
        public CreateViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToMainViewCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>();  }, o => true);
            AddNewQuestionCommand = new RelayCommand(o => AddNewQuestion(), o => true);
            AddNewQuestion();
        }
        
        //Methods
        public void AddNewQuestion()
        {
            var newQuestion = new NewQuestionViewModel
            {
                QuestionNumber = NewQuestionList.Count + 1,
            };
            NewQuestionList.Add(newQuestion);
        }
    }
}
