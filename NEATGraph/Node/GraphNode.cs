using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    internal abstract class GraphNode
    {
        public GraphNode()
        {

        }

        public virtual void AddEdge()
        {
            throw new NotImplementedException();
        }
    }
}
