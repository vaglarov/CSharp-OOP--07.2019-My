namespace FootballTeamGenerator
{
    using System;
    using FootballTeamGenerator.Core;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
