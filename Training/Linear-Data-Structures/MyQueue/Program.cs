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



// Node => Node Next , T Element
// Queue => private Node _head / private Node _tail
// _head = new Node()/ _tail = 2
// var oldTail = _tail
// _tail = 3
// oldTail.Next = _tail