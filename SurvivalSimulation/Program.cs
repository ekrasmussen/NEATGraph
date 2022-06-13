using SurvivalSimulation;

Console.WriteLine("Hello world");

World world = new World(500, 500, 250, 500, 0, 500);

world.NumberOfPlayers = 500;
world.NumberOfSteps = 750;
world.NumberOfGenerations = 500;

world.Play();