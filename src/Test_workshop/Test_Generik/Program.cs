

Person<int> tom = new Person<int>(546, "Tom");
Company<Person<int>> microsoft = new Company<Person<int>>(tom);

Console.WriteLine(microsoft.CEO.Id);  // 546
Console.WriteLine(microsoft.CEO.Name);  // Tom


Console.ReadLine();

// класс компании
class Company<P>
{
    public P CEO { get; set; }  // президент компании
}
