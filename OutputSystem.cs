namespace CsharpLearning;

public static class OutputSystem
{
    public static void GetPartyList(CharacterAction action, Party party)
    {
        Console.WriteLine($"On what character do you want to use {action.ActionName}:");

        for (int i = 0; i < party._charactersParty.Count; i++)
        {
            if (!party._charactersParty[i].IsCharacterTurn) Console.WriteLine($"{i} - {party._charactersParty[i].CharacterName}");
            else Console.WriteLine($"{i} - {party._charactersParty[i].CharacterName}(YOU)");
        }
    }

    public static void GetAllPartiesList(CharacterAction action, List<Party> parties)
    {
        Console.WriteLine($"On what party do you want to use {action.ActionName}:");

        for (int i = 0; i < parties.Count; i++)
        {
            Console.WriteLine($"{i} - {parties[i].PartyName}");
        }

    }

    public static void GetEnemyPartiesList(CharacterAction action, List<Party> parties)
    {
        Console.WriteLine($"On what party do you want to use {action.ActionName}:");

        for (int i = 0; i < parties.Count; i++)
        {
            Console.WriteLine($"{i} - {parties[i].PartyName}");
        }

    }

    public static void GetCharacterActionList(Character character)
    {
        Console.WriteLine($"{character.CharacterName} can do the next: ");

        for (int i = 0; i < character.ActionList.Count; i++)
        {
            Console.WriteLine($"{i} - {character.ActionList[i].ActionName} ({character.ActionList[i].Description})");
        }
    }

    public static void GetItemsList(Party party, Character character)
    {
        Console.WriteLine($"{character.CharacterName} can use the next: ");
        
        for (int i = 0; i < party.Inventory.Items.Count; i++)
        {
            Console.WriteLine($"{i} - {party.Inventory.Items[i].item.ItemName} ({party.Inventory.Items[i].amount}) - {party.Inventory.Items[i].item.Description}");
        }
    }

    public static void GetGearsList(Party party, Character character)
    {
        Console.WriteLine($"{character.CharacterName} can equip the next: ");

        for (int i = 0; i < party.Inventory.Gears.Count; i++)
        {
            Console.WriteLine($"{i} - {party.Inventory.Gears[i].GearName} - {party.Inventory.Gears[i].Description}");
        }
    }

    public static void ActionUsedOn(Character source, Character target, CharacterAction action)
    {
        Console.WriteLine($"{source.CharacterName} used {action.ActionName} on {target.CharacterName}");
    }

    public static void ItemUsedOn(Character source, Character target, Item item)
    {
        Console.WriteLine($"{source.CharacterName} used {item.ItemName} on {target.CharacterName}");
    }

    public static void GearEquiped(Character source, Gear gear)
    {
        Console.WriteLine($"{source.CharacterName} equiped {gear.GearName}");
    }

    public static void DamageDealt(Character source, Character target, CharacterAction action)
    {
        Console.WriteLine($"{action.ActionName} dealt {action.Damage} to {target.CharacterName}");
        Console.WriteLine($"{target.CharacterName} is now at {target.CurrentHP}/{target.MaxHP}");
    }

    public static void DamageDealt(Character source, Character target, Item item)
    {
        Console.WriteLine($"{item.ItemName} dealt {item.Damage} to {target.CharacterName}");
        Console.WriteLine($"{target.CharacterName} is now at {target.CurrentHP}/{target.MaxHP}");
    }

    public static void HPHealt(Character source, Character target, CharacterAction action)
    {
        Console.WriteLine($"{action.ActionName} healt {action.Heal} to {target.CharacterName}");
        Console.WriteLine($"{target.CharacterName} is now at {target.CurrentHP}/{target.MaxHP}");
    }

    public static void HPHealt(Character source, Character target, Item item)
    {
        Console.WriteLine($"{item.ItemName} healt {item.Heal} to {target.CharacterName}");
        Console.WriteLine($"{target.CharacterName} is now at {target.CurrentHP}/{target.MaxHP}");
    }

    public static void PartyDefeat(Party party)
    {
        Console.WriteLine($"Party {party.PartyName} has been defeated!\n");
    }

    public static void CharacterDefeat(Character character)
    {
        Console.WriteLine($"Character {character.CharacterName} has been defeated!\n");
    }

    public static void WinMessage() => Console.WriteLine("The heroes won! The Uncoded One was defeated!");
        

    public static void LoseMessage() => Console.WriteLine("The heroes lost! The Uncoded One’s forces have prevailed!");

    public static void GameModeList()
    {
        Console.WriteLine("Pick a game mode:");
        Console.WriteLine("0 - Human vs Computer");
        Console.WriteLine("1 - Computer vs Computer");
        Console.WriteLine("2 - Human vs Human");
        Console.Write("Answer: ");
    }
    
}
