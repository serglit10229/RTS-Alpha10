using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnitSpawner : MonoBehaviour
{
    // unit prefab
    //public GameObject unit;
    public float spawnRange = 1.5f;

    public float x = 0.075f;
    public float y = 0.5f;
    public float z = -0.1f;
    //public float angle = Random.Range(0.0f, 0.0f);
    public float speed1 = 0.2f;
    public float speed2 = 0.2f;

    public bool allowSpawn = false;
    public int unitAmount = 0;
    //public float prodTime = 0.0f;

    //PRODUCTION
    public GameObject unit;
    public float prodTime = 0.0f;
    //public int unitRequestAmount = 0;

    public GameObject progressBar;

    public float pbFill = 0f;

    float prevTime = 0.0f;

    bool timerIsRunning = false;

    public List<GameObject> queue;

    public float buildTime = 0;
    bool safeSpawnStarted = false;

    public bool testClick = true;

    public GameObject rallyPoint;


    public Vector3 startDest;
    public GameObject rally;

    private void Start()
    {
        startDest = new Vector3(0,-2.5f,10) + transform.position;
        rally = Instantiate(rallyPoint, startDest, Quaternion.identity);
    }

    private void Update()
    {
        rally.transform.position = startDest + new Vector3(0,0.05f,0);
    	if(queue.Count >= 1 && timerIsRunning != true)
            StartCoroutine("Timer", 5);
        if (timerIsRunning == true)
        {
            pbFill += Time.deltaTime;
            progressBar.GetComponent<Image>().fillAmount = pbFill / buildTime;
        }
        else
        {
            pbFill = 0;
            progressBar.GetComponent<Image>().fillAmount = 0;
        }

        if(progressBar.GetComponent<Image>().fillAmount == 1)
        {
            pbFill = 0;
            progressBar.GetComponent<Image>().fillAmount = 0;
        }


    }


    IEnumerator Timer(float buildTimer)
    {
        buildTimer = buildTime;
    	timerIsRunning = true;
    	yield return new WaitForSeconds(buildTimer);
    	timerIsRunning = false;
    	Spawn(queue[0]);
    }

    public void Spawn(GameObject unit)
    {
    	Vector3 pos = transform.position;
        GameObject g = Instantiate(unit, new Vector3(x + pos.x, y + pos.y, z + pos.z), Quaternion.Euler(0.0f, 0.0f, 0.0f));

        g.GetComponent<NavMeshAgent>().SetDestination(startDest);
        g.GetComponent<PlayerController>().spawnDest = true;
        queue.Remove(queue[0]);	
    }

    public void UnitRequest(GameObject unitRequest)
    {
        prevTime = 5f;
        queue.Add(unitRequest);
    }
}