namespace FinalTask
{
    class Practical : Exam
    {
        public Practical(Subject subject):base(subject) 
        {
            Type = ExamType.Practical;
        }

        public static implicit operator bool(Practical x)
        {
            if (x.Subj)
                return true;
            return false;
        }
        public override void StartExam()
        {
            base.StartExam();
            Console.WriteLine("\nCorrect Ansers:");
            string qnum;
            for (int i = 0; i < Subj.Questions.Count; i++)
            {
                qnum = $"{i + 1}";
                Subj.Questions[i].ShowCorrectAnswers(qnum);
            }

        }

    }
}
