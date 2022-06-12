using NEATGraph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalSimulation.Actions
{
    public class LeftRightAction : INodeAction
    {
        public Player Player { get; set; }
        public LeftRightAction(Player player)
        {
            Player = player;
        }

        public void Fire(float input)
        {
            if(input == 0)
            {
                return;
            }
            else if(input < 0.5f)
            {
                Player.MoveLeft();
            }
            else if(input >= 0.5f)
            {
                Player.MoveRight();
            }
        }
    }
}
