

var result = Test(3, 30);

Console.WriteLine(result);

Console.ReadLine();


//Дорешать, решить вопросс с тем что бы часовая стралка тоже смещаласьот часа к часу

static int Test(int hour, int minutes)
{
    int degree = 6;
    int x =  hour * 5 * degree;
    int y = minutes * degree;
    int result = 0;

    if(x > y)
    {
        result = x - y;
    }
    else
    {
        result = y - x;
    }

    return result;
}