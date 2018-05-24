using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

    public BuildManager bm;
    public Canvas cv;
    public Button BotFactory, TankFactory;
    bool buildopen = true;
    public GameObject BotUI;
    public GameObject TankUI;

    /*
    void Start () {
		bm = GameObject.Find("BuildManager").GetComponent<BuildManager>();
        Canvas cv = GameObject.Find("Canvas").GetComponent<Canvas>();
        BotFactory = cv.transform.Find("BotFactory").gameObject.GetComponent<Button>();
        TankFactory = cv.transform.Find("TankFactory").gameObject.GetComponent<Button>();
        Metal = cv.transform.Find("Metal").gameObject.GetComponent<Button>();
        Energy = cv.transform.Find("Energy").gameObject.GetComponent<Button>();
    }
    */
    public void ActiveteBuilding(Button pressedBtn)
    {
        if (pressedBtn.name == "BuildButton")
        {
            if (buildopen)
            {
                //bm.DeactivateBuildingmode();
                BotFactory.gameObject.SetActive(false);
                TankFactory.gameObject.SetActive(false);
                pressedBtn.image.color = Color.white;
                buildopen = false;
            }
            else
            {
                //bm.ActivateBuildingmode();
                BotFactory.gameObject.SetActive(true);
                TankFactory.gameObject.SetActive(true);
                pressedBtn.image.color = new Color(255, 0, 255);
                buildopen = true;

            }
        }
        else
        {
            switch (pressedBtn.name)
            {
                case "BUILD_Button1":
                    bm.SelectBuilding(0);
                    break;
                case "BUILD_Button2":
                    bm.SelectBuilding(1);
                    break;
                case "BUILD_Button3":
                    bm.SelectBuilding(2);
                    break;
                case "BUILD_Button4":
                    bm.SelectBuilding(3);
                    break;

            }

            pressedBtn.image.color = new Color(155, 120, 255);
            bm.ActivateBuildingmode();
            
        }

    }

    void Update()
    {
        if (BotUI.activeSelf)
        {
            BotFactory.gameObject.SetActive(false);
            TankFactory.gameObject.SetActive(false);
        }
        if (!BotUI.activeSelf)
        {
            BotFactory.gameObject.SetActive(true);
            TankFactory.gameObject.SetActive(true);
        }

        if (TankUI.activeSelf)
        {
            BotFactory.gameObject.SetActive(false);
            TankFactory.gameObject.SetActive(false);
        }
        if (!TankUI.activeSelf)
        {
            BotFactory.gameObject.SetActive(true);
            TankFactory.gameObject.SetActive(true);
        }

        if (buildopen)
        {
            if (!bm.isBuildingEnabled)
            {
                if (BotFactory.image.color != Color.white)
                    BotFactory.image.color = Color.white;

                if (TankFactory.image.color != Color.white)
                    TankFactory.image.color = Color.white;
            }
        }
    }
}
