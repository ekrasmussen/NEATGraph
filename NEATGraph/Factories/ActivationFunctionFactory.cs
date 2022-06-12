using NEATGraph.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Factories
{
    public class ActivationFunctionFactory
    {
        public ActivationFunctionFactory()
        {

        }

        public IActivationFunction CreateRandom()
        {
            List<IActivationFunction> activationFunctions = GetList();
            Random rnd = new Random();
            int result = rnd.Next(activationFunctions.Count);
            IActivationFunction activationFunction = activationFunctions[result];
            return activationFunction;

        }

        private List<IActivationFunction> GetList()
        {
            List<IActivationFunction> activationFunctions = new List<IActivationFunction>();
            activationFunctions.Add(new AbsActivation());
            activationFunctions.Add(new GaussianActivation());
            activationFunctions.Add(new LinearActivation());
            activationFunctions.Add(new ReluctantActivation());
            activationFunctions.Add(new SigmoidActivation());
            activationFunctions.Add(new SinActivation());
            activationFunctions.Add(new SquareActivation());
            activationFunctions.Add(new TanHActivation());
            return activationFunctions;
        }
    }
}
