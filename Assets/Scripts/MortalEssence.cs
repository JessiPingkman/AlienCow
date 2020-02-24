﻿using UnityEngine;

public abstract class MortalEssence : MonoBehaviour
{
    public float healthPoint = 10;

    protected void CheckHeath()
    {
        if (healthPoint <= 0)
        {
            Die();
        }
    }

    public abstract void Die();
}