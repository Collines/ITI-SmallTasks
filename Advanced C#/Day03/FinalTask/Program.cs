using FinalTask;
using System.Collections;
//byte choice;
//Subject Subj;
//IExam Exam;
QuestionsListHandler eng = new QuestionsListHandler("English");
eng.Add(new TrueFalseQuestion("Love so much food", 2.5f, new Answer(new string[] { "True" })));
eng.Add(new ChooseOneQuestion("I came _____ America.", 2.5f, new Answer(new string[] { "from", "at", "in", "on" }), new Answer(new string[] { "from" })));
QuestionsListHandler ar = new QuestionsListHandler("Arabic");
ar.Add(new TrueFalseQuestion("Love so much food", 2.5f, new Answer(new string[] { "True" })));
ar.Add(new ChooseOneQuestion("I came _____ America.", 2.5f, new Answer(new string[] { "from", "at", "in", "on" }), new Answer(new string[] { "from" })));

//string[] SubjectsName = QuestionsHandler.GetKeys(); // GET SUBJECT NAMES (keys)
//do
//{
//    int i = 1;
//    Console.WriteLine("Enter the subject you want to be tested in");
//    foreach (var key in SubjectsName)
//    {
//        Console.WriteLine($"{i}. {key}"); // printing subject names to make user choose from them
//        i++;
//    }
//    Console.WriteLine("0. Exit");
//    while (!byte.TryParse(Console.ReadLine(), out choice) || choice > SubjectsName.Length || choice < 0)
//    {
//        Console.WriteLine("Enter a valid number");
//    }
//    if (choice != 0)
//    {
//        Subj = new Subject(SubjectsName[choice - 1], QuestionsHandler.GetQuestions(SubjectsName[choice - 1]));
//        Console.WriteLine("Enter Exam type \n1.Practical\n2.Final");
//        while (!byte.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
//        {
//            Console.WriteLine("Enter a valid number");
//        }
//        if (Subj)
//        {
//            switch (choice)
//            {
//                case 1:
//                    Exam = new Practical(Subj);
//                    Exam.StartExam();
//                    Console.WriteLine("\n");
//                    break;
//                case 2:
//                    Exam = new Exam(Subj);
//                    Exam.StartExam();
//                    Console.WriteLine("\n");
//                    break;
//                default:
//                    Exam = null;
//                    break;
//            }
//        }
//    }
//} while (choice != 0);