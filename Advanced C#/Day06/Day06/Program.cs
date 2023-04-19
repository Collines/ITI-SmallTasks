using Day06;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;
using static Day06.ListGenerators;
StreamReader streamReader = new StreamReader("dictionary_english.txt", System.Text.Encoding.UTF8);
List<string> lst = new List<string>();
foreach (string line in File.ReadLines(@"dictionary_english.txt"))
    lst.Add(line);
lst.ToArray();
//var Result = ProductList.Where(P=> P.UnitsInStock ==0);
//foreach(var item in Result)
//    Console.WriteLine(item);
//Console.WriteLine("------------------------");
//Result = ProductList.Where(P => P.UnitsInStock > 0).Where(p => p.UnitPrice > 3);
//foreach (var item in Result)
//    Console.WriteLine(item);
//Console.WriteLine("------------------------");
//string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
//var R = Arr.Where((d, i) => d.Length < i);
//foreach (var item in R)
//    Console.WriteLine(item);
//Console.WriteLine("------------------------");
//var F = ProductList.Where(P => P.UnitsInStock == 0).FirstOrDefault();
//Console.WriteLine(F);
//Console.WriteLine("------------------------");
//F = ProductList.Where(P => P.UnitPrice > 1000).FirstOrDefault();
//Console.WriteLine(F);
//Console.WriteLine("------------------------");
//int[] AR = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var X = AR.Where(D => D > 5).OrderBy(d => d).Where((D, i) => i == 1);
//foreach(var item in X)
//    Console.WriteLine(item);
//Console.WriteLine("------------------------");
//Result = ProductList.OrderBy(p => p.ProductName);
//foreach (var item in Result)
//    Console.WriteLine(item);
//Console.WriteLine("------------------------");
//string[] AB = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
//var L = AB.OrderBy(p=> p );
//foreach(var x in L)
//    Console.WriteLine(x);
//Console.WriteLine("------------------------");
//Result = ProductList.OrderByDescending(p => p.UnitPrice);
//foreach (var item in Result)
//    Console.WriteLine(item);
//Console.WriteLine("------------------------");
// string[] AC = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
//var C = AC.OrderBy(e => e.Length).ThenBy(p => p);
//foreach (var x in C)
//    Console.WriteLine(x);
//Console.WriteLine("------------------------");
//L.OrderBy(e => e.Length).ThenBy(p => p,new CaseInsensitiveSortComparer());
//foreach (var x in L)
//    Console.WriteLine(x);
//Console.WriteLine("------------------------");
//Result = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
//foreach (var item in Result)
//    Console.WriteLine(item);
//Console.WriteLine("------------------------");
//string[] AX = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
//Array.Reverse(AX);
//var AZ = AX.Where(e => e[1] == 'i');
//foreach (var item in AZ)
//    Console.WriteLine(item);


////////////////////////////////////////// DAY 07 ///////////////////////////////////
/*Console.WriteLine("--------------- 01");
var Results = ProductList.DistinctBy(p => p.Category);
foreach(var result in Results)
    Console.WriteLine(result.Category);
Console.WriteLine("--------------- 02");
var Results2 = ProductList.Select(Product => Product.ProductName[0]);
var Results3 = CustomerList.Select(C => C.CompanyName[0]);
var Results4 = Results2.Concat(Results3).Distinct();
foreach(var result in Results4)
    Console.WriteLine(result);
Console.WriteLine("--------------- 03");
var Results5 = Results2.Intersect(Results3);
foreach (var result in Results5)
    Console.WriteLine(result);
Console.WriteLine("--------------- 04");
var Results6 = Results2.Except(Results3);
foreach (var result in Results6)
    Console.WriteLine(result);
Console.WriteLine("--------------- 05");
var Results7 = ProductList.Select(Product => Product.ProductName[^3..^0]);
var Results8 = CustomerList.Select(C => C.CompanyName[^3..^0]);
var Results9 = Results7.Concat(Results8);
foreach (var result in Results9)
    Console.WriteLine(result);*/

/*Console.WriteLine("--------------- AGGREGATES ------------------");
Console.WriteLine("--------------- 01");
int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var Result = Arr.Where(e => e % 2 != 0).Count();
Console.WriteLine(Result);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 02");
var Result2 = CustomerList.Select(C => $"{C.CompanyName} - {C?.Orders.Count()}").ToList();
foreach (var r in Result2)
    Console.WriteLine(r);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 03");
var Result3 = ProductList.GroupBy(P => P.Category);

foreach (var r in Result3)
{
    Console.WriteLine($"{r.Key}: {r.Count()}");
}
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 04");
int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var Result4 = Arr3.Sum();
Console.WriteLine(Result4);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 05");

var Result5 = lst.Select(e => e.Length);
int sum = 0;
foreach (var r in Result5)
    sum += r;
Console.WriteLine($"{sum} characters");
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 06");
var Result6 = ProductList.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category);
foreach (var r in Result6)
    Console.WriteLine($"{r.Key}: {r.Count()}");
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 07");
var Result7 = lst.Min(e => e.Length);
Console.WriteLine(Result7);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 08");
var Result8 = ProductList.GroupBy(p => p.Category);
foreach (var r in Result8)
    Console.WriteLine($"{r.Key}: {r.Min(p => p.UnitPrice):c}");
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 09");
var Result9 = from P in ProductList
              group P by P.Category into prdGrps
              let product = prdGrps.MinBy(p => p.UnitPrice)
              select new {Category = prdGrps.Key, product };
foreach (var item in Result9)
{
    Console.WriteLine(item);
}
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 10");
var Result10 = lst.Max(e => e.Length);
Console.WriteLine(Result10);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 11");
var Result11 = ProductList.GroupBy(p => p.Category);
Console.WriteLine("Max Prices");
foreach (var r in Result11)
    Console.WriteLine($"{r.Key}: {r.Max(p => p.UnitPrice):c}");
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 12");
var Result12 = from P in ProductList
               group P by P.Category into groups
               let x = groups.MaxBy(g => g.UnitPrice)
               select new { groups.Key, x };
foreach (var s in Result12)
    Console.WriteLine(s);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 13");
var Result13 = lst.Average(e => e.Length);
Console.WriteLine((int)Result13);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 14");
var Result14 = ProductList.GroupBy(p => p.Category);
Console.WriteLine("Average Prices");
foreach (var r in Result11)
    Console.WriteLine($"{r.Key}: {r.Average(p => p.UnitPrice):c}");
Console.ReadLine();
Console.Clear();*/

