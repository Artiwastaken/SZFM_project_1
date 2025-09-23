using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class GameManager : MonoBehaviour
{
    public float score;
    public int highScore;
    public float speed;
    public bool isForest = false;
    UImanager uiManager;
    bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = GameObject.Find("UiManager").GetComponent<UImanager>();
        score = 0f;
        backGroundStop();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        speed = 5;
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

    }

    public void DesertSelector()
    {
        uiManager.Selection();
        isForest = false;
    }

    // JATEKMENET RESZ ##########################################

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
    }

    public void GameOver()
    {
        backGroundStop();
        CheckHighScore();
        uiManager.EnableGameOverUI();
        StopAllCoroutines();
       
    }

    public void Resume()
    {
        isPaused = false;
        uiManager.DisablePauseUI();
        BackGroundStart();
    }

    public void Pause()
    {
        CheckHighScore();
        isPaused = true;
        uiManager.EnablePauseUI();
        backGroundStop();
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
        ScoreUpdater();
        uiManager.UpdateUI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameOver();
        }

    }
}
