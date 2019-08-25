using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text pointsLabel;
    public Text resultPointsLabel;
    public Text bestPointsLabel;

    int gamePoints;

    private void Start() {
        gamePoints = 0;
        bestPointsLabel.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void PlayerDead() {
        StartCoroutine(PanelShow());
    }

    IEnumerator PanelShow() {
        yield return new WaitForSeconds(0.15f);
        Debug.Log("DEAD! GAME OVER");
        gameOverPanel.SetActive(true);
        pointsLabel.enabled = false;
        resultPointsLabel.text = gamePoints.ToString();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetPoints() {
        pointsLabel.text = gamePoints.ToString();
    }

    public void AddPoints(int points) {
        gamePoints += points;
        if(gamePoints > PlayerPrefs.GetInt("BestScore", 0)) {
            PlayerPrefs.SetInt("BestScore", gamePoints);
            bestPointsLabel.text = gamePoints.ToString();
        }
        SetPoints();
        Debug.Log("Current point: " + gamePoints);
    }


}
