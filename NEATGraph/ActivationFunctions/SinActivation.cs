using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public class SinActivation : IActivationFunction
    {
        public string Name { get; } = "Sin";
        public float Calculate(float input)
        {
            return MathF.Sin(input);
        }
    }
}
