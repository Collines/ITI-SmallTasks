using Day02;


//int size;
//Console.WriteLine("Enter Array size: ");
//while (!int.TryParse(Console.ReadLine(), out size))
//{


//    Console.WriteLine("Enter a valid number");
//}
//int[] arr = new int[size];
//for (int i = 0; i < size; i++)
//{
//    int el;
//    Console.WriteLine($"Enter element({i + 1}):");
//    while (!int.TryParse(Console.ReadLine(), out el))
//    {
//        Console.WriteLine("Enter a valid number");
//    }
//    arr[i] = el;
//}

//int element = 0, index1 = 0, index2 = 0;
//for (int i = 0; i < arr.Length; i++)
//{
//    for (int j = 1; j < arr.Length; j++)
//    {
//        if (arr[i] == arr[j])
//        {
//            if (index2 - index1 < j - i)
//            {
//                index1 = i;
//                index2 = j;
//                element = arr[i];
//            }
//        }
//    }
//}
//Console.WriteLine($"the difference between {element} and the last {element} is {index2 - index1 - 1} cells");

//NIC x = NIC.instance;
//NIC y = NIC.instance;
//Console.WriteLine(x.GetHashCode());
//Console.WriteLine(y.GetHashCode());
//x.connectionData();
//y.connectionData();
X x = new X(10, true, new int[] {1,2,3,4});
X y = new X(20, false, new int[] { 10, 20, 30, 40 });
Console.WriteLine(x.ToString());
Console.WriteLine(y.ToString());
y.clone(x);
x.x = 19999;
x.arr[0] = 200;
Console.WriteLine(x.ToString());
Console.WriteLine(y.ToString());