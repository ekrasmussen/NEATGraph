﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEATGraph.Node;

namespace NEATGraph
{
    internal class Edge
    {
        GraphNode Next { get; set; }
        GraphNode Previous { get; set; }

        public Edge()
        {
            
        }

        public float GetStrength()
        {
            return Previous.Fire();
        }
    }
}
