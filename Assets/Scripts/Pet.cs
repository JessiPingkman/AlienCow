using Enums;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public float speed = 10;
    public bool isFree = false;
    
    private Transform home;
    private Transform goalZone;
    private float timer = 0;
    private int timeToExit;
    private bool isStupid = false;
    private Transform myTransform;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
        home = transform.parent;
        goalZone = GameObject.FindGameObjectWithTag(Tags.GoalZone.ToString()).transform;
        timeToExit = Random.Range(3, 10);
    }

    private void FixedUpdate()
    {
        if (isFree)
        {
            Move();
        }
    }

    public void GoHome()
    {
        myTransform.tag = Tags.FreePet.ToString();
        isFree = true;
    }

    private void IsReadyToExit()
    {
        timer += Time.deltaTime;
  
        if(timer > timeToExit)
        {
            timer = 0;
            isStupid = true;
        }
    }

    private void GoToGoalZone()
    {
        float step =  speed/4 * Time.deltaTime; 
        myTransform.position = Vector3.MoveTowards(transform.position, goalZone.position, step);
    }

    private void Move()
    {
        float step =  speed * Time.deltaTime; 
        myTransform.position = Vector3.MoveTowards(transform.position, home.position, step);
    }
}
