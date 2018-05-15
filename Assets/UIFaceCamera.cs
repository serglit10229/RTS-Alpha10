using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCamera : MonoBehaviour {

    public float damping = 5f;


	void FixedUpdate() {
        Vector3 lookPos = Camera.main.transform.position - transform.position;
        lookPos.x = 0; lookPos.y = -lookPos.y; lookPos.z = -lookPos.z;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
