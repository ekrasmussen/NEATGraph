using NEATGraph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Testing
{
    public class SimpleInput : INodeInput
    {
        public int Value { get; set; }

        public float ReadInput()
        {
            return Value;
        }
    }
}
