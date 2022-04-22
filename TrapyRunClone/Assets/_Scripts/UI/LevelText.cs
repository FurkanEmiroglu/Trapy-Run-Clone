using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _uiText;
    private int levelNumber;

    private void Start() {
        levelNumber = PlayerPrefs.GetInt("playerLevel", 1);
        _uiText.text = "Level " + levelNumber;
    }

    
}
