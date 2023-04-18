using System.Collections;
using System.IO;
namespace FinalTask
{
    internal class QuestionsListHandler:List<Question>
    {
        string listName;
        //private static Dictionary<string, List<Question>> Questions = new Dictionary<string, List<Question>> {
        //    {"General Information", new List<Question>
        //       {
        //            new TrueFalseQuestion("Sea otters have a favorite rock they use to break open food",2.5f,new Answer(new string[]{"True"})),
        //            new TrueFalseQuestion("The blue whale is the biggest animal to have ever lived",2.5f,new Answer(new string[]{"True"})),
        //            new TrueFalseQuestion("Pigs roll in the mud because they don’t like being clean",2.5f,new Answer(new string[]{"False"})),
        //            new TrueFalseQuestion("Bats are blind",2.5f,new Answer(new string[]{"False"})),
        //            new ChooseOneQuestion("Identify the capital city of Ecuador",2.5f,new Answer(new string[] { "Bogotá", "Tegucigalpa", "Quito", "Asunción" }),new Answer(new string[] { "Quito" })),
        //            new ChooseOneQuestion("Identify the capital city of Portugal",2.5f,new Answer(new string[] { "Rome", "Lisbon", "Paris", "Madrid" }),new Answer(new string[] { "Lisbon" })),
        //            new ChooseOneQuestion("Identify the capital city of Vietnam",2.5f,new Answer(new string[] { "Vientián", "Phnom Penh", "Bangkok", "Hanói" }),new Answer(new string[] { "Hanói" })),
        //            new ChooseOneQuestion("Identify the capital city of Egypt",2.5f,new Answer(new string[] { "Beni-suef", "Alexandria", "Cairo", "Aswan" }),new Answer(new string[] { "Cairo" })),
        //            new ChooseOneQuestion("What is name of the young rabbit?",2.5f,new Answer(new string[] { "Buck", "Doe", "Bunny", "Cottontail" }),new Answer(new string[] { "Bunny" })),
        //            new ChooseMultiple("I _____ alcohol, but today I _____ my birthday.",5f,new Answer(new string[] { "'m not often drinking", "'m celebrating", "celebrate", "don't often drink" }),new Answer(new string[] {  "don't often drink","'m celebrating" })),
        //            new ChooseMultiple("I don't really like _____ milk. I only like _____ milk that you buy.",5f,new Answer(new string[] { "the", "the", "–" }),new Answer(new string[] { "the", "–" })),
        //       }
        //    },
        //    {"Maths", new List<Question>
        //       {
        //            new ChooseOneQuestion("12 * 9 / 4 = ?",2.5f,new Answer(new string[] { "25", "26", "27", "28" }),new Answer(new string[] { "27" })),
        //            new ChooseOneQuestion("What number should come next: 14, 28, 20, 40, 32, 64,... ",2.5f,new Answer(new string[] { "52", "56", "96", "128" }),new Answer(new string[] { "56" })),
        //            new TrueFalseQuestion("55 * 3 < 820 / 4 ?",2.5f,new Answer(new string[]{"True"})),
        //            new ChooseOneQuestion("3 + 27 * 2 = ?",2.5f,new Answer(new string[] { "33", "54", "57", "60" }),new Answer(new string[] { "57" })),
        //            new ChooseOneQuestion("What number should come next: 7, 10, 8, 11, 9, 12,... ",2.5f,new Answer(new string[] { "7", "10", "12", "13" }),new Answer(new string[] { "10" })),
        //            new ChooseMultiple("8 * 2 * 15 / 4 = ?",5f,new Answer(new string[] { "60", "240 / 6", "480 / 8", "15 * 3" }),new Answer(new string[] {  "60","480 / 8" })),
        //            new TrueFalseQuestion("4232 > 8520 / 2 ?",2.5f,new Answer(new string[]{"False"})),
        //            new ChooseOneQuestion("What number should come next: 31, 29, 24, 22, 17,... ",2.5f,new Answer(new string[] { "15", "14", "13", "12" }),new Answer(new string[] { "15" })),
        //            new ChooseOneQuestion("1080 / ? = 9 * 8",2.5f,new Answer(new string[] { "13", "15", "17", "19" }),new Answer(new string[] { "15" })),
        //            new ChooseMultiple("Which is the factorial of 4 ?",5f,new Answer(new string[] { "22", "24", "8 * 3", "12 * 2" }),new Answer(new string[] { "24", "8 * 3", "12 * 2" })),
        //       }
        //    },
        //    {"English", new List<Question>
        //       {
        //            new ChooseMultiple("______ there anybody in the room?. Nowadays everyone ______ internet.", 5f, new Answer(new string[] { "Are", "is", "had used", "uses" }), new Answer(new string[] { "is", "uses" })),
        //            new ChooseOneQuestion("I spoke to", 2.5f, new Answer(new string[] { "she", "her", "he" }), new Answer(new string[] { "her" })),
        //            new ChooseOneQuestion("I am seeing her ____ three o'clock.", 2.5f, new Answer(new string[] { "in", "at", "on" }), new Answer(new string[] { "at" })),
        //            new ChooseOneQuestion("___ girlfriend left him.", 2.5f, new Answer(new string[] { "He", "His", "Him" }), new Answer(new string[] { "His" })),
        //            new ChooseOneQuestion("I came _____ America.", 2.5f, new Answer(new string[] { "from", "at", "in" , "on" }), new Answer(new string[] { "from" })),
        //            new TrueFalseQuestion("A RIVER is bigger than a STREAM.", 2.5f, new Answer(new string[] { "True" })),
        //            new TrueFalseQuestion("There are one thousand years in a CENTURY", 2.5f, new Answer(new string[] { "False" })),
        //            new TrueFalseQuestion("EQUIVALENT TO is (more or less) the same as EQUAL TO", 2.5f, new Answer(new string[] { "True" })),
        //            new TrueFalseQuestion("USED TO DOING and USED TO DO mean the same thing.", 2.5f, new Answer(new string[] { "False" })),
        //            new ChooseMultiple("She is____ home. And She eats___ apple..", 5f, new Answer(new string[] { "in", "at", "a", "an" }), new Answer(new string[] { "at", "an" })),
        //       }
        //    },

        //};
        public QuestionsListHandler(string name)
        {
            listName = name;
        }

        /// <summary>
        /// Get the Keys that stand for each subject name
        /// </summary>
        /// <returns>Array of the keys</returns>
        //public static string[] GetKeys()
        //{
        //    return Questions.Keys.ToArray();
        //}

        /// <summary>
        /// Get Subject Questions Randomly
        /// </summary>
        /// <param name="subjectName">Name of Subject</param>
        /// <returns>List of Questions related to entered Subject Name</returns>
        //public static List<Question> GetQuestions(string subjectName)
        //{
        //    if (Questions.ContainsKey(subjectName))
        //    {
        //        Random rand = new Random();
        //        List<Question> Randomized = Questions[subjectName].OrderBy(_ => rand.Next()).ToList();
        //        return Randomized;
        //    }
        //    else return null;
                
        //}

        public void Add(Question val)
        {
            base.Add(val);
            string filePath = @$"{listName}.txt";
            using (StreamWriter w = File.AppendText(filePath))
            {
                w.WriteLine($"{val.getHeader()},{val.GetMarks()},{val.GetType()},{val.GetQuestionAnswers().GetAnswersString()},{val.GetModelAnswers().GetAnswersString()}");
                Console.WriteLine("Write Successful");

            }

        }
    }
}
