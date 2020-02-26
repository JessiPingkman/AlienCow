using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    public static int countKillEnemy;
    private void FixedUpdate ()
    {
        UseGun ();
    }

    private void Awake()
    {
        countKillEnemy = 0;
    }

    private void UseGun ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.transform != null)
            {
                Enemy entity = hit.transform.gameObject.GetComponent<Enemy>();
                if(entity != null)
                {
                    entity.healthPoint -= _damage;
                    if(entity.IsDeath())
                    {
                        countKillEnemy++;
                        UIManager.UpdateWaveLabel(countKillEnemy: countKillEnemy);
                    }
                }
            }
        }
    }

    private void Die ()
    {
        Destroy (gameObject);
    }
}