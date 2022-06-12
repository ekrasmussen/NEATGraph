using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public class GaussianActivation : IActivationFunction
    {
        public string Name { get; } = "Gaussian";
        public float Calculate(float input)
        {
            float result = MathF.Pow(MathF.E, MathF.Pow(-input, 2));
            return result;
        }
    }
}
