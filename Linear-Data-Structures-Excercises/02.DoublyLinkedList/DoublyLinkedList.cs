namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node Next { get; set; }

            public Node Previous { get; set; }

            public T Value { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item);

            if (this.head == null)
            {
                this.head = this.tail = node;
            }
            else
            {
                var oldHead = this.head;
                oldHead.Previous = node;
                this.head = node;
                this.head.Next = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node(item);

            if (this.tail == null)
            {
                this.tail = this.head = node;
            }
            else
            {
                var oldTail = this.tail;
                oldTail.Next = node;
                node.Previous = oldTail;
                this.tail = node; 
            }

            this.Count++;
        }

        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            var element = this.head.Value;

            return element;
        }

        public T GetLast()
        {
            if (this.tail == null)
            {
                throw new InvalidOperationException();
            }

            var element = this.tail.Value;

            return element;
        }

        public T RemoveFirst()
        {
           var element = this.GetFirst();

            if (this.Count == 1)
            {
                this.head = this.tail =  null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            this.Count--;

            return element;
        }

        public T RemoveLast()
        {
            var element = this.GetLast();

            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }

            this.Count--;

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.head != null)
            {
                yield return this.head.Value;
                this.head = this.head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}