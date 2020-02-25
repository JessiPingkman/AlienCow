using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update ()
    {
        UseGun ();
    }

    private void UseGun ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            // if(hit.transform.GetComponent<Enemy>() != null)
            // {
            //     
            // }
        }
    }

    private void Die ()
    {
        Destroy (gameObject);
    }
}