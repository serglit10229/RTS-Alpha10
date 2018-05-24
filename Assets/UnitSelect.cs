using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour {

	Camera cam;
	public GameObject selectionCirclePrefab;
	public bool objectSelected = false;
	SelectableUnitComponent selectableObject;
    PlayerController playerController;

    public GameObject selectedGameObject;
	//public bool selected = false;
	//public GameObject prevSelect; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown (0)) 
		{
			//Debug.Log ("Click");
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) 
			{
				selectableObject = hit.collider.GetComponent<SelectableUnitComponent> ();
                playerController = hit.collider.GetComponent<PlayerController>();
				//Debug.Log ("HIT");
				if (hit.collider.tag == "SelectableUnit") {
					//Debug.Log ("SelectableUnit");
					//SelectableUnitComponent selectableObject = GetComponent(SelectableUnitComponent);
					selectableObject.selected = true;
					objectSelected = true;
                    selectedGameObject = hit.collider.gameObject;
                    Debug.Log("Select");
                    playerController.selected = true;

				} 
			}
		}
    }


    private void LateUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log ("Click");
            RaycastHit hit2;
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray2, out hit2, Mathf.Infinity))
            {
                playerController = selectedGameObject.GetComponent<PlayerController>();
                selectableObject = selectedGameObject.GetComponent<SelectableUnitComponent>();
                if (objectSelected == true)
                {
                    //SelectableUnitComponent selectableObject = GetComponent(SelectableUnitComponent) ();
                    selectableObject.Deselect();
                    playerController.selected = false;
                    selectedGameObject = null;
                    objectSelected = false;
                    Debug.Log("Deselect");
                }
            }
        }
    }
}
