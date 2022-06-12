using NEATGraph;
using NEATGraph.Node;
using SurvivalSimulation.PlayerAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalSimulation
{
    public class Player
    {
        public World World { get; set; }
        public float BrainMutationChance { get; set; }
        public float AttributeMutationChance { get; set; }

        public int TrueXpos { get; set; }
        public int TrueYpos { get; set; }
        public int TrueTicksLeft { get; set; }

        public float Xpos { get; set; }
        public float Ypos { get; set; }
        public float TicksLeft { get; set; }

        public Graph Brain { get; set; }

        public Player(World world)
        {
            World = world;
            Random random = new Random();
            BrainMutationChance = (float)random.NextDouble();
            AttributeMutationChance = (float)random.NextDouble();
            Brain = new Graph();
        }

        public Player(World world, float brainChance, float attributeChance, Graph graph)
        {
            World = world;
            BrainMutationChance = brainChance;
            AttributeMutationChance = attributeChance;
            Brain = graph;

            List<InputNode> inputNodes = graph.InputNodes;
            inputNodes[0].InputAction = new Xposition(this);
            inputNodes[1].InputAction = new YPosition(this);
            inputNodes[2].InputAction = new TicksRemaining(this);

        }

        public void EndGeneration()
        {
            Random rnd = new Random();
            if((float)rnd.NextDouble() < BrainMutationChance)
            {
                Brain.Mutate();
            }
            if((float)rnd.NextDouble() < AttributeMutationChance)
            {
                MutateAttribute();
            }
        }
        private void MutateAttribute()
        {

        }
        public void Step()
        {
            Xpos = TrueXpos / World.WorldXSize;
            Ypos = TrueYpos / World.WorldYSize;
            TicksLeft = TrueTicksLeft / World.TicksLeft;


        }
    }
}
