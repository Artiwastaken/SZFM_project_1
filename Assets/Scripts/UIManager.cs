using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private GameObject background;
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

    float score;
    int highScore;
    public static bool isPaused = false;

    public void Start()
    {
        background = GameObject.FindWithTag("BackGround");
        backGroundStop();
        starterText.gameObject.SetActive(true);
        starterStartButton.gameObject.SetActive(true);
        starterQuitButton.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        radioButtonLeft.gameObject.SetActive(false);
        radioButtonRight.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        biomText.gameObject.SetActive(false);
        biom1.gameObject.SetActive(false);
        biom2.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverRestartButton.gameObject.SetActive(false);
        gameOverMenuButton.gameObject.SetActive(false);
        gameOverQuitButton.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        pausequitButton.gameObject.SetActive(false);
        pausemenuButton.gameObject.SetActive(false);
        pauseresumeButton.gameObject.SetActive(false);
        pauserestartButton.gameObject.SetActive(false);
        score = 0f;
        isPaused = false;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void BiomSelector()
    {
        starterStartButton.gameObject.SetActive(false);
        starterQuitButton.gameObject.SetActive(false);
        starterText.gameObject.SetActive(false);
        biomText.gameObject.SetActive(true);
        biom1.gameObject.SetActive(true);
        biom2.gameObject.SetActive(true);
    }

    public void QuitApp()
    {
        CheckHighScore();
        Debug.Log("Kilépés a játékból...");
        Application.Quit();
    }

    private void Selection()
    {
        biomText.gameObject.SetActive(false);
        biom1.gameObject.SetActive(false);
        biom2.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        radioButtonLeft.gameObject.SetActive(true);
        radioButtonRight.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        BackGroundStart();
    }
    public void ForestSelector()
    {
        Selection();
    }

    public void DesertSelector()
    {
        Selection();
    }

    public void RestartGame()
    {
        CheckHighScore();
        score = 0;
        biomText.gameObject.SetActive(false);
        biom1.gameObject.SetActive(false);
        biom2.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverRestartButton.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        gameOverQuitButton.gameObject.SetActive(false);
        gameOverMenuButton.gameObject.SetActive(false);
        pausemenuButton.gameObject.SetActive(false);
        pauseresumeButton.gameObject.SetActive(false);
        pauserestartButton.gameObject.SetActive(false);
        pausequitButton.gameObject.SetActive(false);
        isPaused = false;
        BackGroundStart();
        UpdateUI();
    }

    void GameOver()
    {
        backGroundStop();
        CheckHighScore();

        gameOverText.gameObject.SetActive(true);
        gameOverRestartButton.gameObject.SetActive(true);
        StopAllCoroutines();
        gameOverMenuButton.gameObject.SetActive(true);
        gameOverQuitButton.gameObject.SetActive(true);
    }


    void Update()
    {
        score += Time.deltaTime * 10f;
        CheckHighScore();
        UpdateUI();

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


    public void Resume()
    {
        isPaused = false;
        pauserestartButton.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        pausequitButton.gameObject.SetActive(false);
        pausemenuButton.gameObject.SetActive(false);
        pauseresumeButton.gameObject.SetActive(false);
        BackGroundStart();
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

    void UpdateUI()
    {
        scoreText.SetText("Score: {0}", Mathf.FloorToInt(score));
        highScoreText.SetText("Highscore: {0}", highScore);
    }

    void Pause()
    {
        CheckHighScore();
        isPaused = true;
        pauserestartButton.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
        pausequitButton.gameObject.SetActive(true);
        pausemenuButton.gameObject.SetActive(true);
        pauseresumeButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void backGroundStop()
    {
        Time.timeScale = 0f;
    }

    private void BackGroundStart()
    {
        Time.timeScale = 1f;
    }
}
