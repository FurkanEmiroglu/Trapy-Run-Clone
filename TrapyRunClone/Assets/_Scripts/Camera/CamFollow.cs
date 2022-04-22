using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // simple camera follow script.

    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _smoothSpeed;

    [SerializeField] private Vector3 _currentOffset, _currentRotation, _runningOffset, _runningRotation, _tackleOffset, _tackleRotation,
        _takeOffPosition, _takeOffRotation;

    private void Start() {
        GameEvents.Instance.onTackle += ChangeToTackleCam;
        GameEvents.Instance.onTakeOff += ChangeToTakeOffCam;
        ChangeToRunningCam();
    }

    private void OnDestroy() {
        GameEvents.Instance.onTackle -= ChangeToTackleCam;
        GameEvents.Instance.onTakeOff -= ChangeToTakeOffCam;
    }

    void Update()
    {
        Vector3 desiredPosition = _playerTransform.position + _currentOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        Quaternion desiredRotation = Quaternion.Euler(_currentRotation);
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, _smoothSpeed);

        transform.position = smoothedPosition;
        transform.rotation = smoothedRotation;
    }

    private void ChangeToRunningCam() {
        _currentOffset = _runningOffset;
        _currentRotation = _runningRotation;
    }

    private void ChangeToTackleCam() {
        _currentOffset = _tackleOffset;
        _currentRotation = _tackleRotation;
    }

    private void ChangeToTakeOffCam() {
        _currentOffset = _takeOffPosition;
        _currentRotation = _takeOffRotation;
    }
}
