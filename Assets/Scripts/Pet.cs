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
    public string[] sounds;
    private string stupidSound = "A chicken would say_sound";

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
        AudioManager.PlaySound(sounds[UnityEngine.Random.Range(0,sounds.Length-1)]);
    }

    private void IsReadyToExit()
    {
        timer += Time.deltaTime;
  
        if(timer > timeToExit)
        {
            timer = 0;
            isStupid = true;
            AudioManager.PlaySound(stupidSound);
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
