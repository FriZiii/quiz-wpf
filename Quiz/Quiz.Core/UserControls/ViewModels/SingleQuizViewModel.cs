using Quiz.Core.Core;
using Quiz.Core.Models;
using Quiz.Core.Repository;
using Quiz.Core.ViewModels;
using System;

namespace Quiz.Core.UserControls.ViewModels
{
    public class SingleQuizViewModel: ViewModel
    {
        //Properties
        public SingleQuizModel FoundSingleQuizModel { get; set; }

        //Commands
        public RelayCommand PlayQuizzCommand { get; set; }
        public RelayCommand RemoveQuizzCommand { get; set; }
        public RelayCommand EditQuizzCommand { get; set; }

        public static event Action<int> StartQuizEvent;
        public static event Action<int, string> EditQuizEvent;
        //Constructor
        public SingleQuizViewModel()
        {
            PlayQuizzCommand = new RelayCommand(o =>
            {
                if (FoundSingleQuizModel != null)
                {
                    StartQuizEvent?.Invoke(FoundSingleQuizModel.ID);
                }
            },
            o => true
            );

            RemoveQuizzCommand = new RelayCommand(o =>
            {
                if (FoundSingleQuizModel != null)
                {
                    SQLiteDataAccess.RemoveQuiz(FoundSingleQuizModel.ID);
                    SearchViewModel.FoundedQuizzes.Remove(this);
                }
            },
            o => true
            );

            EditQuizzCommand = new RelayCommand(o =>
            {
                if (FoundSingleQuizModel != null)
                {
                    EditQuizEvent?.Invoke(FoundSingleQuizModel.ID, FoundSingleQuizModel.QuizName);
                }
            },
            o => true
            );
        }

        //Methods
        public void PlayQuiz()
        {
            Console.WriteLine($"{FoundSingleQuizModel.QuizName} started...");
        }
    }
}
