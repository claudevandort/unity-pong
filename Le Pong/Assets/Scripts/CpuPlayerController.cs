using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuPlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    GameObject ball;
    public float speed = 5;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (ball.transform.position.x > 0)
        {
            Vector3 relativePosition = this.transform.InverseTransformPoint(ball.transform.position);
            if (relativePosition.y > 0)
            {
                this.rigidBody.velocity = Vector3.up * speed;
            }
            else if(relativePosition.y < 0)
            {
                this.rigidBody.velocity = Vector3.down * speed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Vector3 relativePosition = this.transform.InverseTransformPoint(collision.transform.position);
            Vector2 newVelocity = new(
                collision.rigidbody.velocity.x,
                collision.rigidbody.velocity.y + relativePosition.y * 5);
            collision.rigidbody.velocity = newVelocity;
            GameManager.instance.OnBallHit();
        }
    }
}
