using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int scorePlayer1 = 0;
    int scorePlayer2 = 0;

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
        StartBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            ExitGame();
        }
    }

    void StartBall()
    {
        GameObject.Find("Ball").GetComponent<BallController>().Push(new Vector2(5, 5));
    }

    void ResetBall()
    {
        GameObject ball = GameObject.Find("Ball");
        ball.GetComponent<Rigidbody2D>().velocity = ball.GetComponent<Rigidbody2D>().velocity.normalized * 5;
        ball.transform.position = Vector2.zero;
    }

    void ResetScore()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        GameViewManager.instance.DrawScore(scorePlayer1, scorePlayer2);
    }

    public void AddPointToPlayer(int player)
    {
        switch (player)
        {
            case 1:
                scorePlayer1++;
                break;
            case 2:
                scorePlayer2++;
                break;
        }
        GameViewManager.instance.DrawScore(scorePlayer1, scorePlayer2);
        if (checkEndCondition())
        {
            ResetScore();
        }
        else
        {
            AudioManager.instance.PlayLoseBall();
        }
        Invoke("ResetBall", 2);
    }

    bool checkEndCondition()
    {
        if(scorePlayer1 >= scorePlayer2 + 2)
        {
            OnWin();
            return true;
        }
        else if(scorePlayer2 >= scorePlayer1 + 2)
        {
            OnLose();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnBallHit()
    {
        AudioManager.instance.PlayHitBall();
    }

    void OnWin()
    {
        AudioManager.instance.PlayWin();
    }

    void OnLose()
    {
        AudioManager.instance.PlayLose();
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
