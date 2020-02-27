using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    
    private Camera myCamera;
    
    private void Awake()
    {
        myCamera = Camera.main;
    }

    private void Update ()
    {
        UseGun ();
    }

    private void UseGun ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(myCamera.ScreenToWorldPoint(mousePos), Vector2.zero);
            if(hit.transform != null)
            {
                Enemy entity = hit.transform.gameObject.GetComponent<Enemy>();
                if(entity != null)
                {
                    entity.healthPoint -= _damage;
                    entity.CheckDeath();
                }
            }
            Explosion(myCamera.ScreenToWorldPoint(mousePos));
        }
    }

    private void Explosion(Vector2 spawnPosition)
    {
        GameObject explosionFx = ObjectPoolManager.Instance.GetFromPool(PoolTags.ExplosionFx);
        explosionFx.transform.position = spawnPosition;
    }

    private void Die ()
    {
        Destroy (gameObject);
    }
}