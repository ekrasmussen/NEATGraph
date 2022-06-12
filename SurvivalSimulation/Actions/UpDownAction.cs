using NEATGraph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalSimulation.Actions
{
    public class UpDownAction : INodeAction
    {
        public Player Player { get; set; }

        public UpDownAction(Player player)
        {
            Player = player;
        }

        public void Fire(float input)
        {
            if(input < 0.5f)
            {
                Player.MoveDown();
            }
            else
            {
                Player.MoveUp();
            }
        }
    }
}
