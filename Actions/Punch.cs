namespace CsharpLearning.Actions;

public class Punch : Attack
{
    public override string ActionName { get; init; } = "PUNCH";
    public override string Description { get; init; } = "Punch an enemy character";
    public override int Damage { get; set; } = 1;
    public override int Heal { get; set; } = 0;

    public override void Do(List<Party> parties, Character sourceCharacter, Player currentPlayer)
    {
        Character targetCharacter = currentPlayer.PickFromEnemyParties(this, parties);

        OutputSystem.ActionUsedOn(sourceCharacter, targetCharacter, this);

        targetCharacter.CurrentHP -= Damage;

        OutputSystem.DamageDealt(sourceCharacter, targetCharacter, this);
    }
}


