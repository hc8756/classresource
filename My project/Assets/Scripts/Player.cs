using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    public float speed;
    private bool grounded;
    public GameObject manager;
    private Vector2 spawnPoint;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private float horizontalAxis;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 10;
        grounded = false;
        spawnPoint = new Vector2(0,-2);
        transform.position = spawnPoint;
<<<<<<< Updated upstream
=======
        Time.timeScale = 1;
        boxCollider = GetComponent<BoxCollider2D>();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalAxis*speed, body.velocity.y);
        if (horizontalAxis > 0.0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalAxis < 0.0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
        animator.SetBool("Walking", horizontalAxis!=0);
        animator.SetBool("Grounded", grounded);
        if (transform.position.y < -10) {
            transform.position = spawnPoint;
            manager.GetComponent<Manager>().lives--;
        }
    }

    void Jump() {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            manager.GetComponent<Manager>().gameOver(true);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            manager.GetComponent<Manager>().lives--;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down,0.1f,groundLayer);
        return raycastHit2D;
    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f,wallLayer);
        return raycastHit;
    }
    public bool canAttack()
    {
        return horizontalAxis == 0 && isGrounded() && !OnWall();
    }
}   
