namespace CsharpLearning.Inventory;

public class PartyInventory
{
    public List<(Item item, int amount)> Items { get; init; } = new List<(Item item, int amount)>();
    public List<Gear> Gears { get; init; } = new List<Gear>();

    public void AddItem(Item item, int amount) => Items.Add((item, amount));

    public void AddGear(Gear gear) => Gears.Add(gear);
    public void AddGear(params Gear[] gears)
    {
        foreach (Gear gear in gears)
        {
            Gears.Add(gear);
        }
    }
    public Item GetItem(int index) => Items[index].item;

    public void CheckItemAmount(int index)
    {
        if (Items[index].amount <= 0) Items.Remove(Items[index]);
    }

    public void DecreaseAmount(int index)
    {
        Items[index] = (GetItem(index), Items[index].amount - 1);
    }

    public void IncreaseAmount(int index)
    {
        Items[index] = (GetItem(index), Items[index].amount + 1);
    }

}
