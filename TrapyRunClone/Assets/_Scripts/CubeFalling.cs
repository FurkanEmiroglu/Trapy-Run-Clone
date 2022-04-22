using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeFalling : MonoBehaviour
{
    // this script makes itself fall if player choses to move above them

    [SerializeField] MeshRenderer _mRenderer;                               // For changing the color
    [SerializeField] BoxCollider _fallingTriggerCollider;                   // When player paints the cube, fallingTrigger becomes active

    private Color32 fallingFinalColor = new Color32(190, 61, 61, 255);
    private Vector3 fallingDestination;

    private void Start() {
        fallingDestination = new Vector3(transform.localPosition.x, -10, transform.localPosition.z);
    }


    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            ChangeColor();
            FallDown();
        }
    }

    private void FallDown() {
        transform.DOLocalMove(fallingDestination, 2f).OnComplete(() => gameObject.SetActive(false)).SetEase(Ease.InOutSine);
    }

    private void ChangeColor() {
        _mRenderer.material.DOColor(fallingFinalColor, .75f);
        _fallingTriggerCollider.enabled = true;
    }
}
