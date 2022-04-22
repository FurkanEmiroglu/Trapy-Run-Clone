using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Start() {
        GameEvents.Instance.onTackle += TriggerTripping;
        GameEvents.Instance.onLevelEnding += TriggerFlipping;
        GameEvents.Instance.onFalling += TriggerFalling;
    }

    private void OnDisable() {
        GameEvents.Instance.onTackle -= TriggerTripping;
        GameEvents.Instance.onLevelEnding -= TriggerFlipping;
        GameEvents.Instance.onFalling -= TriggerFalling;
    }

    private void TriggerTripping() {
        animator.SetTrigger("tripping");
    }

    private void TriggerFlipping() {
        animator.SetTrigger("flipping");
    }

    private void TriggerFalling() {
        animator.SetTrigger("falling");
    }
}
