namespace CsharpLearning.Actions;

public abstract class CharacterAction
{
    public abstract string ActionName { get; init; }
    public abstract string Description { get; init; }

    public abstract int Damage { get; set; }
    public abstract int Heal { get; set; }

    public virtual void Do(List<Party> parties, Character sourceCharacter, Player player) { }
}

public abstract class Attack : CharacterAction
{

}