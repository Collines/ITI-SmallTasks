namespace FinalTask
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, float marks, Answer ModelAnswer) : base(header, marks, new Answer(new string[] { "True", "False" }), ModelAnswer,Type.TrueFalse)
        {}
    }
}
