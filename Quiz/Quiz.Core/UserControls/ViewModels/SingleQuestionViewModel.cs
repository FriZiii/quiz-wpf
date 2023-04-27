using Quiz.Core.Core;
using Quiz.Core.Models;
using Quiz.Core.ViewModels;
using System;

namespace Quiz.Core.UserControls.ViewModels
{
    public class SingleQuestionViewModel : ViewModel
    {
        //Properties
        public RelayCommand GetQuestionCommand { get; set; }
        public QuestionModel QuestionModel { get; set; }

        public int QuestionId { get; set; }

        public RelayCommand RemoveQuestionCommand { get; set; }
        public static Action<QuestionModel, int> ShowQuestionEvent;
        //Constructor
        public SingleQuestionViewModel(QuestionModel model, int questionID)
        {
            QuestionId = questionID;
            QuestionModel = model;
            GetQuestionCommand = new RelayCommand(o => { ShowQuestionEvent?.Invoke(QuestionModel, QuestionId); }, o => true);
            RemoveQuestionCommand = new RelayCommand(o => RemoveQuestion(), o => true);
        }
        public SingleQuestionViewModel(QuestionModel model)
        {
            QuestionModel = model;
            GetQuestionCommand = new RelayCommand(o => { ShowQuestionEvent?.Invoke(QuestionModel, QuestionId); }, o => true);
            RemoveQuestionCommand = new RelayCommand(o => EditViewModel.SingleQuestions.Remove(this), o => true);
        }

        //Methods
        private void RemoveQuestion()
        {
            EditViewModel.SingleQuestions.Remove(this);
        }
    }
}
