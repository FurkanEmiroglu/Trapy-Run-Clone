using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JoinMainRoad : MonoBehaviour
{
    [SerializeField] EnemyMovement selfMovement;
    private Vector3 roadDestination;

    private void OnEnable() {
        SetDestination();
        GoMainRoad();
    }

    private void GoMainRoad() {
        transform.DORotate(new Vector3(0, 0, 0), 2f);
        transform.DOMove(roadDestination, 1f).OnComplete(EnableFollowMovement);
    }

    private void EnableFollowMovement() {
        selfMovement.enabled = true;
        this.enabled = false;
    }

    private void SetDestination() {
        if (transform.position.x > 0) {
            roadDestination = new Vector3
                (Random.Range(LevelBoundary.levelBoundaryRight, LevelBoundary.levelBoundaryRight - 2), transform.position.y,  transform.position.z - 3);
        } else if (transform.position.x < 0) {
            roadDestination = new Vector3
                (Random.Range(LevelBoundary.levelBoundaryLeft, LevelBoundary.levelBoundaryLeft + 2), transform.position.y, transform.position.z);
        }
    }
}
