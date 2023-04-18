namespace FinalTask
{
    internal class ChooseOneQuestion : Question
    {

        public ChooseOneQuestion(string header, float marks,Answer QuestionAnswers, Answer ModelAnswer) : base(header, marks, QuestionAnswers, ModelAnswer, Type.ChooseOne)
        {
        }
    }
}
