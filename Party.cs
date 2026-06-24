namespace CsharpLearning;

public class Party
{
    public string PartyName { get; init; }
    public Player BelongsTo { get; init; }
    public bool AreMonstersParty { get; init; }
    public bool IsAlive { get; set; } = true;

    public List<Character> _charactersParty { get; init; }

    public PartyInventory Inventory { get; init; }

    public Party(Character[] characters, Player player, string name, bool areMonstersParty)
    {
        Inventory = new PartyInventory();
        PartyName = name;
        _charactersParty = characters.ToList();
        BelongsTo = player;
        AreMonstersParty = areMonstersParty;
    }
}
