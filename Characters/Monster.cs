using System.Text;

namespace CsharpLearning.Characters;

public abstract class Monster : Character
{
    
}

public class Skeleton : Monster
{
    public override string? CharacterName { get; set; }
    public override int MaxHP { get; init; } = 5;
    public Skeleton() 
    {
        CharacterName = "SKELETON";

        ActionList.Add(new BoneCrunch());
    }
}

public class TheUncodedOne : Monster
{
    public override string? CharacterName { get; set; }
    public override int MaxHP { get; init; } = 15;

    public TheUncodedOne()
    {
        CharacterName = "The Uncoded One";

        ActionList.Add(new Unraveling());
    }
}
