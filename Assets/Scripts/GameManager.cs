using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    int gamePoints;

    private void Start() {
        gamePoints = 0;
    }

    public void PlayerDead() {
        StartCoroutine(PanelShow());
    }

    IEnumerator PanelShow() {
        yield return new WaitForSeconds(0.15f);
        Debug.Log("DEAD! GAME OVER");
        gameOverPanel.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddPoints() {
        Debug.Log("Current point: " + ++gamePoints);
    }


}