/*Console.WriteLine("--------------- Partitioning ------------------");
Console.WriteLine("--------------- 01");
var Result1 = CustomerList.Where(c => c.Region == "WA").Select(C=> C.Orders);
foreach(var result in Result1)
{   
    foreach(var o in result.Take(3))
        Console.WriteLine(o);
    Console.WriteLine("----------");
}
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 02");
var Result2 = CustomerList.Where(c => c.Region == "WA").Select(C => C.Orders);
foreach (var result in Result2)
{
    foreach (var o in result.Skip(2))
        Console.WriteLine(o);
    Console.WriteLine("----------");
}
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 03");
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var Result3 = numbers.TakeWhile((e, i) => e > i);
foreach (var n in Result3)
     Console.WriteLine(n);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 04");
var Result4 = numbers.SkipWhile(e => e % 3 != 0);
foreach (var n in Result4)
    Console.WriteLine(n);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 05");
var Result5 = numbers.SkipWhile((e,i)=> e>i);
foreach (var n in Result5)
    Console.WriteLine(n);
Console.ReadLine();
Console.Clear();*/

/*Console.WriteLine("--------------- Projection Operators ------------------");
Console.WriteLine("--------------- 01");
var Result = ProductList.Select(P => P.ProductName);
foreach(var result in Result)
    Console.WriteLine(result);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 02");
string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
var Result2 = words.Select(P => new {lower= P.ToLower(),upper= P.ToUpper() });
foreach (var result in Result2)
    Console.WriteLine(result);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 03");
var Result3 = ProductList.Select(P => new {P.ProductID,P.ProductName,Price=P.UnitPrice});
foreach (var result in Result3)
    Console.WriteLine(result);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 04");
int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var Result4 = Arr.Select((e,i) => new {number=e,pos=e==i});
Console.WriteLine("Number: In-place?");
foreach (var result in Result4)
    Console.WriteLine($"{result.number}:{result.pos}");
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 05");
int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };
var Result5 = numbersA.SelectMany(x => numbersB.Where(y => x < y),(a,b)=> $"{a} is less than {b}");
foreach(var r in Result5)
    Console.WriteLine(r);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 06");
var Result6 = CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500);
foreach (var order in Result6)
    Console.WriteLine(order);
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 07");
var Result7 = CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
foreach (var order in Result7)
  Console.WriteLine(order);
Console.ReadLine();
Console.Clear();*/


/*Console.WriteLine("--------------- Quantifiers ------------------");
Console.WriteLine("--------------- 01");
var Result = lst.Any(e => Regex.IsMatch(e, "ei|EI"));
Console.WriteLine(Result);
Console.WriteLine("--------------- 02");
var Result2 = ProductList.GroupBy(p => p.Category);
    //ProductList.GroupBy(p => p.Category).SelectMany(c => c, (g, tc) => new { category = g, product = tc, condition = g.Any(p => p.UnitsInStock == 0) }).GroupBy(a => a.product.Category);
foreach (var item in Result2)
{
    if(item.Any(p=>p.UnitsInStock == 0))
    {
        Console.WriteLine(item.Key);
        foreach(var p in item)
            Console.WriteLine(p);
        Console.WriteLine("---------------");
    }
}
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 03");
var Result3 = ProductList.GroupBy(p => p.Category);
foreach (var item in Result3)
{
    if (item.All(p => p.UnitsInStock > 0))
    {
        Console.WriteLine(item.Key);
        foreach (var p in item)
            Console.WriteLine(p);
        Console.WriteLine("---------------");
    }
}
Console.ReadLine();
Console.Clear();*/


/*Console.WriteLine("--------------- Grouping ------------------");
Console.WriteLine("--------------- 01");
var NumList = Enumerable.Range(0, 15).GroupBy(x => x % 5);
var counter = 0;
foreach(var numc in NumList)
{
    Console.WriteLine($"Numbers with a remainder of {counter} when divided by 5:");
    foreach (var num in numc)
        Console.WriteLine(num);
    counter++;
}
Console.ReadLine();
Console.Clear();
Console.WriteLine("--------------- 02");
var Result2 = lst.GroupBy(e => e.ElementAt(0));
foreach (var col in Result2)
{
    Console.WriteLine($"===============================words start with {col.Key} ==============================================");
    foreach (var e in col)
        Console.WriteLine(e);
    Console.WriteLine("----------------------------------------------------------------------------------------------------");
}
Console.WriteLine("--------------- 03");
string[] Arr = { "from", "salt", "earn", "last", "near", "form" };
var Result3 = Arr.GroupBy(x => x, new AnagramComparer());
foreach (var col in Result3)
{
    Console.WriteLine(".....");
    foreach (var i in col)
        Console.WriteLine(i);
}*/
