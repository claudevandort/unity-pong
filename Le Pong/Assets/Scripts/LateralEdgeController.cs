using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralEdgeController : MonoBehaviour
{
    public int pointsForPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            GameManager.instance.AddPointToPlayer(pointsForPlayer);
        }
    }
}
