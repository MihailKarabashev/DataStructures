
using Tree;

var input = new string[] { "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6"};

var treeFactory = new IntegerTreeFactory();

var tree = treeFactory.CreateTreeFromStrings(input);

var list = tree.GetDeepestKey();

;

