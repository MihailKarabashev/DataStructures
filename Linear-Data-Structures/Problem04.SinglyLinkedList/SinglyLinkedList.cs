namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public int Count { get; private set;}

        public void AddFirst(T item)
        {
            var node = new Node(item);

            var oldHead = this.head;
            this.head = node;
            this.head.Next = oldHead;

            this.Count++;
        }

        public void AddLast(T item)
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

        public IEnumerator<T> GetEnumerator()
        {
            while (this.head != null)
            {
                yield return this.head.Element;
                this.head = this.head.Next;
            }
        }

        public T GetFirst() => this.GetElementIfExsist();

        public T GetLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;

            while (oldHead.Next != null)
            {
                oldHead = oldHead.Next;
            }

            return oldHead.Element;
        }

        public T RemoveFirst()
        {
            var firstElement = this.GetFirst();
            this.head = this.head.Next;

            this.Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;
            T element = default;

            if (this.Count ==  1)
            {
                element = oldHead.Element;
                oldHead.Next = default;
            }
            else
            {
                while (oldHead.Next.Next != null)
                {
                    oldHead = oldHead.Next;
                }

                 element = oldHead.Element;
                oldHead.Next = default;
            }


            this.Count--;

            return element;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private T GetElementIfExsist()
             => this.head == null 
            ? throw new InvalidOperationException()
            : this.head.Element;
    }
}