using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    //[SerializeField] float speed = 5f;
    private Vector3 startPos;
    private float repeatWidth;
    GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPos = transform.position;
        repeatWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*gameManager.speed*Time.deltaTime);

        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
        
    }
}
