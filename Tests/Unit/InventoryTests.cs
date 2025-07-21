using NUnit.Framework;

public class InventoryManagerTests
{
    [Test]
    public void AddItem_StopsAtLimit()
    {
        var inv = new InventoryManager { slotLimit = 2 };
        Assert.IsTrue(inv.AddItem(new Rope()));
        Assert.IsTrue(inv.AddItem(new Flashlight()));
        Assert.IsFalse(inv.AddItem(new Food()));
    }

    [Test]
    public void CurrentWeight_SumsWeights()
    {
        var inv = new InventoryManager();
        inv.AddItem(new Rope());
        inv.AddItem(new Flashlight());
        Assert.AreEqual(3f, inv.CurrentWeight, 0.01f);
    }
}
