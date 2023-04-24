using System;
using Quiz.Core.Core;

namespace Quiz.Core.UserControls.ViewModels
{
    public class FoundSingleQuizViewModel: ViewModel
    {
        //Properties
        public int ID { get; set; }
        public string QuizName { get; set; }

        //Commands
        public RelayCommand PlayQuizzCommand { get; set; }

        //Constructor
        public FoundSingleQuizViewModel()
        {
            PlayQuizzCommand = new RelayCommand(o => PlayQuiz(), o => true);
        }

        //Methods
        public void PlayQuiz()
        {
            Console.WriteLine($"{QuizName} started...");
        }
    }
}
