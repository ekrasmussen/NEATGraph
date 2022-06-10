using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    internal class OutputNode : GraphNode
    {
        public INodeAction? Action { get; set; }

        public OutputNode(string name) : base(name)
        {

        }

        public override void AddEdge(Edge edge, EdgeType type = EdgeType.INPUT)
        {
            Input.Add(edge);
        }

        public override float Fire()
        {
            float result = base.Fire();
            if(Action != null)
            {
                Action.Fire(result);
            }
            return result;
        }
    }
}
