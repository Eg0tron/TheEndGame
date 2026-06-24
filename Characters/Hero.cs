namespace CsharpLearning.Characters;

public abstract class Hero : Character
{

}

public class TrueProgrammer : Hero
{
    public override string? CharacterName { get; set; }
    public override int MaxHP { get; init; } = 25;
    public TrueProgrammer()
    {
        Console.Write("Write the hero's name: ");
        string? name = Console.ReadLine();
        CharacterName = (name == null || name == "") ? "TRUE PROGRAMMER" : name.ToUpper();

        ActionList.Add(new Punch());

        EquipedGear = new Sword();
        EquipedGear.IsEquiped = true;
        EquipedGear.EquipedOn = this;
        ActionList.Add(EquipedGear.Action);
    }
}
