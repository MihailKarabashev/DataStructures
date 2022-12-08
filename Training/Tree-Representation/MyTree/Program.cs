using MyTree;

var tree = new Tree<string>("A",
         new Tree<string>("B",
                         new Tree<string>("E"),
                         new Tree<string>("G")),
         new Tree<string>("C"),
         new Tree<string>("D", 
                          new Tree<string>("H")));

//var bfsTree = tree.OrderBfs();

//foreach (var item in bfsTree)
//{
//    Console.Write(item + " ");
//}


var dfsTree = tree.OrderDfs();

foreach (var item in dfsTree)
{
    Console.Write(item + " ");
}
