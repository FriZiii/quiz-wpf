using System.Collections.Generic;

namespace Quiz.Core.Models
{
    public class QuestionModel
    {
        //Properties
        public int ID { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
