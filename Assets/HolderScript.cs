using System.Collections.Generic;
using UnityEngine;

public class HolderScript : MonoBehaviour
{
    private Queue<Transform> pets;

    private void Start()
    {
        pets = new Queue<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            pets.Enqueue(transform.GetChild(i));
        }
    }

    public Transform GetSomePet()
    {
        return pets.Dequeue();
    }
}
