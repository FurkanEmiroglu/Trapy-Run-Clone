using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColliderTrigger : MonoBehaviour
{
    [SerializeField] int obsForce;

    private void OnTriggerEnter(Collider other) {
        if (transform.position.x > other.transform.position.x) {
            other.GetComponent<Rigidbody>().AddForce(obsForce, 0, 0);
        } else {
            other.GetComponent<Rigidbody>().AddForce(-obsForce, 0, 0);
        }
        Debug.Log("triggered");
    }
}
