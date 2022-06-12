using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.ActivationFunctions
{
    public interface IActivationFunction
    {
        public string Name { get; }
        public float Calculate(float input);
    }
}
