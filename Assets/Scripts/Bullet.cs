using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] float speed = 70f;
    [SerializeField] GameObject impactEffect;

    public void Seek(Transform _target) 
    {  
        target = _target; 
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceTravelThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceTravelThisFrame) //if the length of the direction vector is less than the distance we are supposed to move this frame than we have hit something
            //distance from a bullet to the target = direction.magnitude
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceTravelThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject impactEffectVariable = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactEffectVariable , 2f); 
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
