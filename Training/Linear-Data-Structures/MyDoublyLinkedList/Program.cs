

using MyDoublyLinkedList;

var doubly = new AbstractDoublyLinkedList<string>();

doubly.AddLast("koce");
doubly.AddLast("misho");    
doubly.AddLast("neli");

foreach (var item in doubly)
{
    Console.WriteLine(item);
}