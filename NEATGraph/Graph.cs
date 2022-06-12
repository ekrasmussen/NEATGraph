using NEATGraph.Factories;
using NEATGraph.Node;

namespace NEATGraph
{
    public class Graph
    {
        public List<GraphNode> Nodes { get; set; }
        private NodeFactory Factory { get; set; }
        public Graph()
        {
            Nodes = new List<GraphNode>();
            Factory = new NodeFactory();
        }

        public void CreateInputNode(INodeInput inputAction) => Nodes.Add(Factory.CreateInputNode(inputAction));
        public void CreateHiddenNode() => Nodes.Add(Factory.CreateHiddenNode());
        public void CreateOutputNode(INodeAction action) => Nodes.Add(Factory.CreateOutputNode(action));

        public void CreateEdge(string inputname, string outputname, float weight)
        {
            Edge edge = new Edge();
            edge.Previous = Nodes.Find(n => n.Name == inputname);
            edge.Next = Nodes.Find(n => n.Name == outputname);
            edge.Weight = weight;

            edge.Previous!.AddEdge(edge, EdgeType.OUTPUT);
            edge.Next!.AddEdge(edge, EdgeType.INPUT);
        }

        public void CreateEdge(GraphNode inputNode, GraphNode outputNode, float weight)
        {
            Edge edge = new Edge(inputNode, outputNode, weight);
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