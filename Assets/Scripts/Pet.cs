using Enums;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public float speed = 10;
    
    private Transform home;
    private Transform goalZone;
    private float timer = 0;
    private int timeToExit;
    private bool isStupuid = false;

    private void Start()
    {
        home = transform.parent;
        goalZone = GameObject.FindGameObjectWithTag(Tags.GoalZone.ToString()).transform;
        timeToExit = Random.Range(3, 10);
    }

    private void Update()
    {
        if (transform.CompareTag(Tags.FreePet.ToString()))
        {
            Move();
        }
    }

    public void GoHome()
    {
        transform.tag = Tags.FreePet.ToString();
    }

    private void IsReadyToExit()
    {
        timer += Time.deltaTime;
  
        if(timer > timeToExit)
        {
            timer = 0;
            isStupuid = true;
        }
    }

    void GoToGoalZone()
    {
        float step =  speed/4 * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, goalZone.position, step);
    }

    private void Move()
    {
        float step =  speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, home.position, step);
    }
}
