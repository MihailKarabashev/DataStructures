using TrainingTree;
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

var integerTree = new IntegerTree(7,
                     new IntegerTree(19,
                        new IntegerTree(1),
                        new IntegerTree(12),
                        new IntegerTree(31)),
                     new IntegerTree(21),
                     new IntegerTree(14,
                        new IntegerTree(23),
                        new IntegerTree(6))
                     );

//var ss = tree.AsString();
//Console.WriteLine(ss);

//var leafKeys = tree.GetLeafKeys();
//Console.WriteLine(string.Join(" ", leafKeys));

//var internalKeys = tree.GetInternalKeys();
//Console.WriteLine(string.Join(" ", internalKeys));

//var deepestKey = tree.GetDeepestKey();
//Console.WriteLine(deepestKey);

//var longestPath = tree.GetLongestPath();
//Console.WriteLine(string.Join(" ", longestPath));

//var integerthreepaths = integerTree.GetPathsWithGivenSum(27);

//foreach (var integerthreepath in integerthreepaths)
//{
//    foreach (var item in integerthreepath)
//    {
//        Console.Write(item + " ");
//    }
//    Console.WriteLine();
//}

var subTreeWithGivenSum = integerTree.GetSubtreesWithGivenSum(63);
Console.WriteLine(string.Join(" ", subTreeWithGivenSum.Select(x => x.Key)));




