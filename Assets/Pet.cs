using UnityEngine;

public class Pet : MonoBehaviour
{
    private Transform home;

    private void Start()
    {
        home = transform.parent;
    }

    public void GoHome()
    {
        transform.tag = Tags.FreePet.ToString();
    }
}
