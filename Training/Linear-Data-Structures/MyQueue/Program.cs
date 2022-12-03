using MyQueue;

var queue = new AbstactQueue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

var ss = queue.Dequeue();


foreach (var item in queue)
{
    Console.WriteLine(item);
}
