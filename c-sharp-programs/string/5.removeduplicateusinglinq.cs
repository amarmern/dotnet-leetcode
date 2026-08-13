using System.Linq;

List<int> numbers = new List<int>()
{
    1,2,3,4,2,3,5
};

var result = numbers.Distinct();

foreach (var item in result)
{
    Console.WriteLine(item);
}