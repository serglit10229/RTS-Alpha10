using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    /*
    public float speed = 10f;
    public float lowLimit  = 50f;
    public float highLimit = 250f;

    public float ZoomAmount = 0f;
    public float y = 0f;
	*/

	public GameObject MainCamera;
	private GameObject ScrollAngle;

	public float cameraHeight = 0f;

    public float deadZone = 0.01f;
    public float easeFactor = 20f;






    // Use this for initialization
    void Start () {
		ScrollAngle = new GameObject ();
	}
	
	// Update is called once per frame
	void Update () {

		ApplyScroll ();

		cameraHeight = transform.position.y;




		/*
        //float translation = Input.GetAxis("Vertical") * speed;
        ZoomAmount = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, ZoomAmount * speed);
		//transform.position = new Vector3 (0, 0, ZoomAmount * speed);

        if (transform.position.y < lowLimit)
        {
            y = lowLimit - transform.position.y;

            transform.Translate(0, y, 0);
        }

        if (transform.position.y > highLimit)
        {
            y = highLimit - transform.position.y;

            transform.Translate(0, y, 0);
        }
		*/

    }

	public void ApplyScroll()
	{
		

		float ScrollWheelValue = Input.GetAxis ("Mouse ScrollWheel") * easeFactor;

		if ((ScrollWheelValue > -deadZone && ScrollWheelValue < deadZone) || ScrollWheelValue == 0f) 
		{
			return;
		}

		float EularAnglesX = MainCamera.transform.localEulerAngles.x;

		ScrollAngle.transform.position = transform.position;
		ScrollAngle.transform.eulerAngles = new Vector3 (EularAnglesX, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		ScrollAngle.transform.Translate (Vector3.back * ScrollWheelValue); 

		Vector3 desiredScrollPosition = ScrollAngle.transform.position;

		float heightDifference = desiredScrollPosition.y - this.transform.position.y;
		cameraHeight += heightDifference;
		this.transform.position = desiredScrollPosition;

		return;
	}


}
