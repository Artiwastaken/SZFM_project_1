using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRB;
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKeyCode;
    [SerializeField] KeyCode duckKeyCode;
    [SerializeField] Vector2 boxSize;
    [SerializeField] Vector2 colliderBoxSize;
    [SerializeField] float castDistance;
    [SerializeField] float colliderHeight;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] BoxCollider2D playerBoxCollider;
    private Vector2 startColliderOffset;
    private Vector2 startColliderSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startColliderOffset = playerBoxCollider.offset;
        startColliderSize = playerBoxCollider.size;
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(jumpKeyCode) && isGrounded()) 
        {
            playerRB.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKey(duckKeyCode) && isGrounded())
        {
            playerBoxCollider.size = colliderBoxSize;
            playerBoxCollider.offset = new Vector2 (playerBoxCollider.offset.x,colliderHeight);

        }
        else
        {
            playerBoxCollider.size = startColliderSize;
            playerBoxCollider.offset = startColliderOffset;
        }
    }

    bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up*castDistance, boxSize);
        
    }
}
