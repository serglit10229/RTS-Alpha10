using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		formationMaker();
	}

	private void FixedUpdate()
	{
		formationShape();

	}

	public GameObject unit;//this is a cube prefab with scale dimensions .45,1.8,.3
	public Transform parent;//this is the parent object of the cubes acting as anchor point
	private Vector3 startClick;
	private Vector3 endClick;
	private float width;
	private List<GameObject> unitsList = new List<GameObject>();
	private int numberOfMen;
	private int rows;
	private int leftOverMen;//was going to use these two to calculate the number of men in the last row and...
	private int lastRowSpace;//...the amount of space needed to center them
	private int count;
	private float manWidth = (float)4.5;


	private void formationMaker()//this makes the formation upon start
	{

		for(int x = -10; x< 10; x++)
		{
			for(int z = -4; z< 4; z++)
			{
				Instantiate(unit, new Vector3(x* .7F, .9f, z*1.0f), Quaternion.identity, parent);
				unitsList.Add(unit);
			}
		}
	}

	private void formationShape()
	{
		if (Input.GetMouseButtonDown(1))
		{
			startClick = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(1))
		{
			endClick = Input.mousePosition;
		}
		//ERROR HERE?
		width = Vector3.Distance(startClick, endClick)/manWidth;//width has to be the width in terms of number of men, but i'm not sure where to get this width
		//ERROR HERE
		numberOfMen = unitsList.Count;
		rows = (int)Mathf.Floor(numberOfMen / width);
		leftOverMen = (int)Mathf.Ceil(numberOfMen % width);
		lastRowSpace = ((int)width - leftOverMen) / 2;
		Debug.Log(rows);
		Debug.Log(width);
		Debug.Log(numberOfMen);


		if (width != 0)
		{
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < width; j++)
				{
					unitsList[count].transform.position = new Vector3(i * .7F, .9f, j * 1.0f) + startClick;


					count++; 
				} 
			}
		}
		width = 0;

	}


	void Update () {

	}
}