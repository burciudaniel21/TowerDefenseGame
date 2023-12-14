using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoiny();
        }
    }

    private void GetNextWaypoiny()
    {
        //Debug.Log("index = " + wavepointIndex);
        //Debug.Log("Length = " + Waypoints.waypoints.Length);        

        if(wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            Debug.Log("Enemy destroyed."); 
            return;
        }

        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }
}
