using UnityEngine;
using System.Collections;

public class CastlePlayer : MonoBehaviour {
    // Note: OnMouseDown only works if object has a collider
    public GameObject BuildGuide;

    public float yoff = 0f;

    public GameObject pb;


    public bool overlap = false;
    void OnMouseDown() {
        // use UnitSpawner

        //GetComponent<UnitSpawner>().Spawn();
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