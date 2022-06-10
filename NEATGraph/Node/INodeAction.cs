using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Node
{
    public interface INodeAction
    {
        public void Fire(float input);
    }
}
