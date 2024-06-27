using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)) {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
