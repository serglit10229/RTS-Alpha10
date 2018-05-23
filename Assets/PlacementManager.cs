using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlacementManager : MonoBehaviour {

    public List<GameObject> Buildings = new List<GameObject>();
    public Shader BuildGuide;
    public GameObject Ground;

    public GameObject ghost;
    private int fingerID = -1;
    private void Awake()
    {
    #if !UNITY_EDITOR
            fingerID = 0; 
    #endif

    }
	public void Activate(int buildingIndex) 
    {
        ghost = Instantiate(Buildings[buildingIndex], new Vector3(0,0,0), Quaternion.identity);
        ghost.GetComponent<Collider>().enabled = false;
	}
	
	void FixedUpdate () 
    {
        
        if (ghost != null)
        {
            if (EventSystem.current.IsPointerOverGameObject(fingerID) == false)
            {
                RaycastHit hit;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject == Ground)
                    {
                        ghost.transform.position = hit.point;
                        if (!ghost.GetComponent<CastlePlayer>().BuildGuide.activeSelf)
                        {
                            ghost.GetComponent<CastlePlayer>().BuildGuide.SetActive(true);
                            ghost.GetComponent<CastlePlayer>().pb.SetActive(false);
                        }
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            DestroyImmediate(ghost);
                            ghost = null;
                        }
                        if (Check() == true)
                        {
                            Renderer rend = ghost.GetComponent<CastlePlayer>().BuildGuide.GetComponent<Renderer>();
                            rend.material.shader = BuildGuide;
                            rend.material.SetColor("_Color", Color.green);
                            if (Input.GetMouseButtonDown(0))
                            {
                                ghost = null;
                                ghost.GetComponent<Collider>().enabled = true;
                                if (ghost.GetComponent<CastlePlayer>().BuildGuide.activeSelf)
                                {
                                    ghost.GetComponent<CastlePlayer>().BuildGuide.SetActive(false);
                                    ghost.GetComponent<CastlePlayer>().pb.SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
	}

    private bool Check()
    {
        if(ghost.GetComponent<CastlePlayer>().overlap != true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
