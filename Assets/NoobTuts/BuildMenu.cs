using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour {    
    // This is the GUI size
    public int width = 200;
    public int height = 35;
    public float offset = -2.0f;

    // This is the castle prefab, to be set in the inspector
    public GameObject prefab;
    public GameObject metalPrefab;

    // This holds the game-world instance of the prefab
    GameObject instance;
    GameObject metalInstance;

    void Update() {
        
        //FACTORY
        if (instance != null) {
            // Find out the 3D world coordinates under the cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                if (hit.transform.name == "Ground")
                {
                    Debug.Log(hit.transform.name);
                    // Refresh the instance position
                    instance.transform.position = hit.point;
                    
                    // Note: if your castle appears to be 'in' the Ground
                    //       instead of 'on' the ground, you may have to adjust
                    //       the y coordinate like so:
                    instance.transform.position += new Vector3(0, offset, 0);
                }
            }
            
            // Player clicked? Then stop positioning the castle by simply
            // loosing track of our instance. It's still in the game world after-
            // wards, but we just can't position it anymore.
            if (Input.GetMouseButton(0)) {
                instance = null;
            }
        }

        

        //METAL
        if (metalInstance != null)
        {
            // Find out the 3D world coordinates under the cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "MetalSpots")
                {
                    // Refresh the instance position
                    metalInstance.transform.position = hit.point;

                    // Note: if your castle appears to be 'in' the Ground
                    //       instead of 'on' the ground, you may have to adjust
                    //       the y coordinate like so:
                    metalInstance.transform.position += new Vector3(0, offset, 0);
                }
            }

            // Player clicked? Then stop positioning the castle by simply
            // loosing track of our instance. It's still in the game world after-
            // wards, but we just can't position it anymore.
            if (Input.GetMouseButton(0))
            {
                metalInstance = null;
            }
        }
    }
    
    void OnGUI() {
        GUILayout.BeginArea(new Rect(Screen.width*0.66f - width*0.66f,
                                     Screen.height - height,
                                     width,
                                     height), "", "box");
        
        // Disable the building button if we are currently building something.
        // Note: this enables GUIs if we have no instance at the moment, and
        //       it disables GUIs if we currently have one. Its just written in
        //       a fancy way. (it can also be done with a if-else construct)
        //GUI.enabled = (instance == null);
        if (GUILayout.Button("BUILD CASTLE")) {
            // Instantiate the prefab and keep track of it by assigning it to
            // our instance variable.
            instance = (GameObject)GameObject.Instantiate(prefab);
        }
        GUILayout.EndArea();


        ///////
        ///////
        //Metal
        GUILayout.BeginArea(new Rect(Screen.width / 3 - width / 3, Screen.height - height, width, height), "", "box");

        // Disable the building button if we are currently building something.
        // Note: this enables GUIs if we have no instance at the moment, and
        //       it disables GUIs if we currently have one. Its just written in
        //       a fancy way. (it can also be done with a if-else construct)
        //GUI.enabled = (instance == null);
        if (GUILayout.Button("BUILD METAL"))
        {
            // Instantiate the prefab and keep track of it by assigning it to
            // our instance variable.
           metalInstance = (GameObject)GameObject.Instantiate(metalPrefab);
        }
        GUILayout.EndArea();
    }
}