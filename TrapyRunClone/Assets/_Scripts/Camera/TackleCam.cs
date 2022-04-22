using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackleCam : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _offset;
    private Vector3 desiredLocation;
    [SerializeField] private float _smoothSpeed = .125f;

    private void Start() {
        GameEvents.Instance.onTackle += EnableTackleCam;
        enabled = false;
    }

    private void OnDestroy() {
        GameEvents.Instance.onTackle -= EnableTackleCam;
    }

    private void Update() {
        Vector3 desiredPosition = transform.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(_playerTransform);
    }


    private void EnableTackleCam() {
        enabled = true;
    }
}
