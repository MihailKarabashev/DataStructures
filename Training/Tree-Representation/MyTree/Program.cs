using MyTree;

//var tree = new Tree<string>("A",
//         new Tree<string>("B",
//                         new Tree<string>("E"),
//                         new Tree<string>("G")),
//         new Tree<string>("C"),
//         new Tree<string>("D", 
//                          new Tree<string>("H")));

//var bfsTree = tree.OrderBfs();

//foreach (var item in bfsTree)
//{
//    Console.Write(item + " ");
//}


//tree.AddChild("C", new Tree<string>("Misho"));

//var treeBfs = tree.OrderBfs();

//foreach (var item in treeBfs)
//{
//    Console.WriteLine(item);
//}


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


tree.RemoveNode(19);
var bfsTree = tree.OrderBfs();

foreach (var item in bfsTree)
{
    Console.Write(item + " ");
}