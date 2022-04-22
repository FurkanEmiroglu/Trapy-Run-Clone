using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public Transform _playerTransform;



    public static ObjectHolder Instance;

    private void Awake() {
        Instance = this;
    }
}
