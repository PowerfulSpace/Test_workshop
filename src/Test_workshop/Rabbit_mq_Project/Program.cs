



string a = "125";
string b = "Hello";
string c = "12.5";
string d = "true";

string[] array = {a, b, c, d};

Console.ReadLine();





static void Method(string[] array)
{
    bool resultBool = false;
    int resultInt = 0;
    double resultDouble = 0;
    string resultString = string.Empty;


    foreach (var item in array)
    {
        if (IsDigit(item) != 0)
        {
            //Записывает Int
        }
        else if(IsDouble(item) != 0)
        {
            //Записывает double
        }
        else if (IsBool(item) != false)
        {
            //Записывает bool
        }
        else
        {
            //Записывает string
        }
    }
}


static int IsDigit(string meaning)
{
    int digit;
    bool isDigit = false;
    isDigit = int.TryParse(meaning, out digit);
    return digit;
}

static double IsDouble(string meaning)
{
    double digit;
    bool isDigit = false;
    isDigit = double.TryParse(meaning, out digit);
    return digit;
}

static bool IsBool(string meaning)
{
    bool booling;
    bool isBool = false;
    isBool = bool.TryParse(meaning, out booling);
    return booling;
}
