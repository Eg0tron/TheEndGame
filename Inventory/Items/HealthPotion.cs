namespace CsharpLearning.Inventory.Items;

public class HealthPotion : Item
{
    public override string ItemName { get; init; } = "HEALTH POTION";
    public override string Description { get; init; } = "Heal a character on 10 HP";
    public override int Damage { get; set; } = 0;
    public override int Heal { get; set; } = 10;

    public override void Use(Party sourceParty, Character sourceCharacter, Player currentPlayer, int numberInList, CharacterAction action) 
    {
        Character targetCharacter = currentPlayer.PickFromAllyParty(action, sourceParty);

        OutputSystem.ItemUsedOn(sourceCharacter, targetCharacter, this);

        if ((targetCharacter.CurrentHP += Heal) > targetCharacter.MaxHP) targetCharacter.CurrentHP = targetCharacter.MaxHP;

        OutputSystem.HPHealt(sourceCharacter, targetCharacter, this);

        sourceParty.Inventory.DecreaseAmount(numberInList);
        sourceParty.Inventory.CheckItemAmount(numberInList);
    }
}
