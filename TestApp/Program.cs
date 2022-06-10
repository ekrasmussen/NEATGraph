using NEATGraph;
using NEATGraph.Testing;

Graph graph = new Graph();

SimpleInput input = new SimpleInput();

input.Value = 2;

graph.CreateInputNode(input);

input = new SimpleInput();
input.Value = 3;

graph.CreateInputNode(input);

input = new SimpleInput();
input.Value = 9;
graph.CreateInputNode(input);

Console.WriteLine(graph.Nodes.Count);

graph.CreateHiddenNode();
graph.CreateHiddenNode();

SimpleAction action = new SimpleAction();

graph.CreateOutputNode(action);
graph.CreateOutputNode(action);

graph.CreateEdge("I0", "H0", 1);
graph.CreateEdge("I1", "H0", 3);
graph.CreateEdge("I2", "H1", 2);

graph.CreateEdge("H0", "O0", 0.5f);
graph.CreateEdge("H1", "O0", 1);
graph.CreateEdge("H1", "O1", 3);
graph.CreateEdge("H0", "O1", 2);

graph.Update();