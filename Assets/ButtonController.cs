using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public List<GameObject> bots = new List<GameObject>();
    public List<GameObject> tanks = new List<GameObject>();


    public bool BotFactoryT1 = false;
    public bool TankFactoryT1 = false;

    public List<GameObject> Factory = new List<GameObject>();


    // Use this for initialization
    void Update()
    {
        if (Factory != null)
        {
            /*
            if (Unit1.GetComponent<Button> ().onClick) {
             Factory.GetComponent<UnitSpawner> ().SpawnUnitBot1 ();
            }
            if (Unit2.GetComponent<Button> ().onClick) {
             Factory.GetComponent<UnitSpawner> ().SpawnUnitBot1 ();
            }
            if (Unit3.GetComponent<Button> ().onClick) {
             Factory.GetComponent<UnitSpawner> ().SpawnUnitBot1 ();
            }
            if (Unit4.GetComponent<Button> ().onClick) {
             Factory.GetComponent<UnitSpawner> ().SpawnUnitBot1 ();
            }
            */
        }
    }

    public void addFactory(GameObject factory)
    {
        Factory.Add(factory);
    }

    public void Unit1()
    {
        if (BotFactoryT1 == true)
        {

            foreach (GameObject go in Factory)
            {
                UnitSpawner us = go.GetComponent<UnitSpawner>();
                us.unit = bots[0];
                us.prodTime = 5.0f;
                //Factory.GetComponent<UnitSpawner>().unitRequestAmount = 1;
                us.UnitRequest(bots[0]);
            }
        }
        if (TankFactoryT1 == true)
        {
            foreach (GameObject go in Factory)
            {
                UnitSpawner us = go.GetComponent<UnitSpawner>();
                us.unit = tanks[0];
                us.prodTime = 10f;
                //Factory.GetComponent<UnitSpawner>().unitRequestAmount = 1;
                us.UnitRequest(tanks[0]);
            }
        }
    }
    public void Unit2()
    {
        if (BotFactoryT1 == true)
        {

            foreach (GameObject go in Factory)
            {
                UnitSpawner us = go.GetComponent<UnitSpawner>();
                us.unit = bots[0];
                us.prodTime = 15f;
                //Factory.GetComponent<UnitSpawner>().unitRequestAmount = 1;
                us.UnitRequest(bots[1]);
            }
        }
        if (TankFactoryT1 == true)
        {
            foreach (GameObject go in Factory)
            {
                UnitSpawner us = go.GetComponent<UnitSpawner>();
                us.unit = tanks[0];
                us.prodTime = 20f;
                //Factory.GetComponent<UnitSpawner>().unitRequestAmount = 1;
                us.UnitRequest(tanks[1]);
            }
        }
    }
    public void Unit3()
    {
        if (BotFactoryT1 == true)
        {

            foreach (GameObject go in Factory)
            {
                UnitSpawner us = go.GetComponent<UnitSpawner>();
                us.unit = bots[0];
                us.prodTime = 5.0f;
                //Factory.GetComponent<UnitSpawner>().unitRequestAmount = 1;
                us.UnitRequest(bots[2]);
            }
        }
        if (TankFactoryT1 == true)
        {
            foreach (GameObject go in Factory)
            {
                UnitSpawner us = go.GetComponent<UnitSpawner>();
                us.unit = tanks[0];
                us.prodTime = 25f;
                //Factory.GetComponent<UnitSpawner>().unitRequestAmount = 1;
                us.UnitRequest(tanks[2]);
            }
        }
    }
}