using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        GameController gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            SceneManager.LoadScene("GameController", LoadSceneMode.Additive);
        }
    }

}
