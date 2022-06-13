using NEATGraph;
using NEATGraph.Node;
using NEATGraph.Testing;

Graph graph = new Graph();

SimpleInput input = new SimpleInput();

input.Value = 1;

SimpleAction action = new SimpleAction();

graph.CreateInputNode(input);
graph.CreateHiddenNode();
graph.CreateHiddenNode();
graph.CreateHiddenNode();
graph.CreateOutputNode(action);

graph.CreateEdge("I0", "H0", 1);
graph.CreateEdge("H0", "H1", 1);
graph.CreateEdge("H1", "O0", 1);
graph.CreateEdge("H1", "H2", 1);
graph.CreateEdge("H2", "H0", 1);

Console.WriteLine(graph.HiddenNodes[0]);
Console.WriteLine(graph.IsLoop(graph.HiddenNodes[0], graph.HiddenNodes[0], 0));
//graph.Update();
