using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    
    private Camera myCamera;
    
    public static int CountKillEnemy;

    private void Awake()
    {
        myCamera = Camera.main;
        CountKillEnemy = 0;
    }

    private void Update ()
    {
        UseGun ();
    }

    private void UseGun ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            Vector2 mousePos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(myCamera.ScreenToWorldPoint(mousePos), Vector2.zero);
            if(hit.transform != null)
            {
                Enemy entity = hit.transform.gameObject.GetComponent<Enemy>();
                if(entity != null)
                {
                    entity.healthPoint -= _damage;
                    if(entity.IsDeath())
                    {
                        CountKillEnemy++;
                        UIManager.Instance.UpdateWaveLabel(countKillEnemy: CountKillEnemy);
                    }
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