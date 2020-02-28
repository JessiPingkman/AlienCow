using UnityEngine;

public class Timer
{
    private float timer;

    // Use with Update function
    public bool CountTo(float secs)
    {
        if(timer > secs)
        {
            return true;
        }

        timer += Time.deltaTime;
        return false;
    }

    public void Restart()
    {
        timer = 0;
    }
}
