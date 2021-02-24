using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public RawImage image;
    public float _time;
    public Color _color;
    public bool startOnAwake;
    public AudioSource audioSource;

    Color startColor;

    void Start()
    {
        if(startOnAwake)
        {
            StartTransition(_color, _time);
        }
    }

    public void StartTransition(Color color, float time, string sceneName = "")
    {
        //audioSource.Play();
        _color = color;
        _time = time;
        startColor = image.color;
        //StartCoroutine(TransitionRoutine(time, sceneName));
    }

    IEnumerator TransitionRoutine(float timer, string sceneName)
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            float t = (timer / _time);
            image.color = Color.Lerp(_color, startColor, t);
            yield return null;
        }

        if (sceneName != "") SceneManager.LoadScene(sceneName);

        yield return null;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Wait 1"); 
        yield return new WaitForSeconds(time);
        Debug.Log("Wait 2");
        yield return null;
    }

    IEnumerator Timer(float time)
    {
        Debug.Log("Start");
        while (time > 0)
        {
            time -= Time.deltaTime;
            Debug.Log(time);
            yield return null;
        }
    }
}
