using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlameNekit : MonoBehaviour {

    public NavMeshAgent agent;

    //destination coordinates
    float DoX = 0;
    float DoZ = 0;

    //Object coordinates
    float UoX = 0;
    float UoZ = 0;

    //selected units #
    int selected_units = 0;

    //radius of the circle
    public float triggerRadius = 2.5f;

    //radius multiplier
    int mult = 1;

    public bool arrived = false;


    public float destX = 0;
    public float destY = 0;

    public float distanceDtoU = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (GetComponent<NavMeshAgent>().destination.x != destX || GetComponent<NavMeshAgent>().destination.y != destY)
        {
            arrived = false;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
        
        distanceDtoU = (float)Math.Sqrt(Math.Abs(Math.Pow(destX - transform.position.x, 2) + Math.Pow(destY - transform.position.y, 2)));
        /*
        if (distanceDtoU <= triggerRadius)
        {
            if (distanceDtoU >= triggerRadius)
            {

            }
            else
            {
                arrived = true;
            }
            //GetComponent<NavMeshAgent>().isStopped = true;
            
        }
        if (arrived == true)
        {
            GetComponent<NavMeshAgent>().isStopped = true;
        }
        */
        destX = GetComponent<NavMeshAgent>().destination.x;
        destY = GetComponent<NavMeshAgent>().destination.y;
        if (distanceDtoU <= triggerRadius)
        {
            arrived = true;
            GetComponent<NavMeshAgent>().isStopped = true;
        }
    }
    /*
    void OnTriggerEnter(Collider objectCol)
    {
        Debug.Log("Collision");
        //if(objectCol.collider.tag == )
        if (objectCol.GetComponent<Collider>().GetComponent<BlameNekit>().arrived == true)
        {
            Debug.Log("Stop after collision");
            arrived = true;
            objectCol.GetComponent<Collider>().GetComponent<NavMeshAgent>().isStopped = true;
        }
        
    }
    */
}

