using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    int score = 0;
    int highScore;
    public static bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        highScoreText.SetText("HighScore: " + LoadHighScore().ToString());

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

        score = 0;
        isPaused = false;

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
        StartCoroutine(AddScore());
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
        /*
        biomText.gameObject.SetActive(false);
        biom1.gameObject.SetActive(false);
        biom2.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverRestartButton.gameObject.SetActive(false);
        score = 0;
        pauseText.gameObject.SetActive(false);
        gameOverQuitButton.gameObject.SetActive(false);
        gameOverMenuButton.gameObject.SetActive(false);
        pausemenuButton.gameObject.SetActive(false);
        pauseresumeButton.gameObject.SetActive(false);
        pauserestartButton.gameObject.SetActive(false);
        pausequitButton.gameObject.SetActive(false);
        isPaused = false;
        StartCoroutine(AddScore());
        BackGroundStart();
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void GameOver() 
    {
        backGroundStop();
        gameOverText.gameObject.SetActive(true);
        gameOverRestartButton.gameObject.SetActive(true);
        StopAllCoroutines();
        gameOverMenuButton.gameObject.SetActive(true);
        gameOverQuitButton.gameObject.SetActive(true);
        SaveHighScore(score);

    }

    IEnumerator AddScore()
    {
        while (true)
        {
            score += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SaveHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score:{0}", score);
        //highScoreText.SetText("Highscore: {0}", highScore);
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
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
        StartCoroutine(AddScore());
        BackGroundStart();


    }

    void Pause()
    {
        isPaused = true;
        pauserestartButton.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
        pausequitButton.gameObject.SetActive(true);
        pausemenuButton.gameObject.SetActive(true);
        pauseresumeButton.gameObject.SetActive(true);
        StopAllCoroutines();
        backGroundStop();
        

    }

    private void backGroundStop() {
        //player.GetComponent<PlayerController>().enabled = false;
        //background.GetComponent<BackgroundManager>().enabled = false;
        Time.timeScale = 0;
    }
    private void BackGroundStart() {
        //player.GetComponent<PlayerController>().enabled = true;
        //background.GetComponent<BackgroundManager>().enabled = true;
        Time.timeScale = 1;
    }

}
