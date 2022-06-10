using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    public class HiddenNode : GraphNode
    {
        public INodeStrategy? equation { get; set; }

        public HiddenNode(string name) : base(name)
        {

        }
    }
}
