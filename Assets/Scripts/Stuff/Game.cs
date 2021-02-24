using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Game : MonoBehaviour
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

    public Character player;

    static Game instance = null;

    float timer = 0;
    public float deathTimer = 1;

    public enum eState
    {
        Title,
        StartGame,
        Game,
        Death,
        GameOver
    }

    public eState State { get; set; } = eState.StartGame;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        switch (State)
        {
            case eState.Title:
                // titleScreen.SetActive(true);
                //reticle.SetActive(true);
                gameOver.SetActive(false);
                break;
            case eState.StartGame:
                //titleScreen.SetActive(false);
                timer = 0;
                //player.animator.SetTrigger("GameStart");
                player.GetHealth().CurrentHealth = player.GetHealth().healthMax;
                //Score = 0;
                State = eState.Game;
                //music.Play();
                //ambience.Play();
                break;
            case eState.Game:
                //player.GetHealth().AddHealth(-Time.deltaTime * player.GetHealth().decay);
                timer += Time.deltaTime;
                Debug.Log(timer);
                timerUI.text = string.Format("{0:D4}", (int)timer);
                if (player.GetHealth().CurrentHealth <= 0) State = eState.GameOver;
                break;
            case eState.Death:
                //music.Stop();
                deathTimer -= Time.deltaTime;
                if(deathTimer <= 0)
                {
                    State = eState.GameOver;
                }
                break;
            case eState.GameOver:
                //music.Stop();
                gameOver.SetActive(true);
                //reticle.SetActive(false);
                /*if(Score > HighScore)
                {
                    HighScore = Score;
                    highScoreUI.text = string.Format("{0:D4}", HighScore);
                }*/
                break;
            default:
                break;
        }

    }

    public static Game Instance
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

    public void StartGame()
    {
        State = eState.StartGame;
    }

    public void PlayAgain()
    {
        //GameController.Instance.OnLoadMenuScene("MainMenu");
    }

    /*public static implicit operator Game(Game v)
    {
        throw new NotImplementedException();
    }*/
}
