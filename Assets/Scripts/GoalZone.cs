using UnityEngine;

public class GoalZone : MonoBehaviour
{
    private Transform[] zones;

    private void Start()
    {
        zones = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            zones[i] = transform.GetChild(i);
        }
    }

    public Transform GetRandomZone()
    {
        int zoneCount = zones.Length;
        return zones[Random.Range(0, zoneCount)];
    }
}
