using UnityEngine;

public abstract class MortalEntity : MonoBehaviour
{
    public float healthPoint = 10;

    public bool IsDeath()
    {
        if (healthPoint <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    protected abstract void Die();
}
