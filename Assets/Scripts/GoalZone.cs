using Enums;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GoalZone : MonoBehaviour
{
    public Spawner SpawnerScript;
    public Text PetAmountText;
    
    private Transform[] _zones;
    private int _petAmount = 0;

    private void Start()
    {
        _zones = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _zones[i] = transform.GetChild(i);
        }
    }

    public Transform GetRandomTargetZone()
    {
        int zoneCount = _zones.Length;
        return _zones[Random.Range(0, zoneCount)];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<Pet>())
        {
            other.gameObject.SetActive(false);
        }
    }
}
