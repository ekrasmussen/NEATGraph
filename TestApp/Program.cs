using NEATGraph;
using NEATGraph.Node;
using NEATGraph.Testing;

Graph graph = new Graph();

SimpleInput input = new SimpleInput();

input.Value = 1;

SimpleAction action = new SimpleAction();

graph.CreateInputNode(input);
graph.CreateOutputNode(action);
graph.CreateHiddenNode();
graph.CreateEdge("I0", "H0", 1);
graph.CreateEdge("H0", "O0", 1);

graph.MutateCreateNode();
graph.MutateCreateNode();
graph.MutateCreateNode();

//Console.WriteLine(graph.TotalEdges);

//graph.Update();
