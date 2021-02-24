using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class GameSession : MonoBehaviour
{
    //public int Score { get; set; } = 0;
    //public int HighScore { get; set; } = 0;
    //public TextMeshProUGUI scoreUI;
    //public TextMeshProUGUI highScoreUI;
    public TextMeshProUGUI timerUI;
    //public GameObject titleScreen;
    public GameObject gameOver;
    //public GameObject reticle;
    public AudioSource music;
    //public AudioSource ambience;
    public UnityEvent startSessionEvents;

    public Character player;

    static GameSession instance = null;

    float timer = 0;
    public float deathTimer = 1;

    public enum eState
    {
        StartSession,
        Session,
        EndSession,
        GameOver
    }

    public eState State { get; set; } = eState.StartSession;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        switch (State)
        {
            case eState.StartSession:
                timer = 0;
                player.GetHealth().CurrentHealth = player.GetHealth().healthMax;
                startSessionEvents?.Invoke();
                State = eState.Session;
                break;
            case eState.Session:
                break;
            case eState.GameOver:
                break;
            default:
                break;
        }

    }

    public static GameSession Instance
    {
        get
        {
            return instance;
        }
    }

    /*public void AddPoints(int points)
    {
        Score += points;
        scoreUI.text = string.Format("{0:D4}", Score);
    }*/

    /*public static implicit operator Game(Game v)
    {
        throw new NotImplementedException();
    }*/
}
