using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;              // We need this to be a singleton. We'll use observer pattern to manage our game.

    #region Singleton
    private void Awake() {
        Instance = this;
    }
    #endregion

    #region In Game Events

    public event Action onGameOver;

    public void GameOver() {
        if (onGameOver != null) {
            onGameOver.Invoke();
            Debug.Log("GameOver Triggered");
        }
    }

    public event Action onTackle;
    public void Tackle() {
        if (onTackle != null) {
        onTackle.Invoke();
        }
    }

    public event Action onLevelEnding;

    public void LevelEnd() {
        if (onLevelEnding != null) {
        onLevelEnding.Invoke();
        }
    }

    public event Action onTakeOff;
    // ToDo oncomplete levelcomplete canvas açılacak on takeoff subscribe edilecekler.

    public void TakeOff() {
        if (onTakeOff != null) {
        onTakeOff.Invoke();
        }
    }

    public event Action onFalling;

    public void Falling() {
        if (onFalling != null) {
            onFalling.Invoke();
        }
    }

    public event Action onPauseGame;

    public void PauseGame() {
        if (onPauseGame != null) {
        Time.timeScale = 0;
        Debug.Log("Pause Game Triggered");
        }
    }

    #endregion

    #region SceneManagement

    public void LoadNextLevel() {
        var activeBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetSceneByBuildIndex(activeBuildIndex + 1) != null) {
            SceneManager.LoadScene(activeBuildIndex + 1);
        } else {
            SceneManager.LoadScene(0);
        }
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion
}
