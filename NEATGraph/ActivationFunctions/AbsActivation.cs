using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public class AbsActivation : IActivationFunction
    {
        public string Name { get; } = "Abs";

        public float Calculate(float input)
        {
            return MathF.Abs(input);
        }
    }
}
