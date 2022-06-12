using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    public abstract class GraphNode
    {
        public string? Name { get; set; }
        public List<Edge> Input { get; set; }
        public List<Edge> Output { get; set; }
        public GraphNode(string? name)
        {
            Name = name;
            Input = new List<Edge>();
            Output = new List<Edge>();
        }

        public virtual void AddEdge(Edge edge, EdgeType type = EdgeType.INPUT)
        {
            if(type == EdgeType.INPUT)
            {
                Input.Add(edge);
            }
            else if(type == EdgeType.OUTPUT)
            {
                Output.Add(edge);
            }
        }

        public virtual float Fire()
        {
            float total = 0;

            foreach (var edge in Input)
            {
                total += edge.GetStrength();
            }

            //Do math operation

            return total;
        }
    }
}
