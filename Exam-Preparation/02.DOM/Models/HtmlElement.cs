namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }

        public bool AddAttribute(string key, string value)
        {
            throw new NotImplementedException();
        }

        public bool HasId(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAttribute(string key)
        {
            throw new NotImplementedException();
        }
    }
}
