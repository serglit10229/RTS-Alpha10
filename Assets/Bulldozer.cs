using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldozer : MonoBehaviour {

    public GameObject ground;

	// Use this for initialization
	void Start () {
		
	}
	/*
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
        Debug.Log("Destroy");
        if (col.gameObject != ground)
        {
            for (int i = 255; i > 0; i--)
            {
                GetComponent<Renderer>().material.color.a = i;
            }
            if (GetComponent<Renderer>().material.color.a == 1)
            {
                Debug.Log("IfDestroy");
                Destroy(gameObject);
            }
        }
	}
    */
}
