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
            Random rnd = new Random();
            int result = rnd.Next(0, 4);

            switch(result)
            {
                case 0:
                    MutateCreateNode();
                    break;
                case 1:
                    MutateActivationFunction();
                    break;
                case 2:
                    MutateEdgeWeight();
                    break;

                case 3:
                    MutateEdgeToHiddenNode();
                    break;

                    default:
                    break;
            }
        }

        private void MutateCreateNode()
        {
            Random rnd = new Random();
            HiddenNode node = (HiddenNode)Factory.CreateHiddenNode();
            node.ActivationFunction = ActivationFunctionFactory.CreateRandom();
            GraphNode connectionNode = GetRandomNode(false, true);
            float weight = (float)(rnd.NextDouble() * (5 - -5) + -5);
            HiddenNodes.Add(node);
            Console.WriteLine($"Node created, edge between {node.Name} and {connectionNode.Name}. Weight : {weight}");
            CreateEdge(node, connectionNode, weight);
        }

        private void MutateActivationFunction()
        {
            HiddenNode node = (HiddenNode)GetRandomNode(false, false);
            node.ActivationFunction = ActivationFunctionFactory.CreateRandom();
            Console.WriteLine($"Mutated {node.Name} to be the {node.ActivationFunction.Name} Activation Function");
        }

        private void MutateEdgeWeight()
        {
            Random rnd = new Random();
            int result = rnd.Next(Edges.Count);

            Edge edge = Edges[result];
            edge.Weight = (float)(rnd.NextDouble() * (5 - -5) + -5);
            Console.WriteLine($"Mutated Edge between {edge.Previous.Name} to {edge.Next.Name} with weight {edge.Weight}");
        }

        private void MutateEdgeToHiddenNode()
        {
            Random rnd = new Random(Edges.Count);
            int result = rnd.Next(Edges.Count);

            Edge unbrokenEdge = Edges[result];
            Edges.RemoveAt(result);
            HiddenNode node = (HiddenNode)Factory.CreateHiddenNode();
            node.ActivationFunction = ActivationFunctionFactory.CreateRandom();
            Edge edge1 = new Edge();
            Edge edge2 = new Edge();

            edge1.Previous = unbrokenEdge.Previous;
            edge1.Next = node;
            edge1.Weight = unbrokenEdge.Weight;

            edge2.Previous = node;
            edge2.Next = unbrokenEdge.Next;
            edge2.Weight = 1f;

            //add the edges to the nodes
            unbrokenEdge.Previous!.AddEdge(edge1, EdgeType.OUTPUT);
            unbrokenEdge.Previous.Output.Remove(unbrokenEdge);

            unbrokenEdge.Next!.AddEdge(edge2, EdgeType.INPUT);
            unbrokenEdge.Next.Input.Remove(unbrokenEdge);


            node.AddEdge(edge1, EdgeType.INPUT);
            node.AddEdge(edge2, EdgeType.OUTPUT);

            HiddenNodes.Add(node);

            Console.WriteLine($"Removed edge between {unbrokenEdge.Previous.Name} and {unbrokenEdge.Next.Name}, and added new hidden node");
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