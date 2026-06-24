namespace CsharpLearning.Inventory.Items;

public abstract class Item
{
    public abstract string ItemName { get; init; }
    public abstract string Description { get; init; }

    public abstract int Damage { get; set; }
    public abstract int Heal { get; set; }

    public virtual void Use(Party sourceParty, Character sourceCharacter, Player currentPlayer, int numberInList, CharacterAction action) { }

}
