using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SidewayTrigger : MonoBehaviour
{
    // When the collider triggers, it activates the enemies on the sideway;
    public List<GameObject> sidewayEnemies = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ActivateEnemies();
        }
    }

    private void ActivateEnemies() {
        foreach (GameObject enemy in sidewayEnemies) {
            enemy.SetActive(true);
        }
    }


}
