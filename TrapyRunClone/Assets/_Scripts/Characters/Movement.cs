using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _swipeSpeed;
    [SerializeField] Rigidbody _rb;
    [SerializeField] BoxCollider _thisCollider;
    
    private float horizontalPosition;
    private Vector3 desiredPosition;

    private void Start() {
        GameEvents.Instance.onTackle += StopMoving;
        GameEvents.Instance.onLevelEnding += StopMoving;
        GameEvents.Instance.onLevelEnding += DisableRigidbodyConstraints;
        GameEvents.Instance.onTackle += DisableCollider;
        GameEvents.Instance.onFalling += EnableFallingConstraints;
    }

    private void OnDisable() {
        GameEvents.Instance.onTackle -= StopMoving;
        GameEvents.Instance.onTackle -= DisableCollider;
        GameEvents.Instance.onLevelEnding -= StopMoving;
        GameEvents.Instance.onLevelEnding -= DisableRigidbodyConstraints;
        GameEvents.Instance.onFalling -= EnableFallingConstraints;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);                                                 // moving forward all the time

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            horizontalPosition = transform.position.x + touch.deltaPosition.x * _swipeSpeed * Time.deltaTime;
            if (horizontalPosition > LevelBoundary.levelBoundaryLeft && horizontalPosition < LevelBoundary.levelBoundaryRight) { // check levelboundaries
                desiredPosition = new Vector3(horizontalPosition, transform.position.y, transform.position.z);                   
                transform.position = Vector3.MoveTowards(transform.position, desiredPosition, .2f);                              // moving to desiredPos
            }
        }
    }

    private void StopMoving() {
        enabled = false;
    }

    private void DisableRigidbodyConstraints() {
        _rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
    }

    private void EnableFallingConstraints() {
        _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
    
    private void DisableCollider() {
        _thisCollider.enabled = false;
    }
}
