using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {


    public List<GameObject> BotFactory;
    public List<GameObject> TankFactory;

    public GameObject Bot1UI;
	public GameObject Tank1UI;

    public GameObject BotUI;
    public GameObject TankUI;
    // Use this for initialization
    void Start () {

	}
    private void Update()
    {
        if (BotFactory.Count >= 1 || TankFactory.Count >= 1)
        {
            Debug.Log("activate");
            BotUI.SetActive(false);
            TankUI.SetActive(false);
        }
        else
        {
            Debug.Log("DEactivate");
            BotUI.SetActive(true);
            TankUI.SetActive(true);
        }
    }
    // Update is called once per frame
    public void FixedUpdate ()
    {
        Bot1UI.GetComponent<ButtonController>().Factory = BotFactory;
        if (BotFactory.Count >= 1)
        {
            List<GameObject> ls = new List<GameObject>();
            ls = Bot1UI.GetComponent<ButtonController>().Factory;
            Bot1UI.SetActive(true);
        }
        if (BotFactory.Count < 1)
        {
            Bot1UI.SetActive(false);
        }

        Tank1UI.GetComponent<ButtonController>().Factory = TankFactory;
        if (TankFactory.Count >= 1)
        {
            List<GameObject> l = new List<GameObject>();
            l = Tank1UI.GetComponent<ButtonController>().Factory;
            Tank1UI.SetActive(true);
        }
        if (TankFactory.Count < 1)
        {
            Tank1UI.SetActive(false);
        }

        /*
        if (factoryID == "Bot1") 
		{
            Debug.Log("ShowBot1");
            List<GameObject> ls = new List<GameObject>();
            ls = Bot1UI.GetComponent<ButtonController>().Factory;
            Bot1UI.SetActive (true);
            if (!Bot1UI.GetComponent<ButtonController>().Factory.Contains(factory))
                Bot1UI.GetComponent<ButtonController>().addFactory(factory);
		}
		if (factoryID == "Tank1") 
		{
			List<GameObject> ls = new List<GameObject>();
			ls = Bot1UI.GetComponent<ButtonController>().Factory;
			Tank1UI.SetActive (true);
			if (!Tank1UI.GetComponent<ButtonController>().Factory.Contains(factory))
				Tank1UI.GetComponent<ButtonController>().addFactory(factory);
		}
        
	}

	public void HideUI(string factoryID, GameObject factory)
	{
        Debug.Log("ShowUI");
        if (factoryID == "Bot1")
        {
            Debug.Log("ShowBot1");
            List<GameObject> ls = new List<GameObject>();
            ls = Bot1UI.GetComponent<ButtonController>().Factory;
            Bot1UI.SetActive(true);
            if (!Bot1UI.GetComponent<ButtonController>().Factory.Contains(factory))
                Bot1UI.GetComponent<ButtonController>().addFactory(factory);
        }
        if (factoryID == "Tank1")
        {
            List<GameObject> ls = new List<GameObject>();
            ls = Bot1UI.GetComponent<ButtonController>().Factory;
            Tank1UI.SetActive(true);
            if (!Tank1UI.GetComponent<ButtonController>().Factory.Contains(factory))
                Tank1UI.GetComponent<ButtonController>().addFactory(factory);
        }*/
    }


}
