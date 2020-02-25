using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform _gun;

    private void Update ()
    {
        UseGun ();
        RotateToMousePosition ();
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

    void RotateToMousePosition ()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speed * Time.deltaTime);
        if(angle >= 65f){
            Quaternion newRotation = Quaternion.AngleAxis(65f, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, _speed);
        }
        else if(angle <= -50f){
            Quaternion newRotation = Quaternion.AngleAxis(-50f, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, _speed);
        }
    }

    private void Die ()
    {
        Destroy (gameObject);
    }
}