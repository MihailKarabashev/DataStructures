

var doublyLinkedList = new Problem02.DoublyLinkedList.DoublyLinkedList<int>();

doublyLinkedList.AddFirst(1);
doublyLinkedList.AddFirst(2);
doublyLinkedList.AddFirst(3);


doublyLinkedList.RemoveFirst();
doublyLinkedList.RemoveFirst();


foreach (var item in doublyLinkedList)
{
    Console.WriteLine(item);
}