namespace FinalTask
{
    internal class Answer
    {
        string[] Answers;
        public Answer(string[] answers)
        {
            Answers = answers;
        }
       
        public static implicit operator bool(Answer a)
        {
            if (a.Answers.Length > 0)
                return true;
            return false;
        }
        public string[] Get()
        {
            return Answers;
        }

        public string GetAnswersString()
        {
            string ans = "";
            foreach (string answer in Answers)
                ans = ans + (ans.Length > 0 ? "-" : "") + answer;
            return ans;
        }
        public void ShowAnswers()
        {
            int i = 1;
            foreach(var answer in Answers)
            {
                Console.WriteLine($"({i}) {answer}");
                i++;
            }
            Console.Write("\n");
        }


        ///<summary>
        ///  user enter values like this 1,2,3 we don't know what 1,2 and 3 stands for
        ///  so we split them and get their values from QuestionAnswers array
        ///  and return the answers array to a new Answer so we can use it in Correct function 
        ///  by comparing entered answers with model answers
        ///</summary>
        ///<param name="str">str is the user entered answers indexes array</param>
        ///
        public Answer Grab(string[] str) // obj.grab()
        {
            if(str.Length > 0)
            {
                string[] grabbedAnswers = new string[str.Length];
                for (int i=0;i<str.Length;i++)
                {
                    int x = int.Parse(str[i]);
                    grabbedAnswers[i] = Answers[x - 1];
                }
                return new Answer(grabbedAnswers);
            }
            return null;
        }
    }
}
