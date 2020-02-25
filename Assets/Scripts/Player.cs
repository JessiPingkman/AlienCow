using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    private void Update ()
    {
        UseGun ();
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
                    entity.CheckHeath();
                }
            }
        }
    }

    private void Die ()
    {
        Destroy (gameObject);
    }
}