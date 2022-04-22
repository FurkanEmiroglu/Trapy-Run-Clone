using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HelicopterHandler : MonoBehaviour
{
    [SerializeField] Transform _mainRotorTransform;
    [SerializeField] Transform _backRotorTransform;
    private float _rotationSpeed;
    private const float _maxRotationSpeed = 2000f;
    private bool _isRotating = false;
    private bool _takeOffStarted = false;

    private void Start() {
        GameEvents.Instance.onLevelEnding += EnableRotation;
        GameEvents.Instance.onTakeOff += TakeOff;
        DisableRotation();
    }

    private void OnDestroy() {
        GameEvents.Instance.onLevelEnding -= EnableRotation;
        GameEvents.Instance.onTakeOff -= TakeOff;
    }


    private void Update() {
        if (_isRotating) {
            RotateRotor();
        }
    }

    private void RotateRotor() {
        _mainRotorTransform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
        _backRotorTransform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0);
        if (_rotationSpeed < _maxRotationSpeed) {
            _rotationSpeed += 12.5f;
        } else {
            // rotors are rotating at maximum speed
            // ready to takeoff
            if (!_takeOffStarted) {
                GameEvents.Instance.TakeOff();

                // we need to set this event only for once
                _takeOffStarted = true;
            }

        }
    }

    private void TakeOff() {
        transform.DOLocalMove(new Vector3(20, 15, 10), 5f);
        transform.DOLocalRotate(new Vector3(0, 0, -25), 5f);
    }

    private void EnableRotation() {
        enabled = true;
        _isRotating = true;
    }

    private void DisableRotation() {
        enabled = false;
        _isRotating = false;
    }
}
