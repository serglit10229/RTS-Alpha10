using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/* Controls the player. Here we choose our "focus" and where to move. */

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public Interactables focus;  // Our current focus: Item, Enemy etc.
    public bool selected = false;
    public LayerMask movementMask;  // Filter out everything not walkable
    public Transform lastPosition;

    public bool army = false;
    public Vector3 armyMid;
    public Vector3 armyMove;
    public Vector3 finalDest;

    public Vector3 dest;

    public GameObject thisUnit;
    public GameObject destPoint;

    public bool airplane = false;
    public float airSpeed;
    public float airRotationSpeed;
    public bool airMove = false;

    public bool spawnDest = false;
    Camera cam;         // Reference to our camera
    PlayerMotor motor;  // Reference to our motor

    public float attackRange = 0;
    public GameObject target;

    // Get references
    void Start()
    {
        attackRange = GetComponentInChildren<Attack>().range;
        motor = thisUnit.GetComponent<PlayerMotor>();
        InvokeRepeating("lastPos", 1, 1);
    }

    void lastPos()
    {
        lastPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnDest == true)
        {
            Debug.Log(gameObject.name + Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination));
            if (Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination) < 2)
            {
                GetComponent<NavMeshAgent>().ResetPath();
                spawnDest = false;
            }
        }


        if (selected == true)
        {
            // We create a ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //,movementMask))
            {
                //if (hit.transform.gameObject.GetComponent<PlayerController>() != null || hit.transform.gameObject.GetComponent<CastlePlayer>() != null)
                if (Input.GetMouseButtonDown(1))
                {
                    if (hit.transform.gameObject != destPoint)
                    {
                        if (hit.transform.gameObject.GetComponent<PlayerController>() != null)//TODO: CASTLE PLAYER DETECTION
                        {
                            //UNIT OR BUILDING

                            //TODO: HIGHLIGHT
                            if (hit.transform.gameObject.GetComponentInChildren<Attack>().team != GetComponentInChildren<Attack>().team)
                            {
                                //ENEMY

                                target = hit.transform.gameObject;
                            }
                            else
                            {
                                //ALLY
                                Debug.Log("Set Dest");
                                SetDestination(hit);
                            }
                        }
                        else
                        {
                            //NOT UNIT OR BUILDING
                            Debug.Log("Set Dest");
                            SetDestination(hit);
                        }
                    }
                }
            }


            if (airplane == true && airMove == true)
            {
                if (army == true)
                {
                    float step = airSpeed * Time.deltaTime;
                    Vector3 lookDest = transform.position - (transform.position + (dest - armyMid));
                    lookDest.y = 0;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-lookDest), Time.deltaTime * airRotationSpeed);
                    if (transform.position != dest)
                        transform.Translate(transform.forward * step, Space.World);
                    if (transform.position == transform.position + (dest - armyMid))
                        airMove = false;
                }
                else
                {
                    float step = airSpeed * Time.deltaTime;
                    airSpeed = 5;
                    //if(airSpeed <= 5)
                    //  airSpeed += 0.1f;

                    Vector3 lookDest = transform.position - dest;
                    lookDest.y = 0;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-lookDest), Time.deltaTime * airRotationSpeed);
                    if (Vector3.Distance(dest, transform.position) <= 15)
                        airMove = false;
                    else
                        transform.Translate(transform.forward * step, Space.World);
                    Debug.Log("Distance = " + Vector3.Distance(dest, transform.position));
                }
            }
        }

        if (target != null)
        {
            GetComponent<NavMeshAgent>().destination = target.transform.position;
            GetComponent<NavMeshAgent>().stoppingDistance = attackRange;
            foreach (Attack script in GetComponentsInChildren<Attack>())
            {
                script.manual = true;
                script.m_Target = target.transform;
            }
        }
        else
        {
            GetComponent<NavMeshAgent>().stoppingDistance = 0.0f;
        }
    }


    void SetDestination(RaycastHit hit)
    {

        GetComponent<NavMeshAgent>().stoppingDistance = 0;
        GetComponentInChildren<Attack>().manual = false;
        dest = hit.point;
        /*
        if(GetComponent<NavMeshAgent>().updatePosition == false)
        {
            GetComponent<NavMeshAgent>().updatePosition = true;
        }*/
        Instantiate(destPoint, dest + new Vector3(0, 0.1f, 0), Quaternion.identity);
        if (army == true)
        {
            if (airplane == false)
            {
                //armyMid = Vector3.zero;
                motor.MoveToPoint(dest + armyMove);
                finalDest = dest + armyMove;  // Move to where we hit
            }
            if (airplane == true)
            {
                dest.y = 30f;
                airMove = true;

            }
        }

        else
        {
            if (airplane == false)
            {
                armyMid = Vector3.zero;
                motor.MoveToPoint(hit.point);   // Move to where we hit
            }
            if (airplane == true)
            {
                dest.y = 30f;
                airMove = true;
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, dest);
    }
}