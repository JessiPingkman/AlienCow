﻿using UnityEngine;

public abstract class MortalEntity : MonoBehaviour
{
    public float healthPoint = 10;

    protected void CheckHeath()
    {
        if (healthPoint <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}
