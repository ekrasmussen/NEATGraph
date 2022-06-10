using NEATGraph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEATGraph.Testing
{
    public class SimpleAction : INodeAction
    {
        public void Fire(float input)
        {
            Console.WriteLine($"Output fired: {input}");
        }
    }
}
