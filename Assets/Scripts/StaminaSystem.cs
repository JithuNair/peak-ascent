public class StaminaSystem
{
    public float maxStamina = 100f;
    public float currentStamina = 100f;
    public float regenRate = 10f;

    public void Drain(float amount)
    {
        currentStamina = System.MathF.Max(0f, currentStamina - amount);
    }

    public void Regenerate(float deltaTime)
    {
        currentStamina = System.MathF.Min(maxStamina, currentStamina + regenRate * deltaTime);
    }

    public bool HasStamina(float amount)
    {
        return currentStamina >= amount;
    }
}
