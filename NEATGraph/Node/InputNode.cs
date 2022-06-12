using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    public class InputNode : GraphNode
    {
        public INodeInput? InputAction { get; set; }
        public InputNode(string? name) : base(name)
        {

        }

        public override void AddEdge(Edge edge, EdgeType type = EdgeType.OUTPUT)
        {
            Output.Add(edge);
        }

        public override float Fire()
        {
            if(InputAction == null)
            {
                return 0;
            }
            return InputAction.ReadInput();
        }
    }
}
