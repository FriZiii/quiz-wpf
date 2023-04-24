using System;
using Quiz.Core.Core;

namespace Quiz.Core.UserControls.ViewModels
{
    public class FoundSingleQuizViewModel: ViewModel
    {
        public int ID { get; set; }
        public string QuizName { get; set; }
        public RelayCommand PlayQuizzCommand { get; set; }

        public FoundSingleQuizViewModel()
        {
            PlayQuizzCommand = new RelayCommand(o => PlayQuiz(), o => true);
        }

        public void PlayQuiz()
        {
            Console.WriteLine($"{QuizName} started...");
        }
    }
}
