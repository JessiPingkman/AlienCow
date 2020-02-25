using UnityEngine;

public class Rotatable : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed;

    private void FixedUpdate()
    {
        RotateToMousePosition();
    }

    private void RotateToMousePosition ()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotateSpeed);
        if(angle <= -50f)
        {
            Quaternion newRotation = Quaternion.AngleAxis(-50f, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, _rotateSpeed);
        }
        else if(angle >= 6f)
        {
            Quaternion newRotation = Quaternion.AngleAxis(6f, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, _rotateSpeed);
        }
    }
}
