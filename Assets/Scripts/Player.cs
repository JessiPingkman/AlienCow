using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private const string EVENT_SPAWN_BULLET = "SpawnBullet";

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            // if(hit.transform.GetComponent<Enemy>() != null)
            // {
            //     EventManager.TriggerEvent(EVENT_SPAWN_BULLET);
            // }
        }
        RotateGun();
    }

    private void RotateGun()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = (Vector2.Angle(Vector2.down, mousePosition - (Vector2)transform.position) * _speed);
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}

