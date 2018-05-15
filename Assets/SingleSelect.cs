using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSelect : MonoBehaviour {

	public GameObject selectionCirclePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButtonDown( 0 ) )
		{
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if (Physics.Raycast (ray, out hit)) {
				foreach (var selectableObject in FindObjectsOfType<SelectableUnitComponent>()) {
					//if (hit.collider.tag == "SelectableUnit") 
					//{
						//Debug.Log (selectableObject);
						if (selectableObject.selectionCircle == null) 
						{
							//Debug.Log ("Cirlce");
							selectableObject.selectionCircle = Instantiate (selectionCirclePrefab);
							selectableObject.selectionCircle.transform.SetParent (selectableObject.transform, false);
							selectableObject.selectionCircle.transform.eulerAngles = new Vector3 (90, 0, 0);
						}
					//}
				}
			}
		}
	}
}
