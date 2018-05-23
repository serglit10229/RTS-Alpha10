using UnityEngine;
using System.Collections;

public class CastlePlayer : MonoBehaviour {
    // Note: OnMouseDown only works if object has a collider
    public GameObject BuildGuide;

    public float yoff = 0f;

    public GameObject pb;

    public bool selected = false;

    public bool overlap = false;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        GetComponent<UnitSpawner>().selected = selected;
        if (selected == true)
        {
            GetComponent<UnitSpawner>().rally.SetActive(true);
            // If we press left mouse
            if (Input.GetMouseButtonDown(1))
            {
                // We create a ray
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // If the ray hits
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    GetComponent<UnitSpawner>().startDest = hit.point;
                }
            }
        }
        else
        {
            GetComponent<UnitSpawner>().rally.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        overlap = true;
    }

    private void OnTriggerExit(Collider other)
    {

        overlap = false;
    }

    private void OnTriggerStay(Collider other)
    {
        overlap = true;
    }
}