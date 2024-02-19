

Person<int> tom = new Person<int>(546, "Tom");
Company<Person<int>> microsoft = new Company<Person<int>>(tom);


// класс компании
class Company<P>
{
    public P CEO { get; set; }  // президент компании
    public Company(P ceo)
    {
        CEO = ceo;
    }
}

class Person<T>
{
    public T Id { get; }
    public string Name { get; }
    public Person(T id, string name)
    {
        Id = id;
        Name = name;
    }
}