namespace CsharpLearning.Players;

public abstract class Player
{
    public bool IsPlayerTurn { get; set; } = false;

    public abstract string Name { get; init; }

    public virtual void PickActionAndDo(List<Party> parties, Character character, Player currentPlayer)
    {
        OutputSystem.GetCharacterActionList(character);
        character.ActionList[PickNumber()].Do(parties, character, currentPlayer);
    }

    public Character PickFromAllyParty(CharacterAction action, params Party[] parties)
    {
        Party? allyParty = null; // The "allyParty" can't be null in the end of the method because this method calls when it's a player's turn. Eventually we get a party that needed.

        foreach (Party party in parties)
        {
            if (party.BelongsTo.IsPlayerTurn)
            {
                allyParty = party;
            }
        }

        return PickTarget(action, allyParty);
    }

    public virtual Character PickFromEnemyParties(CharacterAction action, params List<Party> parties)
    {
        List<Party> enemies = new List<Party>();

        foreach (Party party in parties)
        {
            if (!party.BelongsTo.IsPlayerTurn)
            {
                enemies.Add(party);
            }
        }

        OutputSystem.GetEnemyPartiesList(action, enemies);

        return PickTarget(action, enemies[PickNumber()]);
    }

    public virtual Character PickFromAllParties(CharacterAction action, params List<Party> parties)
    {
        List<Party> allParties = new List<Party>();

        foreach (Party party in parties) allParties.Add(party);

        OutputSystem.GetAllPartiesList(action, allParties);

        return PickTarget(action, allParties[PickNumber()]);
    }

    public virtual Character PickTarget(CharacterAction action, Party party)
    { 
        OutputSystem.GetPartyList(action, party);

        return party._charactersParty[PickNumber()];
    }

    public virtual (Item, int) PickItem(Party party, Character character)
    {
        OutputSystem.GetItemsList(party, character);
        int pick = PickNumber();

        return (party.Inventory.Items[pick].item, pick);
    }

    public virtual Gear PickGear(Party party, Character character)
    {
        OutputSystem.GetGearsList(party, character);

        return party.Inventory.Gears[PickNumber()];
    }

    protected int PickNumber() // Moved player's answer to separate method to check correctness.
    {
        int finalNumber = 0;

        Console.Write("Answer: ");

        try
        {
            finalNumber = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            finalNumber = 0;
        }

        Console.WriteLine();

        return finalNumber;
    }
}
