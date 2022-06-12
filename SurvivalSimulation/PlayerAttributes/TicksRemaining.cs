﻿using NEATGraph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalSimulation.PlayerAttributes
{
    public class TicksRemaining : INodeInput
    {
        public Player Player { get; set; }

        public TicksRemaining(Player player)
        {
            Player = player;
        }
        public float ReadInput()
        {
            return Player.TicksLeft;
        }
    }
}
