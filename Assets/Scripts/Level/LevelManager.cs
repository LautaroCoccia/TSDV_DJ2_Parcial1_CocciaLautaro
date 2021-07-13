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
    [SerializeField] int brickWallsLeft = 0;
    [SerializeField] int chanceOfDoorSpawn = 100;
    [SerializeField] List<GameObject> itemList;
    [SerializeField] int chanceToSpawnItem = 50;


    [SerializeField] private TextMeshProUGUI UIHealth;
    [SerializeField] private TextMeshProUGUI UIScore;
    [SerializeField] private TextMeshProUGUI UIEnemies;
    [SerializeField] private TextMeshProUGUI UITime;
    [SerializeField] private TextMeshProUGUI UICantBombs;
    [SerializeField] private TextMeshProUGUI UIDistBombs;
    [SerializeField] private TextMeshProUGUI UIExtras;

    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject QuitMenuUI;
    [SerializeField] private GameObject GameOverMenuUI;

    [SerializeField] private bool doorExists = false;
    [SerializeField] private bool doorActive = false;
    private static bool pause = false;
    private static LevelManager _instanceLevelManager;
    private const int minLives = 1;
    private float time = 0;
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
    private void Start()
    {
        Time.timeScale = 1;
        UIHealth.text = ("Lives: " + lives);
        UIEnemies.text = ("Left: " + enemiesLeft);
    }
    private void Update()
    {
        if (Time.timeScale > 0)
        {
            time += Time.deltaTime;
            SetTimeUI();
        }
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
        if (enemiesLeft == 0)
        {
            doorActive = true;
        }
        UIEnemies.text = ("Left: " + enemiesLeft);
    }
    public void UpdateScore(int SCORE)
    {
        score += SCORE;
        UIScore.text = ("Score: " + score);
    }
    public void UpdateHealth()
    {
        if(lives>0)
        {
            lives--;
            UpdateLivesUI();
        }
        else if (lives < minLives)
        {
            GameOver();
        }
    }
    private void UpdateLivesUI()
    {
        UIHealth.text = ("Lives: " + lives);
    }
    private void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
    public void GameOver()
    {
        SetTimeScale(0);
        SetExtras();
        GameOverMenuUI.SetActive(true);
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
    public void setActiveDoor()
    {
        doorActive = !doorActive;
    }
    public bool GetIsActiveDoor()
    {
        return doorActive;
    }
    public void setDoorExists()
    {
        doorExists = !doorExists;
    }
    public bool GetDoorExists()
    {
        return doorExists;
    }
    public int GetChanceOfDoorSpawn()
    {
        return chanceOfDoorSpawn;
    }
    public void SetBrickWall()
    {
        brickWallsLeft++;
    }
    public void UpdateBrickWall()
    {
        brickWallsLeft--;
    }
    public int GetBrickWallLeft()
    {
        return brickWallsLeft;
    }
    public void OneLiveUp()
    {
        lives++;
        UpdateLivesUI();
    }
    public List<GameObject> GetItemList()
    {
        return itemList;
    }
    public int GetChanceToSpawnItem()
    {
        return chanceToSpawnItem;
    }
    void SetTimeUI()
    {
        UITime.text = ("Time: " + Mathf.Round(time));
    }
    public void SetBombRangeUI(int range)
    {
        UIDistBombs.text = ("Dist bombs: " + range);
    }
    public void SetBombCantUI(int cant)
    {
        UICantBombs.text = ("Cant bombs: " + cant);
    }
    void SetExtras()
    {
        UIExtras.text = (UIHealth.text + "\n" +
            UIScore.text + "\n" + 
            UIEnemies.text + "\n" +
            UITime.text + "\n" +
            UICantBombs.text + "\n" +
            UIDistBombs.text + "\n");
    }
}