using System.Data.SqlTypes;
using System.Reflection.Metadata;

namespace MyTree;

public class Tree<T> : IAbstractTree<T>
{
    private readonly List<Tree<T>> _children;
    private Tree<T> _parent;
    private T _value;

    public Tree(T value)
    {
        _value = value;
        _children = new List<Tree<T>>();
    }

    public Tree(T value, params Tree<T>[] children)
        :this(value)
    {
        foreach (var child in children)
        {
            child._parent = this;
            _children.Add(child);
        }
    }

    public void RemoveNode(T nodeKey)
    {
        var queue = new Queue<Tree<T>>();
        queue.Enqueue(this);

        if (queue.Peek()._value.Equals(nodeKey)) throw new ArgumentException(nameof(nodeKey));


        while (queue.Count > 0)
        {
            var currentTree = queue.Dequeue();

            if(currentTree._value.Equals(nodeKey)
                && (currentTree._children.Count > 0 || currentTree._children.Count == 0))
            {
                currentTree._parent._children.Remove(currentTree);  
            }


            foreach (var child in currentTree._children)
            {
                queue.Enqueue(child);
            }
        }
    }

    public void AddChild(T parentKey, Tree<T> child)
    {

        var tree = AddChildWithBfs(parentKey);

        if (tree is null) throw new ArgumentNullException();
        tree._children.Add(child);
        child._parent = tree;

        //var queue = new Queue<Tree<T>>();
        //queue.Enqueue(this);
        //bool isFound = false;
        ////  A
        ////B   C

        //while (queue.Count > 0)
        //{
        //    //A
        //    var tree = queue.Dequeue();

        //    if (tree._value.Equals(parentKey))
        //    {
        //        isFound = true;
        //        tree._children.Add(child);
        //        break;
        //    }

        //    foreach (var item in tree._children)
        //    {
        //        queue.Enqueue(item);
        //    }
        //}

        //if (!isFound)
        //{
        //    throw new ArgumentNullException();
        //}

        //bool isFound = false;
        //AddChildWithDfs(this, ref isFound,parentKey,child);

        //if (!isFound) throw new ArgumentNullException();
    }

    public IEnumerable<T> OrderBfs()
    {
        var queue = new Queue<Tree<T>>();
        var result = new List<T>();
        queue.Enqueue(this);

        //    A 
        //  B    C
        //D

        while (queue.Count > 0)
        {
            var parent = queue.Dequeue();
            result.Add(parent._value);

            foreach (var child in parent._children) 
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }

    public IEnumerable<T> OrderDfs()
    {
        var result = new List<T>();

        Dfs(this, result);

        return result;
    }

    private void Dfs(Tree<T> tree, IList<T> result)
    {
        foreach (var child in tree._children)
        {
            Dfs(child,result);
        }

        result.Add(tree._value);
    }

    private Tree<T> AddChildWithBfs(T parentKey)
    {
        var queue = new Queue<Tree<T>>();
        queue.Enqueue(this);


        while (queue.Count > 0)
        {
            var tree = queue.Dequeue();

            if (tree._value.Equals(parentKey))
            {
                return tree;
            }

            foreach (var item in tree._children)
            {
                queue.Enqueue(item);
            }
        }

        return null;
    }

    private void AddChildWithDfs(Tree<T> tree, ref bool isFound, T parentKey, Tree<T> child)
    {
        foreach (var item in tree._children)
        {
            if (item._value.Equals(parentKey))
            {
                item._children.Add(child);
                isFound = true;
                break;
            }

            AddChildWithDfs(item, ref isFound, parentKey, child);
        }
    }

    public void Swap(T firstKey, T secondKey)
    {
        var listOfTrees = FindMultipleTreesByKey(firstKey, secondKey);

        var firstNode = listOfTrees[0];
        var secoundNode = listOfTrees[1];

        if (firstNode is  null || secoundNode is  null)
        {
            throw new ArgumentException();
        }

        var firstParent = firstNode._parent;
        var secoundParent = secoundNode._parent;


        var indexOfFirstNode = firstParent._children.IndexOf(firstNode);
        var indexOfSecundNode = secoundParent._children.IndexOf(secoundNode);

        //7
        //19 21 14

        firstParent._children[indexOfFirstNode] = secoundNode;
        secoundNode._parent = firstParent;

        secoundParent._children[indexOfSecundNode] = firstNode;
        firstNode._parent = secoundParent;
    }

    private List<Tree<T>> FindMultipleTreesByKey(T firstKey, T secondKey)
    {
        var list = new List<Tree<T>>();

        var queue = new Queue<Tree<T>>();
        queue.Enqueue(this);

        if (queue.Peek()._value.Equals(firstKey) || queue.Peek()._value.Equals(secondKey))
            throw new ArgumentException("You cannot swap the root element!");


        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (currentNode._value.Equals(secondKey) || currentNode._value.Equals(firstKey)) 
                  list.Add(currentNode);

            if(list.Count > 1)
                break;


            foreach (var child in currentNode._children)
            {
                queue.Enqueue(child);
            }
        }

        return list;
    }
}
