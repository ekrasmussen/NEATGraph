using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public class LinearActivation : IActivationFunction
    {
        public string Name { get; } = "Lin";
        public float Calculate(float input)
        {
            return input;
        }
    }
}
