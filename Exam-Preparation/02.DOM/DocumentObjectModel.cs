namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            this.Root = new HtmlElement(ElementType.Document,
                              new HtmlElement(ElementType.Html,
                                   new HtmlElement(ElementType.Head),
                                   new HtmlElement(ElementType.Body)));
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement.Type == type)
                {
                    return currentElement;
                }

                foreach (var child in currentElement.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            var list = new List<IHtmlElement>();
            this.GetElementsByTypeDfs(this.Root, list, type);

            return list;
        }

        private void GetElementsByTypeDfs(IHtmlElement node, List<IHtmlElement> list, ElementType type)
        {
            foreach (var child in node.Children)
            {
                this.GetElementsByTypeDfs(child, list, type);
            }

            if (node.Type == type)
            {
                list.Add(node);
            }
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return this.FindElement(htmlElement) != null;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            this.ValidateElementExsist(parent);
            parent.Children.Insert(0, child);
            child.Parent = parent;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            this.ValidateElementExsist(parent);
            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void Remove(IHtmlElement htmlElement)
        {
        }

        public void RemoveAll(ElementType elementType)
        {
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public IHtmlElement GetElementById(string idValue)
        {
            throw new NotImplementedException();
        }

        private void ValidateElementExsist(IHtmlElement element)
        {
            if (!this.Contains(element))
            {
                throw new InvalidOperationException();
            }
        }

        private IHtmlElement FindElement(IHtmlElement element)
        {
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement == element)
                {
                    return element;
                }

                foreach (var child in currentElement.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
