using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject gfx;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter () {
		Destroy(gameObject, 0.2f);
		gfx.SetActive(false);
		explosion.SetActive(true);
	}
}
