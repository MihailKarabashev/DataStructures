using System;
using System.Collections.Generic;
using Tree;

var tree = new Tree<string>("A",
                   new Tree<string>("B",
                                       new Tree<string>("E"), new Tree<string>("G")),
                   new Tree<string>("C"),
                   new Tree<string>("D",
                                 new Tree<string>("H")));


tree.AddChild("A", new Tree<string>("KOTUOSHU"));

Console.WriteLine(string.Join(",", tree.OrderBfs()));