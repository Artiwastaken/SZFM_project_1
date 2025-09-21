using TMPro;
using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private GameObject background;
    private GameObject ground;
    [SerializeField] TextMeshProUGUI starterText;
    [SerializeField] GameObject starterButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject player;
    [SerializeField] GameObject radioButtonLeft;
    [SerializeField] GameObject radioButtonRight;
    [SerializeField] TextMeshProUGUI biomText;
    [SerializeField] GameObject biom1;
    [SerializeField] GameObject biom2;
    [SerializeField] TextMeshProUGUI restartText;
    [SerializeField] GameObject restartButton;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    int score;
    int highScore;
    public static bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        background = GameObject.FindWithTag("BackGround");

        player.GetComponent<PlayerController>().enabled = false;
        background.GetComponent<BackgroundManager>().enabled = false;

        starterButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        radioButtonLeft.gameObject.SetActive(false);
        radioButtonRight.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        biomText.gameObject.SetActive(false);
        biom1.gameObject.SetActive(false);
        biom2.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

    }

    public void BiomSelector()
    {
        starterButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        starterText.gameObject.SetActive(false);
        biomText.gameObject.SetActive(true);
        biom1.gameObject.SetActive(true);
        biom2.gameObject.SetActive(true);
    }

    public void QuitApp()
    {
        Debug.Log("Kilépés a játékból..."); // Csak fejlesztés közben látszik
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
        player.GetComponent<PlayerController>().enabled = true;
        background.GetComponent<BackgroundManager>().enabled = true;
        StartCoroutine(AddScore());
        scoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
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
        biomText.gameObject.SetActive(true);
        biom1.gameObject.SetActive(true);
        biom2.gameObject.SetActive(true);
        restartText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        score = 0;

    }

    void GameOver() 
    {
        player.GetComponent<PlayerController>().enabled = false;
        background.GetComponent<BackgroundManager>().enabled = false;
        restartText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        StopAllCoroutines();
    }

    IEnumerator AddScore()
    {
        while (true)
        {
            score += 15;
            yield return new WaitForSeconds(0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score:{0}", score);
        highScoreText.SetText("Highscore: {0}", highScore);
        if (score > highScore)
        {
            highScore = score;

        }

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
        
        Time.timeScale = 1f;          // Játék folytatódik
        isPaused = false;
    }

    void Pause()
    {
        
        Time.timeScale = 0f;         // Játék megáll
        isPaused = true;

    }
    
}
