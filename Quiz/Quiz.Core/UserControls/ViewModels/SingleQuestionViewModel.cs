using Quiz.Core.Core;
using Quiz.Core.Models;
using System;

namespace Quiz.Core.UserControls.ViewModels
{
    public class SingleQuestionViewModel : ViewModel
    {
        //Properties
        public RelayCommand GetQuestionCommand { get; set; }
        public QuestionModel QuestionModel { get; set; }
        public int QuestionId { get; set; }


        public static Action<QuestionModel, int> ShowQuestionEvent;
        //Constructor
        public SingleQuestionViewModel(QuestionModel model, int questionID)
        {
            QuestionId = questionID;
            QuestionModel = model;
            GetQuestionCommand = new RelayCommand(o => { ShowQuestionEvent?.Invoke(QuestionModel, QuestionId); }, o => true);
        }

        //Methods
        public void PrintQuestion()
        {
            Console.WriteLine(QuestionModel.Question);
            foreach(var answer in QuestionModel.Answers)
                Console.WriteLine(answer.Answer);
        }
    }
}
