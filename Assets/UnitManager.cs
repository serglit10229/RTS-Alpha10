using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {


	public List<GameObject> units = new List<GameObject> ();
	public int unitNum = 0;
	
	// Update is called once per frame
	void Update () {
		unitNum = units.Count;
	}
}
