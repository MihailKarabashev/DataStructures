﻿namespace _02.DOM
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
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            throw new NotImplementedException();
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            throw new NotImplementedException();
        }


        public bool Contains(IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
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
    }
}
