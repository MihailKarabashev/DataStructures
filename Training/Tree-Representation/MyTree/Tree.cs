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

    public IEnumerable<T> OrderBfs()
    {
        var queue = new Queue<Tree<T>>();
        var result = new List<T>();
        queue.Enqueue(this);

        // A B C D

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
}
