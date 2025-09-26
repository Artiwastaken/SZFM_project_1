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
        spawnPoint = new Vector2(12, -2.2f);
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if (gameManager.isForest)
            {
                SpawnForestObstacle();
            }
            else
            {
                SpawnDesertObstacle();
            }
        }
    }

    public void SpawnForestObstacle()
    {
        int random = Random.Range(0, forestObstacleList.Length);
        float randomSpawnPoint = Random.Range(-2f, -1f);
        if (random == 0)
        {
            Instantiate(forestObstacleList[0], new Vector2(12,randomSpawnPoint), transform.rotation);
        }
        else
        {
            Instantiate(forestObstacleList[random], spawnPoint, transform.rotation);
        }
        
    }

    public void SpawnDesertObstacle()
    {
        int random = Random.Range(0, desertObstacleList.Length);
        float randomSpawnPoint = Random.Range(-2f, -1f);
        if (random == 0)
        {
            Instantiate(desertObstacleList[0], new Vector2(12, randomSpawnPoint), transform.rotation);
        }
        else
        {
            Instantiate(desertObstacleList[random], spawnPoint, transform.rotation);
        }

    }
    
    public void DestroyAllEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
        
    }

}
