public class Item
{
    public string name;
    public float weight;
    public Item(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }
    public virtual void Use() { }
}

public class Rope : Item
{
    public Rope() : base("Rope", 2f) { }
}

public class Flashlight : Item
{
    public Flashlight() : base("Flashlight", 1f) { }
}

public class Food : Item
{
    public float staminaRestore = 20f;
    public Food() : base("Food", 1f) { }
    public override void Use() { }
}
