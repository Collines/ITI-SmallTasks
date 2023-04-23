////// Task #3
using Day06;

Duration D1 = new Duration(0, 2, 0);
Duration D2 = new Duration(300);
//D1.Show();
//D2.Show();
//if(D2)
//{
//    D2.Show();
//}
//else Console.WriteLine("Non valid duration");

Duration D3 = D2 - D1;
D3.Show();
Duration D4 = D3++;
D4.Show();
D3.Show();
//if(D1== D2)
//{
//    Console.WriteLine("D1 == D2");
//}
//else if(D1 >= D2)
//{
//    Console.WriteLine("D1 > D2");
//} else
//    Console.WriteLine("D1 < D2");