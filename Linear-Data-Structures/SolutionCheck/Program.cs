using Problem01.List;
using Problem02.Stack;

IAbstractStack<string> stack = new Problem02.Stack.Stack<string>();

stack.Push("first");
stack.Push("secound");


foreach (var item in stack)
{
    Console.WriteLine(item);
}