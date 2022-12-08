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

    private void AddChildWithDfs(Tree<T> tree,  ref bool isFound, T parentKey, Tree<T> child)
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
}
