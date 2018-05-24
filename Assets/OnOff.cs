using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour {


    public GameObject Sun;
    public Beacon beacon;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        beacon = Sun.gameObject.GetComponent<Beacon>();
        beacon.Off();
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        beacon = Sun.gameObject.GetComponent<Beacon>();
        beacon.On();
    }
}
