using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Rigidbody2D rigidbody2D;
    private float startTime;
    private float journeyLength;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, target.position);
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        rigidbody2D.position = Vector2.Lerp(transform.position, target.position, fractionOfJourney);
    }
}
