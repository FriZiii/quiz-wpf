using System;
using Quiz.Core.Core;
using Quiz.Core.Repository;
using Quiz.Core.ViewModels;

namespace Quiz.Core.UserControls.ViewModels
{
    public class FoundSingleQuizViewModel: ViewModel
    {
        //Properties
        public int ID { get; set; }
        public string QuizName { get; set; }

        //Commands
        public RelayCommand PlayQuizzCommand { get; set; }
        public RelayCommand RemoveQuizzCommand { get; set; }
        public RelayCommand EditQuizzCommand { get; set; }

        //Constructor
        public FoundSingleQuizViewModel()
        {
            PlayQuizzCommand = new RelayCommand(o => PlayQuiz(), o => true);
            RemoveQuizzCommand = new RelayCommand(o => { SQLiteDataAccess.RemoveQuiz(ID); SearchViewModel.FoundedQuizzes.Remove(this); }, o => true) ;
            EditQuizzCommand = new RelayCommand(o => Console.Write("Edit..."), o => true);
        }

        //Methods
        public void PlayQuiz()
        {
            Console.WriteLine($"{QuizName} started...");
        }
    }
}
