using NEATGraph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Factories
{
    public class NodeFactory
    {
        int InputNodes { get; set; }
        int HiddenNodes { get; set; }
        int OutputNodes { get; set; }

        public GraphNode CreateInputNode(INodeInput inputAction)
        {
            InputNode node = new InputNode($"I{InputNodes}");
            node.InputAction = inputAction;
            InputNodes++;
            return node;
        }

        public GraphNode CreateOutputNode(INodeAction action)
        {
            OutputNode node = new OutputNode($"O{OutputNodes}");
            node.Action = action;
            OutputNodes++;
            return node;
        }

        public GraphNode CreateHiddenNode()
        {
            HiddenNode node = new HiddenNode($"H{HiddenNodes}");
            HiddenNodes++;
            return node;
        }
    }
}
