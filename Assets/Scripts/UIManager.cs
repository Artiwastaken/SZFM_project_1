using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    GameManager gameManager;
    
    [SerializeField] TextMeshProUGUI starterText;
    [SerializeField] GameObject starterStartButton;
    [SerializeField] GameObject starterQuitButton;
   
    [SerializeField] GameObject player;
    
    [SerializeField] GameObject radioButtonLeft;
    [SerializeField] GameObject radioButtonRight;
    
    [SerializeField] TextMeshProUGUI biomText;
    [SerializeField] GameObject biom1;
    [SerializeField] GameObject biom2;
    
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject gameOverMenuButton;
    [SerializeField] GameObject gameOverRestartButton;
    [SerializeField] GameObject gameOverQuitButton;
    
    [SerializeField] TextMeshProUGUI pauseText;
    [SerializeField] GameObject pausequitButton;
    [SerializeField] GameObject pauseresumeButton;
    [SerializeField] GameObject pausemenuButton;
    [SerializeField] GameObject pauserestartButton;
   
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    ObstacleGenerator obstacleGenerator;
    
    //public bool isPaused = false;


    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        obstacleGenerator = GameObject.Find("Sensor").GetComponent<ObstacleGenerator>();
        
        gameManager.backGroundStop();
       
        EnableStarterUI();
       
        HidePlayer();
      
        DisableRadioUI();
        
        DisableScoreUI();
       
        DisableBiomUI();
       
        DisableGameOverUI();
       
        DisablePauseUI();
     
        UpdateUI();
        obstacleGenerator.DestroyAllEnemy();
        gameManager.isGameActive = false;
        gameManager.speed = 5;
        gameManager.score = 0;
        gameManager.isPaused = false;
        gameManager.playerAnimator.SetBool("alive", true);
        gameManager.backgroundScriptEnable();
    }

    public void BiomSelector()
    {
        
        DisableStarterUI();
        EnableBiomUI();
    }

    public void QuitApp()
    {
        gameManager.CheckHighScore();
        Debug.Log("Kilépés a játékból...");
        Application.Quit();
    }

    public void Selection()
    {
        gameManager.isGameActive = true;
        DisableBiomUI();
        ShowPlayer();
        EnableRadioUI();
        EnableScoreUI();
        gameManager.BackGroundStart();
    }

    //#################UIMANAGERRESZ##########################X

    public void DisableStarterUI()
    {
        starterText.gameObject.SetActive(false);
        starterStartButton.gameObject.SetActive(false);
        starterQuitButton.gameObject.SetActive(false);
    }
    public void EnableStarterUI()
    {
        starterText.gameObject.SetActive(true);
        starterStartButton.gameObject.SetActive(true);
        starterQuitButton.gameObject.SetActive(true);
    }


    public void HidePlayer()
    {
        player.gameObject.SetActive(false);
    }
    public void ShowPlayer()
    {
        player.gameObject.SetActive(true);
    }
    public void DisableRadioUI()
    {
        radioButtonLeft.gameObject.SetActive(false);
        radioButtonRight.gameObject.SetActive(false);
    }
    public void EnableRadioUI()
    {
        radioButtonLeft.gameObject.SetActive(true);
        radioButtonRight.gameObject.SetActive(true);
    }

    public void DisableBiomUI()
    {
        biomText.gameObject.SetActive(false);
        biom1.gameObject.SetActive(false);
        biom2.gameObject.SetActive(false);
    }
    public void EnableBiomUI()
    {
        biomText.gameObject.SetActive(true);
        biom1.gameObject.SetActive(true);
        biom2.gameObject.SetActive(true);
    }

    public void DisableGameOverUI()
    {
        gameOverText.gameObject.SetActive(false);
        gameOverRestartButton.gameObject.SetActive(false);
        gameOverMenuButton.gameObject.SetActive(false);
        gameOverQuitButton.gameObject.SetActive(false);
    }
    public void EnableGameOverUI()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverRestartButton.gameObject.SetActive(true);
        gameOverMenuButton.gameObject.SetActive(true);
        gameOverQuitButton.gameObject.SetActive(true);
    }

    public void DisablePauseUI()
    {
        pauseText.gameObject.SetActive(false);
        pausequitButton.gameObject.SetActive(false);
        pausemenuButton.gameObject.SetActive(false);
        pauseresumeButton.gameObject.SetActive(false);
        pauserestartButton.gameObject.SetActive(false);
    }
    public void EnablePauseUI()
    {
        pauseText.gameObject.SetActive(true);
        pausequitButton.gameObject.SetActive(true);
        pausemenuButton.gameObject.SetActive(true);
        pauseresumeButton.gameObject.SetActive(true);
        pauserestartButton.gameObject.SetActive(true);
    }

    public void DisableScoreUI()
    {
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }
    public void EnableScoreUI()
    {
        scoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
    }


    void Update()
    {
        gameManager.CheckHighScore();
        UpdateUI();
    }

    
    public void UpdateUI()
    {
        scoreText.SetText("Score: {0}", Mathf.FloorToInt(gameManager.score));
        highScoreText.SetText("Highscore: {0}", gameManager.highScore);
    }

    
}
