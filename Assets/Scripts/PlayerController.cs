using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRB;
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKeyCode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKeyCode)) 
        {
            playerRB.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }
}
