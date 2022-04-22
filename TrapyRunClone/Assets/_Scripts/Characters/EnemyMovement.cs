using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // This scripts makes enemies follow our player, when triggers tackle event if enemy character near enough

    private Transform _targetTransform;
    [SerializeField] float enemyForwardSpeed;
    [SerializeField] float enemyDiagonalSpeed;

    private void Start() {
        GameEvents.Instance.onTackle += StopMoving;
        GameEvents.Instance.onTakeOff += StopMoving;
        GameEvents.Instance.onLevelEnding += StopMoving;
        _targetTransform = ObjectHolder.Instance._playerTransform;
    }

    private void OnDisable() {
        GameEvents.Instance.onTackle -= StopMoving;
        GameEvents.Instance.onLevelEnding -= StopMoving;
    }

    void Update()
    {
        if (_targetTransform.position.z - transform.position.z > 1) {
            var zUpdatedPosition = new Vector3(transform.position.x, transform.position.y, _targetTransform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, zUpdatedPosition, Time.deltaTime * enemyForwardSpeed);
        }
        else if (Vector3.Distance(transform.position, _targetTransform.position) > 1) {
            transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, Time.deltaTime * enemyDiagonalSpeed);
            transform.LookAt(_targetTransform);
        }
        else if (Vector3.Distance(transform.position, _targetTransform.position) < 1) {
            GameEvents.Instance.Tackle();
        }
    }

    private void StopMoving() {
        enabled = false;
    }
}
