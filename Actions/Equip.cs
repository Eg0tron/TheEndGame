namespace CsharpLearning.Actions;

public class Equip : CharacterAction
{
    public override string ActionName { get; init; } = "EQUIP GEAR";
    public override string Description { get; init; } = "Equip a gear";

    public override int Damage { get; set; } = 0;
    public override int Heal { get; set; } = 0;

    public override void Do(List<Party> parties, Character sourceCharacter, Player currentPlayer) 
    {
        Party? sourceParty = null;
        Gear gearToEquip;
        Gear currentGear = sourceCharacter.EquipedGear;

        foreach (Party party in parties)
        {
            foreach (Character character in party._charactersParty)
            {
                if (character == sourceCharacter) sourceParty = party;
            }
        }

        if (sourceParty.Inventory.Gears.Count <= 0)
        {
            currentPlayer.PickActionAndDo(parties, sourceCharacter, currentPlayer);
            return;
        }

        gearToEquip = currentPlayer.PickGear(sourceParty, sourceCharacter);

        if (currentGear is not null) 
        {
            sourceCharacter.ActionList.Remove(sourceCharacter.EquipedGear.Action);
            sourceParty.Inventory.Gears.Add(currentGear);
            sourceCharacter.EquipedGear = null;
            currentGear.EquipedOn = null;
            currentGear.IsEquiped = false; 
        }

        gearToEquip.EquipedOn = sourceCharacter;
        sourceCharacter.EquipedGear = gearToEquip;
        gearToEquip.IsEquiped = true;
        sourceParty.Inventory.Gears.Remove(gearToEquip);
        sourceCharacter.ActionList.Add(sourceCharacter.EquipedGear.Action);

        OutputSystem.GearEquiped(sourceCharacter, gearToEquip);
    }
}
