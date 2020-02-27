using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    
    private Camera myCamera;
    private SoundEvent soundEvent;
    
    public string[] sounds;

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
            Vector3 mousePos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(myCamera.ScreenToWorldPoint(mousePos), Vector2.zero);
            if(hit.transform != null )
            {
                Debug.Log(hit.collider.name);
                Enemy entity = hit.transform.gameObject.GetComponent<Enemy>();
                if(entity != null)
                {
                    entity.healthPoint -= _damage;
                    entity.CheckDeath();

                    if (CountManager.Instance.GetCounter(CounterTags.totalKills)%5==0)
                    {
                        AudioManager.PlaySound(sounds[UnityEngine.Random.Range(0,sounds.Length-1)]);
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