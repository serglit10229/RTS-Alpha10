using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour {

    public float x = 0;
    public float y = 5;
    public float z = 0;

	public GameObject Sun;
	private Light myLight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(x,y,z);

		myLight = GetComponent<Light>();

		//myLight.enabled = false;
        /*
		Debug.Log (Sun.transform.eulerAngles.x);

		if (Sun.transform.eulerAngles.x < 360) 
		{
			myLight.enabled = false;	
			Debug.Log ("false");
		}

		if (Sun.transform.eulerAngles.x > 0) 
		{
			myLight.enabled = true;
			Debug.Log ("true");
		}
        */
	}

    public void On()
    {
        myLight.enabled = true;
    }

    public void Off()
    {
        myLight.enabled = false;
    }

}
