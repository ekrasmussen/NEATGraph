using NEATGraph.Factories;
using NEATGraph.Node;

namespace NEATGraph
{
    public class Graph
    {
        public List<GraphNode> Nodes { get
            {
                List<GraphNode> result = new List<GraphNode>();
                result.AddRange(HiddenNodes);
                result.AddRange(InputNodes);
                result.AddRange(OutputNodes);

                return result;
            }
        }
        public List<HiddenNode> HiddenNodes { get; set; }
        public List<InputNode> InputNodes { get; set; }
        public List<OutputNode> OutputNodes { get; set; }
        public List<Edge> Edges { get
            {
                List<Edge> edges = new List<Edge>();
                foreach(var node in Nodes)
                {
                    for(int i = 0; i < node.Input.Count; i++)
                    {
                        edges.Add(node.Input[i]);
                    }
                }

                return edges;
            } 
        }
        public int TotalEdges { get
            {
                int total = 0;
                foreach (var node in Nodes)
                {
                    total += node.Input.Count;
                }
                return total;
            } 
        }
        private NodeFactory Factory { get; set; }
        private ActivationFunctionFactory ActivationFunctionFactory { get; set; }
        public Graph()
        {
            Factory = new NodeFactory();
            HiddenNodes = new List<HiddenNode>();
            OutputNodes = new List<OutputNode>();
            InputNodes = new List<InputNode>();
            ActivationFunctionFactory = new ActivationFunctionFactory();
        }

        public void CreateInputNode(INodeInput inputAction) => InputNodes.Add((InputNode)Factory.CreateInputNode(inputAction));
        public void CreateHiddenNode() => HiddenNodes.Add((HiddenNode)Factory.CreateHiddenNode());
        public void CreateOutputNode(INodeAction action) => OutputNodes.Add((OutputNode)Factory.CreateOutputNode(action));

        public void CreateEdge(string inputname, string outputname, float weight)
        {
            Edge edge = new Edge();
            edge.Previous = Nodes.Find(n => n.Name == inputname);
            edge.Next = Nodes.Find(n => n.Name == outputname);
            edge.Weight = weight;
            if(VerifyEdge(edge.Previous!, edge.Next!))
            {
                edge.Previous!.AddEdge(edge, EdgeType.OUTPUT);
                edge.Next!.AddEdge(edge, EdgeType.INPUT);
            }
        }

        public void CreateEdge(GraphNode inputNode, GraphNode outputNode, float weight)
        {
            Edge edge = new Edge(inputNode, outputNode, weight);
            if (VerifyEdge(edge.Previous!, edge.Next!))
            {
                edge.Previous!.AddEdge(edge, EdgeType.OUTPUT);
                edge.Next!.AddEdge(edge, EdgeType.INPUT);
            }
        }

        private bool VerifyEdge(GraphNode input, GraphNode output)
        {
            foreach(Edge edge in input.Output)
            {
                if(edge.Next == output)
                {
                    return false;
                }
            }

            return true;
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

        public void Mutate()
        {
            throw new NotImplementedException();
        }

        public void MutateCreateNode()
        {
            Random rnd = new Random();
            HiddenNode node = (HiddenNode)Factory.CreateHiddenNode();
            node.ActivationFunction = ActivationFunctionFactory.CreateRandom();
            GraphNode connectionNode = GetRandomNode(false, true);
            float weight = (float)(rnd.NextDouble() * (5 - -5) + -5);

            Console.WriteLine($"Node created, edge between {node.Name} and {connectionNode.Name}. Weight : {weight}");
            CreateEdge(node, connectionNode, weight);
        }

        private void MutateActivationFunction()
        {
            throw new NotImplementedException();
        }

        private void MutateEdgeWeight()
        {
            throw new NotImplementedException();
        }

        private GraphNode GetRandomNode(bool includeOutput, bool includeInput)
        {
            List<GraphNode> nodes = new List<GraphNode>();
            nodes.AddRange(HiddenNodes);
            if(includeOutput)
            {
                nodes.AddRange(OutputNodes);
            }
            if(includeInput)
            {
                nodes.AddRange(InputNodes);
            }

            Random rnd = new Random();
            int result = rnd.Next(nodes.Count);

            return nodes[result];
        }
    }
}