using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoint;

    public void СauseDamage(float damage)
    {
        healthPoint -= damage;
        CheckHeath();
    }

    private void CheckHeath()
    {
        if (healthPoint <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
