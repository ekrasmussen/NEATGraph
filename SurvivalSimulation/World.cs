using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalSimulation
{
    public class World
    {
        public int NumberOfPlayers { get; set; }
        public int NumberOfSteps { get; set; }
        public int NumberOfGenerations { get; set; }

        public int TicksLeft { get; set; }
        public int WorldXSize { get; set; }
        public int WorldYSize { get; set; }

        public List<Player> Players { get; set; }

        public World()
        {

        }

        public void SpawnPlayers()
        {
            for(int i = 0; i < NumberOfPlayers; i++)
            {
                Players.Add(new Player(this));
            }
        }

        public void Play()
        {
            for(int i = 0; i < NumberOfGenerations; i++)
            {
                for(int j = 0; j < NumberOfSteps; j++)
                {
                    MakeMoves();
                }
            }
        }

        public void MakeMoves()
        {
            foreach(Player player in Players)
            {
                //Make move
            }
        }
    }
}
