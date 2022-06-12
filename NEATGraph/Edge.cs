using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEATGraph.Node;

namespace NEATGraph
{
    public class Edge
    {
        public GraphNode? Next { get; set; }
        public GraphNode? Previous { get; set; }
        public bool IsEnabled { get; set; } = true;

        public float Weight { get; set; }

        public Edge()
        {
            
        }

        public Edge(float weight)
        {
            Weight = weight;
        }

        public Edge(GraphNode inputNode, GraphNode outputNode, float weight)
        {
            Weight = weight;
            Previous = inputNode;
            Next = outputNode;
        }

        public float GetStrength()
        {
            if(Previous == null)
            {
                return 0;
            }

            return Previous.Fire() * Weight;
        }
    }
}
