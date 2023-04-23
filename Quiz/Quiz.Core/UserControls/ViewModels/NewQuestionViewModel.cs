using Quiz.Core.Core;
using Quiz.Core.Models;
using System;
using System.Collections.ObjectModel;

namespace Quiz.Core.UserControls.ViewModels
{
    public class NewQuestionViewModel : ViewModel
    {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }

        public ObservableCollection<AnswerModel> answers { get; set; } = new ObservableCollection<AnswerModel>();

        public NewQuestionViewModel()
        {
            for(int i = 0; i<4; i++)
            {
                answers.Add(new AnswerModel());
            }
        }
    }
}
