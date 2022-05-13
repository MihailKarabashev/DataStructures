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

        public int Size { set; get; }

        public void Clear()
        {
            this.links.Clear();
        }

        public bool Contains(ILink link)
        {
            throw new NotImplementedException();
        }

        public ILink DeleteFirst()
        {
            throw new NotImplementedException();
        }

        public ILink DeleteLast()
        {
            throw new NotImplementedException();
        }

        public ILink GetByUrl(string url)
        {
            throw new NotImplementedException();
        }

        public ILink LastVisited()
        {
            throw new NotImplementedException();
        }

        public void Open(ILink link)
        {
        }

        public int RemoveLinks(string url)
        {
            throw new NotImplementedException();
        }

        public ILink[] ToArray()
        {
            throw new NotImplementedException();
        }

        public List<ILink> ToList()
        {
            throw new NotImplementedException();
        }

        public string ViewHistory()
        {
            throw new NotImplementedException();
        }
    }
}
