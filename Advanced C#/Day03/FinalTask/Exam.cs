namespace FinalTask
{
    enum ExamType:byte
    {
        Final,
        Practical
    }
    class Exam : IExam
    {
        protected Subject Subj;
        protected ExamType Type;

        public Exam(Subject subject)
        {
            Subj = subject;
            Type = ExamType.Final;
        }

        public static implicit operator bool(Exam x)
        {
            if (x.Subj)
                return true;
            return false;
        }
        public float GetFullMarks()
        {
            float marks = 0;
            if(Subj.Questions.Count > 0)
            {
                for (int i = 0; i < Subj.Questions.Count; i++)
                {
                    marks += Subj.Questions[i].GetMarks();
                }
            }
            return marks;
        }
        public virtual void StartExam()
        {
            float totalMarks = GetFullMarks();
            Console.WriteLine($"\t\t\t\t{Subj.Name} {Type.ToString()} Exam - {Subj.Questions.Count} Questions - ({totalMarks} Marks)");
            Console.WriteLine("\t\t\tEnter question answers for multiple answers as following: 1,2,3 ..etc");
            string qnum;
            float marks = 0;
            for (int i = 0; i < Subj.Questions.Count; i++)
            {
                qnum = $"{i + 1}";
                Subj.Questions[i].ShowQuestion(qnum);
                string[] enteredIndexes;
                bool exit = true;
                do
                {
                    enteredIndexes = Console.ReadLine().Split(',');
                    if(enteredIndexes.Length > Subj.Questions[i].GetQuestionAnswers().Get().Length)
                    {
                        Console.WriteLine("Enter a valid input");
                        exit = false;
                    } 
                    else
                        for (int j = 0; j < enteredIndexes.Length; j++)
                        {
                            if (!int.TryParse(enteredIndexes[j], out int x) || int.Parse(enteredIndexes[j]) > Subj.Questions[i].GetQuestionAnswers().Get().Length)
                            {
                                Console.WriteLine("Enter a valid input");
                                exit = false;
                            }
                            else exit = true;
                        }
                } while (enteredIndexes.Length <= 0 ||
                    enteredIndexes.Length > Subj.Questions[i].GetQuestionAnswers().Get().Length || !exit);

                Answer EnteredAns = Subj.Questions[i].GetQuestionAnswers().Grab(enteredIndexes);
                if (EnteredAns) {
                    if (Subj.Questions[i].Correct(EnteredAns))
                    {
                        marks += Subj.Questions[i].GetMarks();
                    }
                }
            }
            if ((marks / totalMarks) >= 0.7f)
                Console.WriteLine($"\n\t\tCongratulations! You've finished the exam and you got {marks}/{totalMarks} Marks");
            else
                Console.WriteLine($"\n\t\tSorry! You Unfortunately failed the exam and you got {marks}/{totalMarks} Marks");

        }

    }
}
