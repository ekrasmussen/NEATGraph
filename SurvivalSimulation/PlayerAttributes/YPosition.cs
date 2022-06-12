using NEATGraph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalSimulation.PlayerAttributes
{
    public class YPosition : INodeInput
    {
        public Player Player { get; set; }
        public YPosition(Player player)
        {
            Player = player;
        }

        public float ReadInput()
        {
            return Player.Ypos;
        }
    }
}
