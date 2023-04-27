using Quiz.Core.Core;
using Quiz.Core.Models;
using Quiz.Core.Repository;
using Quiz.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Quiz.Core.ViewModels
{
    public class AnswerViewModel : ViewModel
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

        public static ObservableCollection<QuestionModel> Questions { get; set; } = new ObservableCollection<QuestionModel>();
        private static List<bool> UserAnswers { get; set; } = new List<bool>();
        public AnswerModel AnswerA { get; set; } = new AnswerModel();
        public AnswerModel AnswerB { get; set; } = new AnswerModel();
        public AnswerModel AnswerC { get; set; } = new AnswerModel();
        public AnswerModel AnswerD { get; set; } = new AnswerModel();
        public static int TotalQuestionsCout { get; set; } 

        //Commands
        public RelayCommand NextQuestionCommand { get; set; }
        public RelayCommand FinishQuizzCommand { get; set; }

        //Constructor
        public AnswerViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NextQuestionCommand = new RelayCommand(MoveToNextQuestion, o => true);
            FinishQuizzCommand = new RelayCommand(o => EndQuiz(), o => true);
            InitializeQuestion();
        }

        //Methods
        public static void InitializeQuiz(int quizID)
        {
            Questions.Clear();
            SQLiteDataAccess.GetQuestions(quizID).ForEach(x => Questions.Add(x));
            UserAnswers.Clear();
            TotalQuestionsCout = Questions.Count;
        }

        private void MoveToNextQuestion(object parameter)
        {
            if (Questions.Count >= 0)
            {
                UserAnswers.Add(Questions[0].Answers[int.Parse(parameter.ToString())].IsCorrect);
            }

            if(Questions.Count > 0)
                Questions.RemoveAt(0);

            if (Questions.Count > 0)
            {
                InitializeQuestion();
            }

            if(Questions.Count == 0)
            {
                EndQuiz();
            }
        }

        private void EndQuiz()
        {
            ResultViewModel.InicializeResult(TotalQuestionsCout, UserAnswers.Count(x => x == true));
            Navigation.NavigateTo<ResultViewModel>();
        }

        private void InitializeQuestion()
        {
            AnswerA = Questions[0].Answers[0];
            AnswerB = Questions[0].Answers[1];
            AnswerC = Questions[0].Answers[2];
            AnswerD = Questions[0].Answers[3];
            OnPropertyChanged(nameof(AnswerA));
            OnPropertyChanged(nameof(AnswerB));
            OnPropertyChanged(nameof(AnswerC));
            OnPropertyChanged(nameof(AnswerD));
        }
    }
}
