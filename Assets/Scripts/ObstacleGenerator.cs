using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] forestObstacleList;
    [SerializeField] GameObject[] desertObstacleList;
    UImanager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = GameObject.Find("Sensor").GetComponent<UImanager>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (uiManager.isForest)
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
