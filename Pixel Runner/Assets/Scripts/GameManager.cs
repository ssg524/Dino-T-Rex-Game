using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI hiScoreText;

    [SerializeField]
    private GameObject scorePanel;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject gameOverPanel;

    public int score = 0;
    public int hiScore = 0;
    public bool isGameOver = false;
    public bool isPlay = false;

    void Awake() {
        if (instance == null)
            instance = this;
        
        Time.timeScale = 0;
        hiScore = PlayerPrefs.GetInt("HISCORE");
        hiScoreText.SetText(string.Format("{0:D5}", hiScore));
    }
     
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isPlay) {
            Time.timeScale = 1;
            isPlay = true;
            Play();
        }
    }

    void Play()
    {
        mainPanel.SetActive(false);
        StartCoroutine("IncreaseScore");
    }

    IEnumerator IncreaseScore()
    {
        while (isPlay) {
            yield return new WaitForSeconds(0.1f);
            score += 1;
            scoreText.SetText(string.Format("{0:D5}", score));
        }
    }

    public void SetGameOver()
    {
        StopCoroutine("IncreaseScore");

        if (hiScore < score) {
            hiScore = score;
            PlayerPrefs.SetInt("HISCORE", hiScore);
            hiScoreText.SetText(string.Format("{0:D5}", score));
        }
        gameOverPanel.SetActive(true);
        new WaitForSeconds(0.1f);
        Time.timeScale = 0;
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
