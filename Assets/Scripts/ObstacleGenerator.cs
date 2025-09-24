using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] forestObstacleList;
    [SerializeField] GameObject[] desertObstacleList;
    GameManager gameManager;
    Vector2 spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnPoint = new Vector2(12,-3);
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        Destroy(collision.gameObject);
        if (gameManager.isForest)
        {
            SpawnForestObstacle();
        }
        else
        {
            //SpawnForestObstacle();
        }
       
    }
    
    public void SpawnForestObstacle()
    {
        int random = Random.Range(0, forestObstacleList.Length);
        Instantiate(forestObstacleList[random], spawnPoint, transform.rotation);//.AddComponent<ObstacleMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
