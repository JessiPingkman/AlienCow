using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    public static int CountKillEnemy;
    private void FixedUpdate ()
    {
        UseGun ();
    }

    private void Awake()
    {
        CountKillEnemy = 0;
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
                        CountKillEnemy++;
                        UIManager.Instance.UpdateWaveLabel(countKillEnemy: CountKillEnemy);
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