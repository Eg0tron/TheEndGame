namespace CsharpLearning.Inventory.Gears;

public abstract class Gear
{
    public abstract string GearName { get; init; }

    public abstract string Description { get; init; }

    public bool IsEquiped { get; set; } = false;

    public Character EquipedOn { get; set; }

    public abstract CharacterAction Action { get; init; }
}


public class Sword : Gear
{
    public override string GearName { get; init; } = "SWORD";

    public override string Description { get; init; } = "A big sword for slashing enemies";

    public override CharacterAction Action { get; init; } = new Slash();
}

public class Dagger : Gear
{
    public override string GearName { get; init; } = "DAGGER";

    public override string Description { get; init; } = "A small dagger for long-range attacks";
    
    public override CharacterAction Action { get; init; } = new Stab();
}