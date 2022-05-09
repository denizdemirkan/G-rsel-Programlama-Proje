using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public int enemyCount;
    public int enemyLeft;
    public float enemySpawnTimer;
    private float tempEnemySpawnTimer;
    public int enemyKilled = 0;
    private bool isGamePaused = false;
    private bool isPlayerDeath = false;
    private float deathTimer = 10f;

    // References
    GameObject playerObject;
    SoundHandler soundHandler;

    // Prefabs
    public GameObject playerPrefab;
    public List<GameObject> enemyPrefabs;
    
    
    public GameObject playerSpawnLocation;
    public GameObject enemySpawnLocation1;
    public GameObject enemySpawnLocation2;

    // Start is called before the first frame update
    void Start()
    {
        tempEnemySpawnTimer = enemySpawnTimer;
        GameObject playerObject = Instantiate(playerPrefab, playerSpawnLocation.transform);
        playerObject.GetComponent<DamageHandler>().gameHandler = this;
        soundHandler = gameObject.GetComponent<SoundHandler>();
        enemyLeft = enemyCount;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnTimer -= Time.deltaTime;
        if(enemySpawnTimer <= 0)
        {
            SpawnEnemy();
            enemySpawnTimer = tempEnemySpawnTimer;
        }

        if (Input.GetKeyDown("escape"))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (isPlayerDeath)
        {
            if (!soundHandler.deathSound.isPlaying)
            {
                soundHandler.DeathSound();
            }

            deathTimer -= Time.deltaTime;
            
            if (deathTimer <= 0)
            {
                SceneManager.LoadScene("MainUI");
            }
        }

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "Kalan düþman sayýsý: " + enemyLeft);
    }

    void SpawnEnemy()
    {
        int spawnLocationIndex = Random.Range(1, 3);
        int enemySelectionIndex = Random.Range(0, enemyPrefabs.Count);
        GameObject spawnLocation;

        if (spawnLocationIndex == 1)
        {
            spawnLocation = enemySpawnLocation1;
        }
        else
        {
            spawnLocation = enemySpawnLocation2;
        }

        if(enemyCount > 0 && enemySpawnTimer <= 0)
        {
            GameObject tempEnemy = Instantiate(enemyPrefabs[enemySelectionIndex]);
            tempEnemy.GetComponent<DamageHandler>().gameHandler = this;
            enemyCount--;
        }
    }

    public void CheckEnemyLeft()
    {
        enemyLeft -= 1;
        if (enemyLeft == 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if(currentScene.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (currentScene.name == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
            else
            {
                SceneManager.LoadScene("TheEnd");
            }

        }
    }

    public void PlayerDie()
    {
        isPlayerDeath = true;
    }


    void PauseGame() 
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }
}
