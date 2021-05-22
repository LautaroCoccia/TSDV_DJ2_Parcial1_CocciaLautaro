using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;
    [SerializeField] int enemiesLeft = 0;

    [SerializeField] private TextMeshProUGUI UIScore;
    [SerializeField] private TextMeshProUGUI UIHealth;
    [SerializeField] private TextMeshProUGUI UIEnemies;
    [SerializeField] private TextMeshProUGUI UIExtras;
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject QuitMenuUI;
    [SerializeField] private GameObject GameOverMenuUI;

    private static bool pause = false;
    private static LevelManager _instanceLevelManager;
    private const int minLives = 1;
    public static LevelManager Get()
    {
        return _instanceLevelManager;
    }
    private void Awake()
    {
        if (_instanceLevelManager == null)
        {
            _instanceLevelManager = this;
        }
        else if (_instanceLevelManager != this)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }
    public void StartEnemies()
    {
        enemiesLeft++;
    }
    public void UpdateEnemies()
    {
        enemiesLeft--;
        UIEnemies.text = ("ENEMIES LEFT: " + enemiesLeft);
    }
    public void UpdateScore(int SCORE)
    {
        score += SCORE;
        UIScore.text = ("SCORE: " + score);
    }
    public void UpdateHealth()
    {
        lives--;
        if(lives< minLives)
        {
            GameOver();
        }
        UIHealth.text = ("HEALTH: " + lives);
    }
    private void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
    private void GameOver()
    {
        SetTimeScale(0);
        GameOverMenuUI.SetActive(true);
        //if (player.GetScore() > GameManager.Get().Highscore)
        //{
        //    UIExtras.text = ("HEALTH " + player.GetHealth() + "\n"
        //        + ("NEW RECORD: " + "\n"
        //        + ("SCORE: " + player.GetScore())));
        //}
        //else
        //{
        //    UIExtras.text = ("HEALTH " + player.GetHealth() + "\n" +
        //        ("SCORE: " + player.GetScore()) +
        //        ("HIGHSCORE" + GameManager.Get().Highscore));
        //}

    }
    public void SetPause()
    {
        pause = !pause;
        if (pause)
        {
            SetTimeScale(0);
            PauseMenuUI.SetActive(pause);
        }
        else
        {
            SetTimeScale(1);
            PauseMenuUI.SetActive(pause);
            QuitMenuUI.SetActive(pause);
        }
    }
}
