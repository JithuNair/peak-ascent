using NUnit.Framework;

public class StaminaSystemTests
{
    private StaminaSystem stamina;

    [SetUp]
    public void Setup()
    {
        stamina = new StaminaSystem();
        stamina.maxStamina = 100f;
        stamina.currentStamina = 100f;
        stamina.regenRate = 10f;
    }

    [Test]
    public void DrainReducesStamina()
    {
        stamina.Drain(20f);
        Assert.AreEqual(80f, stamina.currentStamina, 0.01f);
    }

    [Test]
    public void RegenerateRecoversStamina()
    {
        stamina.currentStamina = 50f;
        stamina.Regenerate(1f);
        Assert.Greater(stamina.currentStamina, 50f);
    }
}
