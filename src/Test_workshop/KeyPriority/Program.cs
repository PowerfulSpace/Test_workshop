


Dictionary<char, int> keys = new Dictionary<char, int>
{
    {'5',2 },
    {'3',2 },
    {'7',2 },
    {'6',4 },
    {'1',2 },
    {'9',3 },
    {'8',4 },
    {'4',1 },
    {'2',1 },
};

GetPriority(keys);





Console.ReadLine();


static List<char> GetPriority(Dictionary<char, int> keys)
{
    var list = keys.OrderBy(x => x.Value);

    List<char> list2 = list.Select(x => x.Key).ToList();
    list2.Reverse();
    return list2;
}

