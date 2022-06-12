using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public class ReluctantActivation : IActivationFunction
    {
        public string Name { get; } = "Rel";
        public float Calculate(float input)
        {
            float result = 0;
            if(input > 0)
            {
                result = input;
            }
            return result;
        }
    }
}
