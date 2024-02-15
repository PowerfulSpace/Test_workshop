

void Sum(int[] numbers, int initialValue)
{
    int result = initialValue;
    foreach (var n in numbers)
    {
        result += n;
    }
    Console.WriteLine(result);
}

int[] nums = { 1, 2, 3, 4, 5 };
Sum(nums, 10);

Console.ReadLine();


#region Задачки для понимания строк 3, сложный пример

//string a = new string(new char[] { 'a', 'b', 'c' });
//object o = String.Copy(a);
//Console.WriteLine(object.ReferenceEquals(o, a));
//String.Intern(o.ToString());
//Console.WriteLine(object.ReferenceEquals(o, String.Intern(a)));



//string a = new string(new char[] { 'a', 'b', 'c' });
//object o = String.Copy(a);
//Console.WriteLine(object.ReferenceEquals(o, a));
//String.Intern(o.ToString());
//Console.WriteLine(object.ReferenceEquals(o, String.Intern(a)));

//object o2 = String.Copy(a);
//String.Intern(o2.ToString());
//Console.WriteLine(object.ReferenceEquals(o2, String.Intern(a)));

#endregion


#region Задачки для понимания строк 2

//string hello = "hello";
//string helloWorld = "hello world";
//string helloWorld2 = hello + " world";

//Console.WriteLine("{0}, {1}: {2}, {3}", helloWorld, helloWorld2,
//    helloWorld == helloWorld2,
//    object.ReferenceEquals(helloWorld, helloWorld2));




//string hello = "hello";
//string helloWorld = "hello world";
//string helloWorld2 = "hello world";
//Console.WriteLine("{0}, {1}: {2}, {3}", helloWorld, helloWorld2,
//    helloWorld == helloWorld2,
//    object.ReferenceEquals(helloWorld, helloWorld2));


#endregion





#region Задачки для понимания строк 1


//string a = "hello world";
//string b = a;
//a = "hello";
//Console.WriteLine("{0}, {1}", a, b);
//Console.WriteLine(a == b);
//Console.WriteLine(object.ReferenceEquals(a, b));

#endregion




#region Задачки для понимания с массивом значимых элементом


//int[] array = new int[3] { 10, 15, 20 };


//Method(array);

//Console.WriteLine(array[0]);

//Console.ReadLine();



//static void Method(int[] array)
//{
//    array = new int[3];
//    array[0] = 25;
//}



//Пример 1

//int[] array = new int[3] { 10, 15, 20 };


//Method(array);

//Console.WriteLine(array[0]);

//Console.ReadLine();



//static void Method(int[] array)
//{
//    array[0] = 25;
//}
#endregion
