using UnityEngine;

public class Rotatable : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed;
    [SerializeField] [Range(0f, 10f)]
    private float _angleUpRotate;
    [SerializeField] [Range(0f, -50f)]
    private float _angleDownRotate;

    private void Update()
    {
        RotateToMousePosition();
    }

    private void RotateToMousePosition ()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotateSpeed);
        if(angle >= _angleUpRotate)
        {
            RestructionAngle(_angleUpRotate);
        }
        else if(angle <= _angleDownRotate)
        {
            RestructionAngle(_angleDownRotate);
        }
    }

    public void RestructionAngle(float angle)
    {
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, _rotateSpeed);
    }
}
