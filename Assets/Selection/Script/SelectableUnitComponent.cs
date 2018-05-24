using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class SelectableUnitComponent : MonoBehaviour
{
    public GameObject selectionCircle;

	public bool selected = false;
	public bool move = false;
	public bool attack = false;

	public bool Highlighted = false;




	public bool debugDeselect = false;

	public void Update ()
	{
		if (selected == true) {
			if (Highlighted == false) {
				selectionCircle.gameObject.SetActive (true);
				Highlighted = true;
			}
		} 

		//DEBUG
		if (debugDeselect == true) 
		{
			Deselect ();
		}
	}

	public void Deselect()
	{
		if (selected == true && Highlighted == true) 
		{
			selectionCircle.gameObject.SetActive(false);
			//selectionCircle = null;

			selected = false;
			Highlighted = false;
		}
	}
}