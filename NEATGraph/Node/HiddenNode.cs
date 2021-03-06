using NEATGraph.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    public class HiddenNode : GraphNode
    {
        public IActivationFunction ActivationFunction { get; set; } = new LinearActivation();
        public HiddenNode(string name) : base(name)
        {

        }

        public override float Fire()
        {
            float total = 0;
            foreach (var edge in Input)
            {
                if(edge.IsEnabled)
                {
                    total += edge.GetStrength();
                }
            }

            return ActivationFunction.Calculate(total);
        }
    }
}
