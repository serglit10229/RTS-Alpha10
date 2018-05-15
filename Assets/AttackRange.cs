using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour {

    List<GameObject> enemies = new List<GameObject>();

    // Use this for initialization
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!enemies.Contains(collision.gameObject))
            {
                enemies.Add(collision.gameObject);
            }
        }
    }

}
