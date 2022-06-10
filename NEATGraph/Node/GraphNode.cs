using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    internal abstract class GraphNode
    {
        public List<Edge> Input { get; set; }
        public List<Edge> Output { get; set; }
        public GraphNode()
        {
            Input = new List<Edge>();
            Output = new List<Edge>();
        }

        //public virtual void AddEdge()
        //{
            
        //}

        public virtual float Fire()
        {
            float total = 0;
            
            foreach(var edge in Input)
            {
                total += edge.GetStrength();
            }
            
            //Do math operation

            return total;
        }
    }
}
