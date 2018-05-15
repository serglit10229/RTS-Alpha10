using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stop : MonoBehaviour {

	public int unitNum = 0;
	public int r = 0;
	public int mult = 2;
	public float dist;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		dist = GetComponent<UnityEngine.AI.NavMeshAgent> ().remainingDistance;
		unitNum = GameObject.Find("UnitManager").GetComponent<UnitManager>().unitNum;

		r = unitNum * mult;
		if(dist <= r)
		{
            Debug.Log("Stop");
			GetComponent<UnityEngine.AI.NavMeshAgent> ().isStopped = true;

		}

    }
}
