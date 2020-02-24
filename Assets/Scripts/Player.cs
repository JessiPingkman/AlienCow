using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform gun;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            // if(hit.transform.GetComponent<Enemy>() != null)
            // {
            //     
            // }
            
        }
        RotateGun();
    }

    private void RotateGun()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = (Vector2.Angle(Vector2.down, mousePosition - (Vector2)gun.transform.position) * _speed);
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}

