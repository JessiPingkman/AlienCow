using UnityEngine;

public class Timer
{
    private float _timer;

    // Use with Update function
    public bool CountTo(float secs)
    {
        if(_timer > secs)
        {
            return true;
        }

        _timer += Time.deltaTime;
        return false;
    }

    public void Restart()
    {
        _timer = 0;
    }
}
