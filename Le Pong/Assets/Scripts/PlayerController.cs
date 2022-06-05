using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    float verticalAxisInput;
    public float speed = 5;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        verticalAxisInput = Input.GetAxis("Vertical");
        if (verticalAxisInput != 0)
        {
            rigidBody.velocity = new Vector3(0, verticalAxisInput * speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
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
