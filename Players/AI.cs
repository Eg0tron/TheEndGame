namespace CsharpLearning.Players;

public class AI : Player
{
    public override string Name { get; init; } = "Computer";

    public Random random = new Random();


    public override void PickActionAndDo(List<Party> parties, Character sourceCharacter, Player currentPlayer)
    {
        CharacterAction actionToDo = sourceCharacter.ActionList[RandomPick(sourceCharacter.ActionList.Count)];

        Party? sourceParty = null;

        foreach (Party party in parties)
        {
            foreach (Character character in party._charactersParty)
            {
                if (character == sourceCharacter) sourceParty = party;
            }
        }

        if (RandomPick(4) == 3 && (double)sourceCharacter.CurrentHP < (double)sourceCharacter.MaxHP / (double)2)
        {
            while (actionToDo is not UseItem) actionToDo = sourceCharacter.ActionList[RandomPick(sourceCharacter.ActionList.Count)];

            actionToDo.Do(parties, sourceCharacter, currentPlayer);
            return;
        }
        else  while (actionToDo is UseItem)  actionToDo = sourceCharacter.ActionList[RandomPick(sourceCharacter.ActionList.Count)];

        if (sourceCharacter.EquipedGear is null && sourceParty.Inventory.Gears.Count > 0 && RandomPick(2) == 1)
        {
            while (actionToDo is not Equip) actionToDo = sourceCharacter.ActionList[RandomPick(sourceCharacter.ActionList.Count)];

            actionToDo.Do(parties, sourceCharacter, currentPlayer);

            return;
        }

        if (sourceCharacter.EquipedGear is not null && actionToDo != sourceCharacter.EquipedGear.Action && actionToDo is Attack)
        { 
            while (actionToDo != sourceCharacter.EquipedGear.Action) actionToDo = sourceCharacter.ActionList[RandomPick(sourceCharacter.ActionList.Count)];

            actionToDo.Do(parties, sourceCharacter, currentPlayer);
            return;
        }

        actionToDo.Do(parties, sourceCharacter, currentPlayer);
    }

    public override Character PickFromEnemyParties(CharacterAction action, params List<Party> parties)
    {
        List<Party> enemies = new List<Party>();

        foreach (Party party in parties)
        {
            if (!party.BelongsTo.IsPlayerTurn)
            {
                enemies.Add(party);
            }
        }

        return PickTarget(action, enemies[RandomPick(enemies.Count)]);
    }

    public override Character PickFromAllParties(CharacterAction action, params List<Party> parties)
    {
        List<Party> allParties = new List<Party>();

        foreach (Party party in parties) allParties.Add(party);

        return PickTarget(action, allParties[RandomPick(allParties.Count)]);
    }

    public override (Item, int) PickItem(Party party, Character character)
    {
        int pick = RandomPick(party.Inventory.Items.Count);

        return (party.Inventory.Items[pick].item, pick);
    }

    public override Gear PickGear(Party party, Character character) => party.Inventory.Gears[RandomPick(party.Inventory.Gears.Count)];

    public override Character PickTarget(CharacterAction action, Party party) => party._charactersParty[RandomPick(party._charactersParty.Count)];


    public int RandomPick(int maxNumber) => random.Next(0, maxNumber);
}
