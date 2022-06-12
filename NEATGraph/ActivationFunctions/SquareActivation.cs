using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public class SquareActivation : IActivationFunction
    {
        public string Name { get; } = "Square";
        public float Calculate(float input)
        {
            float result = MathF.Pow(input, 2);
            return result;
        }
    }
}
