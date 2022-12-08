var array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var stack = new Stack<int>(array);


foreach (var item in stack)
{
    Console.Write(item + " ");
}

