using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] forestObstacleList;
    [SerializeField] GameObject[] desertObstacleList;
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (gameManager.isForest)
        {

        }
        else
        {

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
