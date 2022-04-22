using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelEndingTrigger : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _helicopter;

    private void Start() {
        GameEvents.Instance.onLevelEnding += GoHelicopter;
    }

    private void OnDisable() {
        GameEvents.Instance.onLevelEnding -= GoHelicopter;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GameEvents.Instance.LevelEnd();
        }
    }

    private void GoHelicopter() {
        _playerTransform.SetParent(_helicopter);
        _playerTransform.DOLocalJump(new Vector3(0,1,0),1, 1, 1.5f);
        _playerTransform.DOLocalRotate(new Vector3(0, 180, 0), 1.5f);
    }
}
