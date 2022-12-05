using System.Collections;
using System.Linq.Expressions;

namespace MyDoublyLinkedList;

public class AbstractDoublyLinkedList<T> : IEnumerable<T>
{

    private Node _head;
    private Node _tail;
    private class Node
    {
        public Node(T element)
        {
            Element = element;
        }

        public Node Next { get; set; }

        public Node Previous { get; set; }

        public T Element { get; set; }
    }

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        if (Count == 0)
        {
            _head = _tail = new Node(item); 
        }
        else
        {
            var node = new Node(item); 
            node.Next = _head;
            _head.Previous = node;
            _head = node;
        }

        Count++;
    }

    public void AddLast(T item)
    {
        if (Count == 0)
        {
            _head = _tail = new Node(item);
        }
        else
        {
            var node = new Node(item);
            node.Previous = _tail;
            _tail.Next = node;
            _tail = node;   
        }
        Count++;
    }

    public T GetFirst()
    {
        ValidateIfNotEmpty();
        return _head.Element;
    }

    public T GetLast()
    {
        ValidateIfNotEmpty();
        return _tail.Element;
    }

    public T RemoveFirst()
    {
        ValidateIfNotEmpty();
        var element = _head.Element;
        if(Count == 1)
        {
            _head = _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head.Previous = null;
        }
        Count--;
        return element;
    }

    public T RemoveLast()
    {
        ValidateIfNotEmpty();
        var element = _tail.Element;
        if (Count == 1)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.Previous;
            _tail.Next = null;
        }
        Count--;
        return element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        while (_head != null)
        {
            yield return _head.Element;
            _head = _head.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   

    private void ValidateIfNotEmpty()
    {
        if (Count <= 0) throw new NullReferenceException();
    }
}
