using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MakeEnemyFall : MonoBehaviour
{
    // this script will be attached to enemy itself. It will make itself fall if it collides with a FallingTrigger collider.

    private EnemyMovement _enemyMovement;              // enemyMovement script.

    private void Start() {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("FallingTrigger")) {
            transform.DOMoveY(-10, 2f).OnComplete(SetObjectDisabled);
            StopMoving();
        } else if (other.CompareTag("Player")) {
            GameEvents.Instance.GameOver();
        }
    }

    private void SetObjectDisabled() {
        gameObject.SetActive(false);
    }

    private void StopMoving() {
        _enemyMovement.enabled = false;
    }
}
