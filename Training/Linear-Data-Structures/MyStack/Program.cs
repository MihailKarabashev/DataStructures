
using MyStack;

var stack = new AbstractStack<int>();

stack.Push(5);
stack.Push(6);
stack.Push(7);

foreach (var item in stack)
{
    Console.WriteLine(item);
}

