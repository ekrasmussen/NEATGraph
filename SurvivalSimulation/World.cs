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

        public int CurrentGeneration { get; set; }

        public int TicksLeft { get; set; }
        public int WorldXSize { get; set; }
        public int WorldYSize { get; set; }

        public int SurviveBoxXMin { get; set; }
        public int SurviveBoxXMax { get; set; }
        public int SurviveBoxYMin { get; set; }
        public int SurviveBoxYMax { get; set; }

        public List<Player> Players { get; set; }

        public World(int xsize, int ysize, int sxmin, int sxmax, int symin, int symax)
        {
            Players = new List<Player>();
            WorldXSize = xsize;
            WorldYSize = ysize;
            SurviveBoxXMax = sxmax;
            SurviveBoxYMax = symax;
            SurviveBoxXMin = sxmin;
            SurviveBoxYMin = symin;
        }

        public void SpawnPlayers()
        {
            for(int i = 0; i < NumberOfPlayers; i++)
            {
                Players.Add(new Player(this));
            }

            SetPlayerPositions();
        }

        private void SetPlayerPositions()
        {
            Random rnd = new Random();
            List<Player> positionedPlayers = new List<Player>();
            foreach(Player player in Players)
            {
                bool isBlocked = true;
                while(isBlocked)
                {
                    int x = rnd.Next(WorldXSize);
                    int y = rnd.Next(WorldYSize);

                    if(positionedPlayers.Count == 0)
                    {
                        isBlocked = false;
                    }

                    foreach (Player positionedPlayer in positionedPlayers)
                    {
                        if (positionedPlayer.TrueXpos == x && positionedPlayer.TrueYpos == y)
                        {
                            isBlocked = true;
                        }
                        else
                        {
                            isBlocked = false;
                        }
                    }

                    if(!isBlocked)
                    {
                        player.setPosition(x, y);
                        positionedPlayers.Add(player);
                    }
                }
            }
        }

        public void Play()
        {
            SpawnPlayers();
            CurrentGeneration = 0;
            TicksLeft = NumberOfSteps;
            for(int i = 0; i < NumberOfGenerations; i++)
            {
                MakeMoves();
                CurrentGeneration++;
                TicksLeft = NumberOfSteps;
            }
        }

        public void MakeMoves()
        {
            
            while (TicksLeft > 0)
            {
                foreach (Player player in Players)
                {
                    player.Step();
                }
                TicksLeft--;
                Console.WriteLine($"Generation {CurrentGeneration} - Step {NumberOfSteps - TicksLeft}");
            }

            KillUnfit();

            Console.WriteLine($"Generation ended: \n    {Players.Count} survived.\n    {NumberOfPlayers - Players.Count} died\n    Survival procent: {Players.Count / NumberOfPlayers * 100}%");
            Thread.Sleep(3000);
            Reproduce();
            EndGeneration();
            SetPlayerPositions();
        }

        private void EndGeneration()
        {
            foreach(Player player in Players)
            {
                player.EndGeneration();
            }
        }

        private void KillUnfit()
        {
            //Set conditions for killing the unfit
            for(int i= 0; i < Players.Count; i++)
            {
                if (Players[i].TrueXpos > SurviveBoxXMax || Players[i].TrueXpos < SurviveBoxXMin)
                {
                    Players.RemoveAt(i);
                    i--;
                }
            }
        }

        private void Reproduce()
        {
            int toReproduce = NumberOfPlayers - Players.Count;
            List<Player> newPlayers = new List<Player>();
            Random rnd = new Random();

            for(int i = 0; i < toReproduce; i++)
            {
                int result = rnd.Next(Players.Count);
                Player player = Players[result];
                newPlayers.Add(new Player(this, player.BrainMutationChance, player.AttributeMutationChance, player.Brain));
            }

            Players.AddRange(newPlayers);
        }
    }
}
