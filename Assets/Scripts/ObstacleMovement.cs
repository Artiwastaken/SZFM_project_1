using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    UImanager uiManager;
    ObstacleGenerator oG;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oG = GameObject.Find("GameManager").GetComponent<ObstacleGenerator>();
        uiManager = GameObject.Find("Sensor").GetComponent<UImanager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Translate(Vector2.left * uiManager.speed * Time.deltaTime);
    }
}
