using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    public class HiddenNode : GraphNode
    {
        public IActivationFunction ActivationFunction { get; set; }
        public HiddenNode(string name) : base(name)
        {

        }

        public override float Fire()
        {
            float total = 0;
            foreach (var edge in Input)
            {
                total += edge.GetStrength();
            }

            
            return total;
        }
    }
}
