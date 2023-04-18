namespace FinalTask
{
    enum Type:byte
    {
        TrueFalse,
        ChooseOne,
        Multiple
    }
    internal abstract class Question
    {
        protected string Header;
        protected float Marks;
        protected Answer QuestionAnswers;
        protected Answer ModelAnswers;
        protected Type QType;

        public Question(string header, float marks, Answer questionAnswers, Answer modelAnswers, Type type)
        {
            Header = header;
            Marks = marks;
            QuestionAnswers = questionAnswers;
            ModelAnswers = modelAnswers;
            QType = type;
        }

        public Answer GetQuestionAnswers()
        {
            return QuestionAnswers;
        }

        public Answer GetModelAnswers()
        {
            return ModelAnswers;
        }

        public float GetMarks()
        {
            return Marks;
        }

        public Type GetType()
        {
            return QType;
        }

        public string getHeader()
        {
            return Header;
        }


        public void ShowQuestion(string num = "")
        {
            num = num.Length >= 1 ? num + ") " : num;
            if(QType == Type.Multiple)
                Console.Write($"{num}Choose all correct answers: {Header}       ({Marks} Marks)\n");
            else
                Console.Write($"{num}{Header}       ({Marks} Marks)\n");
            QuestionAnswers.ShowAnswers();
        }


        /// <summary>
        /// Print Correct Answers to a specific question number taking in consideration if the question has multiple correct answers
        /// </summary>
        /// <param name="QNum">Question Number</param>
        public void ShowCorrectAnswers(string QNum)
        {
            bool first = true;
            foreach (var answer in ModelAnswers.Get())
            {
                if (QType==Type.Multiple && first)
                {
                    Console.Write($"\n{QNum}) {answer}");
                    first = false;
                }
                else if (QType == Type.Multiple)
                    Console.Write($", {answer}");

                else
                    Console.Write($"\n{QNum}) {answer}");
            }
        }
        public virtual bool Correct(Answer EnteredAnswer)
        {
            if (EnteredAnswer.Get().Length == 1)
            {
                if (EnteredAnswer.Get()[0] == ModelAnswers.Get()[0])
                    return true;
            }
            return false;
        }
    }
}