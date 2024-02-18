using People = System.Collections.Generic.List<Person>;

People people = new() { new("Tom", 38), new("Bob", 42) };
people.ForEach(Console.WriteLine);




Console.WriteLine("{0:#### (###-##-##)}",80293190884);

int[] nums1 = { 1, 2, 3, 4 };
int[] nums2 = new int[] { };   // пустой массив




var welcome = (string message = "hello") => Console.WriteLine(message);

welcome("hello world"); // hello world
welcome();              // hello


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

public record Person(string Name, int Age);


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
