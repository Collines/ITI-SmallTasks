namespace FinalTask
{
    internal class ChooseMultiple : Question
    {
        public ChooseMultiple(string header,float marks, Answer questionAnswers,Answer modelAnswers):base(header,marks,questionAnswers,modelAnswers, Type.Multiple)
        {}
        public override bool Correct(Answer EnteredAnswers)
        {
            if(EnteredAnswers)
            {
                string[] ma = ModelAnswers.Get(); 
                string[] ea = EnteredAnswers.Get(); 
                Array.Sort(ma); // for
                Array.Sort(ea); // for
                if (ma.Length == ea.Length)
                {
                    for (int i = 0; i < ma.Length; i++)
                    {
                        if (ma[i] != ea[i])
                            return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
