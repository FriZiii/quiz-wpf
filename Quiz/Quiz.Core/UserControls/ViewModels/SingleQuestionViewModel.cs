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

        public static Action<QuestionModel> ShowQuestionEvent;
        //Constructor
        public SingleQuestionViewModel(QuestionModel model)
        {
            QuestionModel = model;
            GetQuestionCommand = new RelayCommand(o => { ShowQuestionEvent?.Invoke(QuestionModel); }, o => true);
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
