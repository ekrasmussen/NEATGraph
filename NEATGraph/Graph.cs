using NEATGraph.Node;

namespace NEATGraph
{
    public class Graph
    {
        int InputNodes { get; set; }
        int HiddenNodes { get; set; }
        int OutputNodes { get; set; }
        public List<GraphNode> Nodes { get; set; }
        public Graph()
        {
            Nodes = new List<GraphNode>();
        }

        public void CreateInputNode(INodeInput inputAction)
        {
            InputNode node = new InputNode($"I{InputNodes}");
            node.InputAction = inputAction;
            Nodes.Add(node);
            InputNodes++;
        }

        public void CreateOutputNode(INodeAction action)
        {
            OutputNode node = new OutputNode($"O{OutputNodes}");
            node.Action = action;
            Nodes.Add(node);
            OutputNodes++;
        }

        public void CreateHiddenNode()
        {
            HiddenNode node = new HiddenNode($"H{HiddenNodes}");
            Nodes.Add(node);
            HiddenNodes++;
        }

        public void CreateEdge(string inputname, string outputname, float weight)
        {
            Edge edge = new Edge();
            edge.Previous = Nodes.Find(n => n.Name == inputname);
            edge.Next = Nodes.Find(n => n.Name == outputname);
            edge.Weight = weight;

            edge.Previous!.AddEdge(edge, EdgeType.OUTPUT);
            edge.Next!.AddEdge(edge, EdgeType.INPUT);
        }

        public void Update()
        {
            foreach(var node in Nodes)
            {
                if(node.GetType() == typeof(OutputNode))
                {
                    node.Fire();
                }
            }
        }
    }
}