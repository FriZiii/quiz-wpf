using Quiz.Core.Core;

namespace Quiz.Core.UserControls.ViewModels
{
    public class NewQuestionViewModel : ViewModel
    {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }

        public string AnswearA { get; set; }
        public string AnswearB { get; set; }
        public string AnswearC { get; set; }
        public string AnswearD { get; set; }

        public bool AIsChecked { get; set; } = false;
        public bool BIsChecked { get; set; } = false;
        public bool CIsChecked { get; set; } = false;
        public bool DIsChecked { get; set; } = false;
    }
}
