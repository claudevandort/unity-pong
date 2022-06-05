using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameViewManager : MonoBehaviour
{
    public static GameViewManager instance;
    Canvas gameCanvas;
    Text scorePlayer1;
    Text scorePlayer2;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameCanvas = GetComponent<Canvas>();
        scorePlayer1 = GameObject.Find("Score Player 1").GetComponent<Text>();
        scorePlayer2 = GameObject.Find("Score Player 2").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawScore(int player1, int player2)
    {
        scorePlayer1.text = $"{player1}";
        scorePlayer2.text = $"{player2}";
    }
}
