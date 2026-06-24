namespace CsharpLearning.Actions;

public class DoNothing : CharacterAction
{
    public override string ActionName { get; init; } = "DO NOTHING";

    public override string Description { get; init; } = "Skip turn";

    public override int Damage { get; set; } = 0;
    public override int Heal { get; set; } = 0;

    public override void Do(List<Party> parties, Character sourceCharacter, Player currentPlayer) { Console.WriteLine($"{sourceCharacter.CharacterName} did nothing");  }
}
