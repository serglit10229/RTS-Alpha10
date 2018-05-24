using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    Vector3 dir = new Vector3();
    public float speed = 5;
    public Transform target;

    public float delay = 0.5f;
    public string enemyTag;
    public bool afterSpawn = false;

    public int damage = 0;
    public bool energyBoolet = false;

    public GameObject effect1;
    public GameObject effect2;

    void Update() {
        if (target)
        {
            GetComponent<Rigidbody>().velocity = dir * speed;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void Fire(Transform dest)
    {
        dir = dest.position - transform.position;
    }
    
    void OnTriggerEnter(Collider co) {
        Debug.Log("Triggered");
        if (afterSpawn == true)
        {
            Debug.Log("AfterSpawn");
            Destroy(gameObject);
            speed = 0;
            //StopCoroutine("Delay");
        }
        if (co == target.gameObject) {
            Debug.Log("Target");
            co.gameObject.GetComponent<Health>().current -= damage;
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        StartCoroutine("Delay");
        StartCoroutine("AfterSpawn");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    IEnumerator AfterSpawn()
    {
        yield return new WaitForSeconds(delay);
        afterSpawn = true;
    }
}