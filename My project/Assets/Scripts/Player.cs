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

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 10;
        grounded = false;
        spawnPoint = new Vector2(0,-2);
        transform.position = spawnPoint;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");

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
}
