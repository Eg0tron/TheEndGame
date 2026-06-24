namespace CsharpLearning.Characters;

public abstract class Character
{
    public abstract string? CharacterName { get; set; }

    public abstract int MaxHP { get; init; }
    public int CurrentHP { get; set; }

    public Gear EquipedGear { get; set; }

    public bool IsAlive { get; set; } = true;
    public bool IsCharacterTurn { get; set; } = false;

    public List<CharacterAction> ActionList { get; set; }

    public Character() 
    {
        CurrentHP = MaxHP;

        ActionList = new List<CharacterAction>  //
        {                                       // Base actions for all characters
            new DoNothing(),                    //
            new UseItem(),
            new Equip(),
        };                                      
    }
}

