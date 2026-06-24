
namespace CsharpLearning.Actions;

public class Slash : Attack
{
    public override string ActionName { get; init; } = "SLASH";

    public override string Description { get; init; } = "Attack with a sword";

    public override int Damage { get; set; } = 2;
    public override int Heal { get; set; } = 0;

    public override void Do(List<Party> parties, Character sourceCharacter, Player currentPlayer) 
    {
        Character targetCharacter = currentPlayer.PickFromEnemyParties(this, parties);

        OutputSystem.ActionUsedOn(sourceCharacter, targetCharacter, this);

        targetCharacter.CurrentHP -= Damage;

        OutputSystem.DamageDealt(sourceCharacter, targetCharacter, this);
    }
}
