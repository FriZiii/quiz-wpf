using Quiz.Core.Core;
using Quiz.Core.Models;
using System;
using System.Collections.ObjectModel;

namespace Quiz.Core.UserControls.ViewModels
{
    public class NewQuestionViewModel : ViewModel
    {
        //Properties
        public ObservableCollection<AnswerModel> Answers { get; set; } = new ObservableCollection<AnswerModel>();
        public int QuestionNumber { get; set; }
        public string Question { get; set; }

        //Constructor
        public NewQuestionViewModel()
        {
            for(int i = 0; i<4; i++)
            {
                Answers.Add(new AnswerModel());
            }
        }
    }
}
