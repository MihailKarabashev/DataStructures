namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
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
            this.ValidateElementExsist(htmlElement);

            this.ClearElementReferences(htmlElement);
        }

        public void RemoveAll(ElementType elementType)
        {
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();

                if(current.Type == elementType)
                {
                   this.ClearElementReferences(current);
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            this.VisualizeDomDfs(this.Root, 0, sb);
            return sb.ToString().TrimEnd();
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            this.ValidateElementExsist(htmlElement);
            return htmlElement.AddAttribute(attrKey, attrValue);
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            this.ValidateElementExsist(htmlElement);
            return htmlElement.RemoveAttribute(attrKey);
        }

        public IHtmlElement GetElementById(string idValue)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement.HasId(idValue))
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

        private void VisualizeDomDfs(IHtmlElement node, int indent, StringBuilder sb)
        {
            sb.Append(' ', indent).AppendLine(node.Type.ToString());

            foreach (var child in node.Children)
            {
                this.VisualizeDomDfs(child, indent + 2, sb);
            }
        }

        private void ClearElementReferences(IHtmlElement element)
        {
            var parent = element.Parent;
            element.Parent = null;
            element.Children.Clear();
            parent.Children.Remove(element);
        }
    }
}
