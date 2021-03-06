﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 100f;

    private Transform target;
    private int wavepointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if( Vector2.Distance(transform.position, target.position) <= 1f )
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if( wavepointIndex >= Waypoints.waypoints.Length - 1 )
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }
}
