using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public class TanHActivation : IActivationFunction
    {
        public string Name { get; } = "TanH";
        public float Calculate(float input)
        {
            float result = (MathF.Pow(MathF.E, input) - MathF.Pow(MathF.E, -input)) / (MathF.Pow(MathF.E, input) + MathF.Pow(MathF.E, -input));
            return result;
        }
    }
}
