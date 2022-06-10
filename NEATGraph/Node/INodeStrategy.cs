using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    public interface INodeStrategy
    {
        public float Calculate(float input);
    }
}
