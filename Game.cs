namespace CsharpLearning;

public class Game
{
    public Party HeroesParty { get; init; }
    public Party MonstersParty1 { get; init; }
    public Party MonstersParty2 { get; init; }
    public Party MonstersParty3 { get; init; }

    public Player Player1 { get; init; }
    public Player Player2 { get; init; }

    public Battle Battle { get; init; }

    private GameMode gameMode { get; init; }

    public Game()
    {
        gameMode = PickGameMode();

        Player1 = gameMode switch
        {
            GameMode.HumanAI => new Human(),
            GameMode.AIAI => new AI(),
            GameMode.HumanHuman => new Human(),
            _ => new Human()
        };

        Player2 = gameMode switch
        {
            GameMode.HumanAI => new AI(),
            GameMode.AIAI => new AI(),
            GameMode.HumanHuman => new Human(),
            _ => new AI()
        };

        HeroesParty = new Party(new Character[] { new TrueProgrammer() }, Player1, "Heroes", false);
        MonstersParty1 = new Party(new Character[] { new Skeleton() }, Player2, "Monsters", true);
        MonstersParty2 = new Party(new Character[] { new Skeleton(), new Skeleton() }, Player2, "Monsters", true);
        MonstersParty3 = new Party(new Character[] { new TheUncodedOne() }, Player2, "The Uncoded One Party", true);

        HeroesParty.Inventory.AddItem(new HealthPotion(), 3);
        MonstersParty1.Inventory.AddItem(new HealthPotion(), 1);
        MonstersParty2.Inventory.AddItem(new HealthPotion(), 1);
        MonstersParty3.Inventory.AddItem(new HealthPotion(), 1);

        MonstersParty1.Inventory.AddGear(new Dagger());
        MonstersParty2.Inventory.AddGear(new Dagger(), new Dagger());
        MonstersParty3.Inventory.AddGear(new Dagger());

        Battle = new Battle();
    }

    public void Run()
    {
        Battle.StartBattle(HeroesParty, MonstersParty1, MonstersParty2, MonstersParty3);
    }

    private GameMode PickGameMode()
    {
        int answer = 0;
        OutputSystem.GameModeList();

        try
        {
            answer = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            answer = 0;
        }

        return answer switch
        {
            0 => GameMode.HumanAI,
            1 => GameMode.AIAI,
            2 => GameMode.HumanHuman,
            _ => GameMode.HumanAI
        };
    }

    private enum GameMode { HumanAI, AIAI, HumanHuman };  
}
