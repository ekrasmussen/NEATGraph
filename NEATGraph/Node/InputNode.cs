using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    internal class InputNode : GraphNode
    {
        INodeInput? input;
        public InputNode(string? name) : base(name)
        {

        }

        public override void AddEdge(Edge edge, EdgeType type = EdgeType.OUTPUT)
        {
            Output.Add(edge);
        }

        public override float Fire()
        {
            if(input == null)
            {
                return 0;
            }

            return input.ReadInput();
        }
    }
}
