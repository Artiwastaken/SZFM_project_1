using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    //[SerializeField] float speed = 5f;
    private Vector3 startPos;
    private float repeatWidth;
    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite caveBackGround;
    [SerializeField] Sprite forestBackGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPos = transform.position;
        repeatWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }
    public void BackGroundCave()
    {
        spriteRenderer.sprite = caveBackGround;
    }
    public void BackGroundForest()
    {
        spriteRenderer.sprite = forestBackGround;
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
