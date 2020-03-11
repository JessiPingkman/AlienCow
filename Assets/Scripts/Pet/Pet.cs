﻿using Common;
using Enums;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public float Speed = 10;
    public bool IsFree = false;
    
    private Transform _home;
    private Transform _goalZone;
    private float _timer = 0;
    private int _timeToExit;
    private bool _isStupid = false;
    private Transform _myTransform;

    private void Start()
    {
        _myTransform = GetComponent<Transform>();
        _home = transform.parent;
        _goalZone = GameObject.FindGameObjectWithTag(GameObjectTag.GoalZone.ToString()).transform;
        _timeToExit = Random.Range(3, 10);
    }

    private void FixedUpdate()
    {
        if (IsFree)
        {
            Move();
        }
    }

    public void GoHome()
    {
        _myTransform.tag = GameObjectTag.FreePet.ToString();
        IsFree = true;
        AudioManager.Instance.PlayRandomSoundByTag(AudioTag.Morty);
    }

    private void Move()
    {
        float step =  Speed * Time.deltaTime; 
        _myTransform.position = Vector3.MoveTowards(transform.position, _home.position, step);
    }
}
