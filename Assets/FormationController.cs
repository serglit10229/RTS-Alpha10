using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FormationController : MonoBehaviour {
	public float unitsNumber;
	public List<GameObject> units;
	public List<Transform> positions;
	public List<Transform> lastPositions;



    public float formWidth = 1;
    public float formHeight = 1;
    public float spacing = 10f;

    public float gridx = 0;
    public float gridy = 0;

    public bool invoken = false;

	Vector3 midPoint1;
	public Vector3 midPoint2;

    public bool multiple = false;

    public float offset = 5;

    private void Start()
    {
    	InvokeRepeating("MidPoint",1,1);
    }

    // Update is called once per frame
    void FixedUpdate() {
		unitsNumber = GetComponent<RtsSelectionSystem>().unitsList.Count;
		units = GetComponent<RtsSelectionSystem>().unitsList;


		foreach(GameObject g in units)
		{
			if(!positions.Contains(g.transform))
				positions.Add(g.transform);
		}
        foreach (Transform po in positions)
        {
            if (!units.Contains(po.gameObject))
                positions.Remove(po);

            if (po != po.gameObject.transform)
            {
                Debug.Log("Mid");
                MidPoint();
            }
        }

        if (units.Count > 1)
        {
            multiple = true;

            if (invoken == false)
            {
                //Invoke("MidPoint", 0);
            }
        }
        else
        {
            midPoint1 = Vector3.zero;
            midPoint2 = Vector3.zero;
            invoken = false;
            multiple = false;
        }
		lastPositions = positions;
		foreach(Transform p in lastPositions)
		{
			if(!positions.Contains(p))
			{
				invoken = false;
			}
		}

        if (units.Count > 1)
        {

            formWidth = Mathf.RoundToInt(Mathf.Sqrt(units.Count) - 0.5f);
            formHeight = Mathf.RoundToInt((units.Count / formWidth) + 0.5f);

            float cX = 0;
            float cY = 0;

            foreach (GameObject unit in units)
            {
                unit.GetComponent<PlayerController>().army = true;
                unit.GetComponent<PlayerController>().armyMove = (new Vector3(cX, 0f, cY)) * (unit.GetComponent<UnityEngine.AI.NavMeshAgent>().radius * 5);
                if(cX <= formWidth)
                {
                	cX++;
                }
                else
                {
                	cX = 0;
                	cY++;
                }
            }
        }
        else
        {
            foreach (GameObject unit in units)
            {
                unit.GetComponent<PlayerController>().army = false;
            }
        }
					
	}



	

	void MidPoint()
	{
		invoken = true;

		midPoint2 = SumArray(positions) / units.Count;
	}

    public Vector3 SumArray(List<Transform> toBeSummed)
    {
        Vector3 sum = Vector3.zero;
        foreach (Transform item in toBeSummed)
        {
            sum += item.position;
        }
        return sum;
    }
}
