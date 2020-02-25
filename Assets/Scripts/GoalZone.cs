using Enums;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GoalZone : MonoBehaviour
{
    public Spawner spawnerScript;
    public Text petAoumtText;
    
    private Transform[] zones;
    private int petAmount = 0;

    private void Start()
    {
        zones = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            zones[i] = transform.GetChild(i);
        }
    }

    public Transform GetRandomTargetZone()
    {
        int zoneCount = zones.Length;
        return zones[Random.Range(0, zoneCount)];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.transform.tag);
        if (other.transform.CompareTag(Tags.CapturedPet.ToString()))
        {
            CountPet();
        }
    }

    private void CountPet()
    {
        petAmount++;
        UpdateText();
        if (petAmount >= spawnerScript.spawnCount)
        {
            GameOver();
        }
    }

    private void UpdateText()
    {
        petAoumtText.text = petAmount.ToString();
    }

    private void GameOver()
    {
        return;
    }
}
