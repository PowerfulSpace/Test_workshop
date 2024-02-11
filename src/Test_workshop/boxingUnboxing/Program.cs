




Nullable<int> value;
int? value2;

Console.ReadLine();


public struct Nullable<T> where T : struct
{
    public bool HasValue { get; }
    public T Value { get; }
}