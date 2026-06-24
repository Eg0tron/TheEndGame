namespace CsharpLearning.Actions;

public class Unraveling : Attack
{
    public override string ActionName { get; init; } = "UNRAVELING";
    public override string Description { get; init; } = "Attack an enemy character";

    public override int Damage { get; set; }
    public override int Heal { get; set; } = 0;

    public override void Do(List<Party> parties, Character sourceCharacter, Player currentPlayer)
    {
        Random random = new Random();
        Damage = random.Next(3);
        Character targetCharacter = currentPlayer.PickFromEnemyParties(this, parties);

        OutputSystem.ActionUsedOn(sourceCharacter, targetCharacter, this);

        targetCharacter.CurrentHP -= Damage;

        OutputSystem.DamageDealt(sourceCharacter, targetCharacter, this);
    }
}