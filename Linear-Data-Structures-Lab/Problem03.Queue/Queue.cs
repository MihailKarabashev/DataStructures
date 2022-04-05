namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        private Node head;

        public int Count {get; private set;}

        public void Enqueue(T item)
        {
            var node = new Node(item);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {

                var oldHead = this.head;

                while (oldHead.Next != null)
                {
                    oldHead = oldHead.Next;
                }

                oldHead.Next = node;
            }   

            this.Count++;
        }

        public T Dequeue()
        {
            var element = this.ValidateItem();

            this.head = this.head.Next;
            this.Count--;

            return element;
        }

        public T Peek() => this.ValidateItem();

        public bool Contains(T item)
        {
            while(this.head != null)
            {
                if (this.head.Element.Equals(item))
                {
                    return true;
                }

                this.head = this.head.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.head != null)
            {
                yield return this.head.Element;
                this.head = this.head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private T ValidateItem() 
            => this.head == null 
            ? throw new InvalidOperationException()
            : this.head.Element;
    }
}