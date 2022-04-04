using Problem03.Queue;

IAbstractQueue<int> queue = new Problem03.Queue.Queue<int>();

var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
foreach (var num in numbers)
{
    queue.Enqueue(num);
}


foreach (var item in queue)
{
    Console.WriteLine(item);
}
