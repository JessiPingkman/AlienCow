using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    public Transform Target;
    
    private Rigidbody2D _rb;
    private float _startTime;
    private float _journeyLength;

    private void OnEnable() 
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void Initialize()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startTime = Time.time;
        _journeyLength = Vector3.Distance(transform.position, Target.position);
    }

    private void MoveForward()
    {
        float distCovered = (Time.time - _startTime) * Speed;
        float fractionOfJourney = distCovered / _journeyLength;
        _rb.position = Vector2.Lerp(transform.position, Target.position, fractionOfJourney);
    }

    public void ChangeTarget(Transform newTarget)
    {
        Target = newTarget;
        _startTime = Time.time;
        _journeyLength = Vector3.Distance(transform.position, Target.position);
    }
}
