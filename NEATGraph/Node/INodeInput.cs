using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    public interface INodeInput
    {
        //Should give a float between 0 and 1, remember to normalize input
        public float ReadInput();
    }
}
