using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;
    public AudioClip hitBall, loseBall, lose, win;

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
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHitBall() => Play(hitBall);
    public void PlayLoseBall() => Play(loseBall);
    public void PlayLose() => Play(lose);
    public void PlayWin() => Play(win);

    void Play(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
