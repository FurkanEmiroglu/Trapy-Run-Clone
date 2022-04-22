using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimations : MonoBehaviour
{
    [SerializeField] private bool isReverse;
    [SerializeField] Animator animator;

    private void Start() {
        ReverseAnim();
    }

    private void ReverseAnim() {
        if (isReverse) {
            animator.SetBool("reverse", true);
        } else {
            animator.SetBool("reverse", false);

        }
    }

}
