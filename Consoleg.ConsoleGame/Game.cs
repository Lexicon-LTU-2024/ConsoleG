


internal class Game
{
    private Map map = null!;
    private Player player = null!;

    public Game()
    {
    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;

        do
        {
            //Drawmap

            //Getcommand

            //Act

            //Drawmap

            //EnemyAction

            //Drawmap

        } while (gameInProgress);

    }

    private void Initialize()
    {
        //ToDo: Read from config
        map = new Map(width: 10, height: 10);
        player = new Player();
    }
}