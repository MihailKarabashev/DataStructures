namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }

            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
                : this(element, null)
            {
            }

            public Node()
            {
            }
        }

       
        private Node top;

        public int Count  { get; private set; }

        //last in
        public void Push(T item)
        {
            var node = new Node(item);
            node.Next = this.top;
            this.top = node;
            this.Count++;
        }

        //first out
        public T Pop()
        {
            var element = this.ReturnNodeElement();

            this.top = this.top.Next;
            this.Count--;

            return element;
        }

        public T Peek() => this.ReturnNodeElement();

        public bool Contains(T item)
        {
            while (this.top != null)
            {
                if (this.top.Element.Equals(item))
                {
                    return true;
                }

                this.top = this.top.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.top != null)
            {
                yield return this.top.Element;
                this.top = this.top.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private T ReturnNodeElement()
            => this.top == null
                        ? throw new InvalidOperationException()
                        : this.top.Element;
    }
}