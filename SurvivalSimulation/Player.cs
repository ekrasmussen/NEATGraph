using NEATGraph;
using NEATGraph.Node;
using SurvivalSimulation.Actions;
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

        //Attributes
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
            Brain.CreateInputNode(new Xposition(this));
            Brain.CreateInputNode(new YPosition(this));
            Brain.CreateInputNode(new TicksRemaining(this));

            Brain.CreateOutputNode(new UpDownAction(this));
            Brain.CreateOutputNode(new LeftRightAction(this));
        }

        public Player(World world, float brainChance, float attributeChance, Graph graph)
        {
            World = world;
            BrainMutationChance = brainChance;
            AttributeMutationChance = attributeChance;
            Brain = graph;

            List<InputNode> inputNodes = Brain.InputNodes;
            inputNodes[0].InputAction = new Xposition(this);
            inputNodes[1].InputAction = new YPosition(this);
            inputNodes[2].InputAction = new TicksRemaining(this);

            List<OutputNode> outputNodes = Brain.OutputNodes;
            outputNodes[0].Action = new UpDownAction(this);
            outputNodes[1].Action = new LeftRightAction(this);

        }

        public void setPosition(int x, int y)
        {
            TrueXpos = x;
            TrueYpos = y;
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
            Random rnd = new Random();

            int result = rnd.Next(0, 2);

            switch(result)
            {
                case 0:
                    BrainMutationChance = (float)rnd.NextDouble();
                    break;
                case 1:
                    AttributeMutationChance = (float)rnd.NextDouble();
                    break;
                default:
                    break;
            }
        }
        public void Step()
        {
            Xpos = TrueXpos / World.WorldXSize;
            Ypos = TrueYpos / World.WorldYSize;
            TicksLeft = TrueTicksLeft / World.TicksLeft;

            Brain.Update();
        }

        public void MoveLeft()
        {
            bool isBlocked = false;

            if (TrueXpos - 1 < 0)
            {
                isBlocked = true;
            }
            else
            {
                for (int i = 0; i < World.Players.Count; i++)
                {
                    if (World.Players[i].TrueXpos == TrueXpos - 1 && World.Players[i].TrueYpos == TrueYpos)
                    {
                        isBlocked = true;
                    }
                }
            }

            if (!isBlocked)
            {
                TrueXpos--;
            }

        }

        public void MoveRight()
        {
            bool isBlocked = false;

            if (TrueXpos + 1 > World.WorldXSize)
            {
                isBlocked = true;
            }
            else
            {
                for (int i = 0; i < World.Players.Count; i++)
                {
                    if (World.Players[i].TrueXpos == TrueXpos + 1 && World.Players[i].TrueYpos == TrueYpos)
                    {
                        isBlocked = true;
                    }
                }
            }

            if (!isBlocked)
            {
                TrueXpos++;
            }
        }

        public void MoveUp()
        {
            bool isBlocked = false;

            if (TrueYpos + 1 > World.WorldYSize)
            {
                isBlocked = true;
            }
            else
            {
                for (int i = 0; i < World.Players.Count; i++)
                {
                    if (World.Players[i].TrueXpos == TrueXpos && World.Players[i].TrueYpos == TrueYpos + 1)
                    {
                        isBlocked = true;
                    }
                }
            }

            if (!isBlocked)
            {
                TrueXpos++;
            }
        }
        public void MoveDown()
        {
            bool isBlocked = false;

            if (TrueYpos - 1 < 0)
            {
                isBlocked = true;
            }
            else
            {
                for (int i = 0; i < World.Players.Count; i++)
                {
                    if (World.Players[i].TrueXpos == TrueXpos && World.Players[i].TrueYpos == TrueYpos - 1)
                    {
                        isBlocked = true;
                    }
                }
            }

            if (!isBlocked)
            {
                TrueXpos--;
            }
        }
    }
}
