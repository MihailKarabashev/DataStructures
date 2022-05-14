namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
            return this.links.Where(links => links.Url == url).FirstOrDefault();
        }

        public ILink LastVisited()
        {
            this.ValidateLink();

            return this.links.First.Value;
        }

        public void Open(ILink link) => this.links.AddFirst(link);

        public int RemoveLinks(string url)
        {
            var list = this.links.Where(x => x.Url.ToLower().Contains(url.ToLower())).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                this.links.Remove(list[i]);
            }

            var linksCount = this.Size;

            return linksCount == 0 ? throw new InvalidCastException() : linksCount;
        }

        public ILink[] ToArray() => this.links.ToArray();

        public List<ILink> ToList() => this.links.ToList();

        public string ViewHistory()
        {
            var sb = new StringBuilder();

            foreach (var link in this.links)
            {
                sb.AppendLine(link.ToString());
            }

            return sb.Capacity > 0 ? sb.ToString() : "Browser history is empty!";
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
