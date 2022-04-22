using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GameEvents.Instance.Falling();
            GameEvents.Instance.GameOver();
        }
    }
}
