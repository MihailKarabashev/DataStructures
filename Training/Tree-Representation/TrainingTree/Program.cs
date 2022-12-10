using Tree;

var tree = new Tree<int>(7,
                     new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                     new Tree<int>(21),
                     new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6))
                     );

//var ss = tree.AsString();
//Console.WriteLine(ss);

var leafKeys = tree.GetLeafKeys();
Console.WriteLine(string.Join(" ", leafKeys));


