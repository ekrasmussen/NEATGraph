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
graph.Mutate();
graph.Mutate();
graph.Mutate();
graph.Mutate();
graph.Mutate();
graph.Mutate();
graph.Mutate();

//graph.Update();
