using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Rigidbody2D rb;
    private float startTime;
    private float journeyLength;

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
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, target.position);
    }

    private void MoveForward()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        rb.position = Vector2.Lerp(transform.position, target.position, fractionOfJourney);
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, target.position);
    }
}
