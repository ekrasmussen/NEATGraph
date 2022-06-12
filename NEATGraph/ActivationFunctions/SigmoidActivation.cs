using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public class SigmoidActivation : IActivationFunction
    {
        public string Name { get; } = "Sig";
        public float Calculate(float input)
        {
            float result = 1 / (1 + MathF.Pow(MathF.E, -input));
            return result;
        }
    }
}
