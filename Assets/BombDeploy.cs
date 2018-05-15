using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDeploy : MonoBehaviour {

	public GameObject bomb;
	public GameObject thisUnit;
	public float force = 0;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Deploy", 2,2);
	}
	
	// Update is called once per frame
	public void Deploy () {
		Quaternion deployRotation = transform.rotation;

		
		GameObject b = Instantiate(bomb, transform.position, deployRotation);
		b.GetComponent<Rigidbody>().velocity = transform.up * force;
	}
}
