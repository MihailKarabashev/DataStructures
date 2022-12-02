using System.Collections;

namespace MyStack;

public class AbstractStack<T> : IAbstractStack<T>
{
    private Node _top;

    private class Node
    {
        public Node(T element, Node next)
        {
            Element = element;
            Next = next;
        }

        public T Element { get; set; }

        public Node Next { get; set; }
    }

    public int Count { get; private set; }

    public void Push(T item)
    {
        var node = new Node(item, _top);
        _top= node;
        Count++;
    }

    public T Pop()
    {
        ValidateTop(_top);
        var element = _top.Element;
        _top=_top.Next;

        Count--;
        return element;
    }

    public T Peek()
    {
        ValidateTop(_top);
        return _top.Element;
    }

    public bool Contains(T item)
    {
        while(_top != null)
        {
            if (_top.Element.Equals(item)) return true;

            _top = _top.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        while (_top != null)
        {
            yield return _top.Element;
            _top = _top.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void ValidateTop(Node top)
    {
        if (_top == null) throw new NullReferenceException();
    }
}
