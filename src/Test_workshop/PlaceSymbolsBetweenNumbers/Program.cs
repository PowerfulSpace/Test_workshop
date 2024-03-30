
//Have the function ArrayChallenge(arr) take the array of numbers stored in arr and return
//the number that appears most frequently (the mode). For example: if arr contains[10, 4, 5, 2, 4]
//the output should be 4. If there is more than one mode return the one that appeared
//in the array first (ie. [5, 10, 10, 6, 5] should return 5 because it appeared first).
//If there is no mode return -1. The array will not be empty.




using System.Text;

int num = 439810382;
string myString = num.ToString();

List<int> nums = new List<int>();

foreach (var item in myString)
{
    nums.Add((int)char.GetNumericValue(item));
}

List<char> chars = new List<char>();
for (int i = 1; i < nums.Count; i++)
{
    if (nums[i - 1] % 2 == 0 && nums[i] % 2 == 0)
    {
        chars.Add('-');
        chars.Add((char)nums[i]);
    }
    else if (nums[i - 1] % 2 != 0 && nums[i] % 2 != 0)
    {
        chars.Add('*');
        chars.Add((char)nums[i]);
    }
    else
    {
        chars.Add((char)nums[i]);
    }
}

StringBuilder stringBuilder = new StringBuilder();

foreach (var item in chars)
{
    if ((int)item <= 9)
    {
        stringBuilder.Append((int)item);
    }
    else
    {
        stringBuilder.Append(item);
    }
}

Console.WriteLine(stringBuilder.ToString());

Console.ReadLine();


