using System.Collections;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class GameManager : MonoBehaviour
{
    public float score;
    public int highScore;
    public float speed;
    public bool isForest = false;
    UImanager uiManager;
    public bool isPaused = false;
    private ObstacleGenerator obstacleGenerator;
    public bool isGameActive;
    public Animator playerAnimator;
    public BackgroundManager backgroundManagerScript;   
    
    [SerializeField] GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //backgroundManagerScript = GameObject.Find("Background").GetComponent<BackgroundManager>();
        obstacleGenerator = GameObject.Find("Sensor").GetComponent<ObstacleGenerator>();
        uiManager = GameObject.Find("UiManager").GetComponent<UImanager>();
        score = 0f;
        backGroundStop();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        speed = 5;
        isGameActive = false;
        StartCoroutine(IncreasingSpeed());
    }


    // SCORERESZ ###########################################################
    public void ScoreUpdater()
    {
        score += Time.deltaTime * 10f;
    }
    public void CheckHighScore()
    {
        int roundedScore = Mathf.FloorToInt(score);
        if (roundedScore > highScore)
        {
            highScore = roundedScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
    // SELECTIONRESZ ####################################################
    public void ForestSelector()
    {
        
        uiManager.Selection();
        isForest = true;
        obstacleGenerator.SpawnForestObstacle();
        backgroundManagerScript.BackGroundForest();
    }

    public void DesertSelector()
    {
        
        uiManager.Selection();
        isForest = false;
        obstacleGenerator.SpawnDesertObstacle();
        backgroundManagerScript.BackGroundCave();
    }

    // JATEKMENET RESZ ##########################################

    IEnumerator IncreasingSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (isGameActive) 
            { 
                speed += 1.5f;
            }
        }
    }

    public void RestartGame()
    {
        CheckHighScore();
        score = 0;
        uiManager.DisableBiomUI();
        uiManager.DisableGameOverUI();
        uiManager.DisablePauseUI();
        isPaused = false;
        BackGroundStart();
        uiManager.UpdateUI();
        obstacleGenerator.DestroyAllEnemy();
        if (isForest)
        {
            obstacleGenerator.SpawnForestObstacle();
        }
        else
        {
            obstacleGenerator.SpawnDesertObstacle();
        }
        speed = 5;
        isGameActive = true;
        player.transform.position= new Vector2(-7.11f, -2.67f);
        playerAnimator.SetBool("alive", true);
        backgroundScriptEnable();
    }

    public void GameOver()
    {
        
        CheckHighScore();
        uiManager.EnableGameOverUI();
        isGameActive = false;
        playerAnimator.SetBool("alive",false);
        backgroundScriptDisable();
    }

    public void Resume()
    {
        isPaused = false;
        uiManager.DisablePauseUI();
        BackGroundStart();
        isGameActive = true;
    }

    public void Pause()
    {
        isGameActive = false;
        CheckHighScore();
        isPaused = true;
        uiManager.EnablePauseUI();
        backGroundStop();
    }

    public void backgroundScriptDisable()
    {
        backgroundManagerScript.enabled = false;
    }
    public void backgroundScriptEnable()
    {
        backgroundManagerScript.enabled = true;
    }

    public void backGroundStop()
    {
        Time.timeScale = 0f;

    }

    public void BackGroundStart()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            ScoreUpdater();
        }
        uiManager.UpdateUI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) { Resume(); }
            else Pause();
        }

    }
}
