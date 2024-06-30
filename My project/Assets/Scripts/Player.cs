using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    public float speed;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 10;
        grounded = true;
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
}
