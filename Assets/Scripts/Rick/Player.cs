using Enums;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    
    private Camera _myCamera;
    private SoundEvent _soundEvent;
    
    public string[] Sounds;

    private void Awake()
    {
        _myCamera = Camera.main;
    }

    private void Update ()
    {
        Shoot();
    }

    private void Shoot ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(_myCamera.ScreenToWorldPoint(mousePos), Vector2.zero);
            if(hit.transform != null )
            {
                Enemy entity = hit.transform.gameObject.GetComponent<Enemy>();
                
                if(entity != null)
                {
                    entity.HealthPoint -= _damage;
                    entity.CheckDeath();

                    if (CountManager.Instance.GetCounter(CounterTag.TotalKills)%5==0)
                    {
                        AudioManager.PlaySound(Sounds[Random.Range(0,Sounds.Length)]);
                    }
                }
            }
            CreateExplosion(_myCamera.ScreenToWorldPoint(mousePos));
        }
    }

    private void CreateExplosion(Vector2 spawnPosition)
    {
        GameObject explosionFx = ObjectPoolManager.Instance.GetFromPool(PoolTag.ExplosionFx);
        explosionFx.transform.position = spawnPosition;
    }
}