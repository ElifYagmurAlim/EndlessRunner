using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gamerOverCanvas;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score = 0;
    public void StopGame(int score)
    {
        gamerOverCanvas.SetActive(true);
        this.score = score;
        scoreText.text = score.ToString();
        SubmitScore();
    }
    public void SubmitScore()
    {

    }
    public void AddXP(int score)
    {

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
