namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private LinkedList<ILink> links;

        public BrowserHistory()
        {
            this.links = new LinkedList<ILink>();
        }

        public int Size => this.links.Count;

        public void Clear() => this.links.Clear();

        public bool Contains(ILink link) => this.links.Contains(link);

        public ILink DeleteFirst()
        {
            this.ValidateLink();

            var firstLink = this.links.Last.Value;

            links.RemoveLast();

            return firstLink;
        }

        public ILink DeleteLast()
        {
            this.ValidateLink();

            var lastLink = this.LastVisited();
            links.RemoveFirst();

            return lastLink;
        }

        public ILink GetByUrl(string url)
        {
            throw new NotImplementedException();
        }

        public ILink LastVisited()
        {
            this.ValidateLink();

            return this.links.First.Value;
        }

        public void Open(ILink link) => this.links.AddFirst(link);

        public int RemoveLinks(string url)
        {
            throw new NotImplementedException();
        }

        public ILink[] ToArray()
        {
            var arr = new ILink[this.Size];

            var count = 0;

            while (this.Size != 0)
            {
                var ss = this.DeleteLast();
                arr[count++] = ss;
            }

            return arr;
        }

        public List<ILink> ToList()
        {
            throw new NotImplementedException();
        }

        public string ViewHistory()
        {
            throw new NotImplementedException();
        }

        private void ValidateLink()
        {
            if (this.Size == 0)
            {
                throw new InvalidCastException();
            }
        }
    }
}
