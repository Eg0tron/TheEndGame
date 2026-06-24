namespace CsharpLearning.Actions;

public class UseItem : CharacterAction
{
    public override string ActionName { get; init; } = "USE ITEM";

    public override string Description { get; init; } = "Use an item on a character.";

    public override int Damage { get; set; } = 0;
    public override int Heal { get; set; } = 0;


    public override void Do(List<Party> parties, Character sourceCharacter, Player currentPlayer)
    { 
        Party? sourceParty = null;
        (Item item, int numberInList) itemToUse;

        foreach (Party party in parties)
        {
            foreach (Character character in party._charactersParty)
            {
                if (character == sourceCharacter) sourceParty = party;
            }
        }

        if (sourceParty.Inventory.Items.Count <= 0)
        {
            currentPlayer.PickActionAndDo(parties, sourceCharacter, currentPlayer);
            return;
        }

        itemToUse = currentPlayer.PickItem(sourceParty, sourceCharacter);


        itemToUse.item.Use(sourceParty, sourceCharacter, currentPlayer, itemToUse.numberInList, this);
    }
}

