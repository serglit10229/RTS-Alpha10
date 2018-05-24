using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    // attack range
    public float range = 5;

    // attack interval
    public float interval = 1.5f;

    // attack damage
    public int damage = 0;

    // tag of the unit that should be attacked
    public string team = "team1";

    // arrow prefab (to shoot at enemies)
    public GameObject arrow;

    // check if player2(NPC)
    public bool Player2 = false;

    //True if enemy in sight
    public bool enemyDetected = false;

    public Vector3 scale = new Vector3(0.25f, 0.25f, 0.25f);


    public GameObject Bashnya;
    public Transform m_Target;
    public float m_Speed;


    public bool mishaAxis = false;
    public Vector3 lTargetDir;
    public bool manual = false;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Fire", interval, interval + 1);
    }

    void FixedUpdate()
    {
        if (m_Target != null)
        {
            lTargetDir = m_Target.position - Bashnya.transform.position;
            if (mishaAxis == false)
                lTargetDir.y = 0.0f;
            if (mishaAxis == true)
                lTargetDir.y = 0.0f;

            Bashnya.transform.rotation = Quaternion.Lerp(Bashnya.transform.rotation, Quaternion.LookRotation(lTargetDir), Time.deltaTime * m_Speed);
        }
        if (m_Target == null)
        {
            if (mishaAxis == true)
                Bashnya.transform.localRotation = Quaternion.Lerp(Bashnya.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
            if (mishaAxis == false)
                Bashnya.transform.localRotation = Quaternion.Lerp(Bashnya.transform.localRotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);
        }
    }

    void Fire()
    {
        if (m_Target == null && manual == false)
        {
            foreach (Attack g in FindObjectsOfType<Attack>())
            {
                // still alive?
                if (g != null)
                {
                    if (g.team != team)
                    {
                        // in attack range?	
                        if (Vector3.Distance(g.transform.position, transform.position) >= range)
                        {
                            m_Target = null;
                        }
                        if (Vector3.Distance(g.transform.position, transform.position) <= range)
                        {
                            enemyDetected = true;
                            GameObject a = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                            a.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                            a.transform.LookAt(g.transform);
                            a.GetComponent<Arrow>().damage = damage;

                            m_Target = g.transform;
                            // set its target
                            a.GetComponent<Arrow>().target = g.transform;
                            a.GetComponent<Arrow>().Fire(g.transform);

                            /*
                            if (Player2 == false)
                            {
                                a.GetComponent<Destroy>().enemyTag = "Enemy";
                            }
                            if (Player2 == true)
                            {
                                a.GetComponent<Destroy>().enemyTag = "Player";
                            }
                            */
                            break;
                        }
                    }
                }

                if (g == null)
                {
                    enemyDetected = false;
                }
            }
        }
        else
        {
            // in attack range? 
            if (Vector3.Distance(m_Target.transform.position, transform.position) >= range)
            {
                m_Target = null;
            }
            if (Vector3.Distance(m_Target.transform.position, transform.position) <= range)
            {
                enemyDetected = true;
                GameObject a = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                a.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                a.transform.LookAt(m_Target.transform);
                a.GetComponent<Arrow>().damage = damage;
                // set its target
                a.GetComponent<Arrow>().target = m_Target.transform;
                a.GetComponent<Arrow>().Fire(m_Target.transform);

                /*
                if (Player2 == false)
                {
                    a.GetComponent<Destroy>().enemyTag = "Enemy";
                }
                if (Player2 == true)
                {
                    a.GetComponent<Destroy>().enemyTag = "Player";
                }
                */
            }
        }
    }
}

