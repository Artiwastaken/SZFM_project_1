using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRB;
    [SerializeField] float jumpForce;
    [SerializeField] float fallForce;
    [SerializeField] KeyCode jumpKeyCode;
    [SerializeField] KeyCode duckKeyCode;
    [SerializeField] KeyCode fallKeyCode;
    [SerializeField] Vector2 boxSize;
    [SerializeField] Vector2 colliderBoxSize;
    [SerializeField] float castDistance;
    [SerializeField] float colliderHeight;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] BoxCollider2D playerBoxCollider;
    private Vector2 startColliderOffset;
    private Vector2 startColliderSize;
    public Animator playerAnimator;
    public Vector2 playerStartPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startColliderOffset = playerBoxCollider.offset;
        startColliderSize = playerBoxCollider.size;
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerStartPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isGrounded() &&  !Input.GetKey(jumpKeyCode))
        {
            playerAnimator.SetBool("jump", false);
        }
        if (Input.GetKey(fallKeyCode) && isGrounded()==false)
        {
            playerRB.AddForce(-Vector2.up * fallForce, ForceMode2D.Impulse);
            
        }
        if (Input.GetKeyDown(jumpKeyCode) && isGrounded()) 
        {
            playerAnimator.SetBool("jump", true);
            playerRB.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
        
        if (Input.GetKey(duckKeyCode) && isGrounded())
        {
            playerAnimator.SetBool("duck", true);
            playerBoxCollider.size = colliderBoxSize;
            playerBoxCollider.offset = new Vector2 (playerBoxCollider.offset.x,colliderHeight);

        }
        else
        {
            playerAnimator.SetBool("duck", false);
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
