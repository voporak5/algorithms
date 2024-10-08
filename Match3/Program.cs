namespace Match3
{
    class Match3
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();

            for (int i = 0; i < args.Length; i++)
            {
                grid.ParseCommand(args[i]);
            }

            grid.Build();

            GameManager game = new GameManager(grid);
            game.Run();

            Console.ReadKey();
        }
    }
}