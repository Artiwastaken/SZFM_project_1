using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    GameManager gameManager;
    ObstacleGenerator oG;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oG = GameObject.Find("GameManager").GetComponent<ObstacleGenerator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            gameObject.transform.Translate(Vector2.left * gameManager.speed * Time.deltaTime);
        }
    }
}
