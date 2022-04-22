using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider thisCollider;
    private Transform _playerTransform;

    private void Start() {
        GameEvents.Instance.onTackle += TriggerTakedown;
        GameEvents.Instance.onTackle += DisableCollider;
        GameEvents.Instance.onLevelEnding += TriggerLost;
        _playerTransform = ObjectHolder.Instance._playerTransform;
    }


    private void OnDisable() {
        GameEvents.Instance.onTackle -= TriggerTakedown;
        GameEvents.Instance.onTackle -= DisableCollider;
        GameEvents.Instance.onLevelEnding -= TriggerLost;
    }

    private void TriggerTakedown() {
        if (Vector3.Distance(transform.position, _playerTransform.position) < 1) {
        animator.SetTrigger("takedown");
        } else {
            animator.SetTrigger("victory");
        }
    }

    private void TriggerLost() {
        animator.SetTrigger("kneel");
    }

    private void DisableCollider() {
        thisCollider.enabled = false;
    }
}
