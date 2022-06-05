using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigidBody;

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

    public void Push(Vector2 direction)
    {
        rigidBody.velocity = new Vector3(direction.x, direction.y, 0);
    }
}
