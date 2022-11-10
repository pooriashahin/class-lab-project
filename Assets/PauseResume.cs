using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{

    [SerializeField] GameObject[] showWhenPaused;
    [SerializeField] GameObject[] showWhenResumed;

    // Start is called before the first frame update
    void Start()
    {
        showWhenPaused = GameObject.FindGameObjectsWithTag("ShowOnPause");
        showWhenResumed = GameObject.FindGameObjectsWithTag("ShowOnResume");
        foreach(GameObject g in showWhenPaused)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause() {
        Time.timeScale = 0.0f;
        foreach(GameObject g in showWhenPaused)
            g.SetActive(true);

        foreach(GameObject g in showWhenResumed)
            g.SetActive(false);
    }

    public void Resume() {
        Time.timeScale = 1.0f;
        foreach(GameObject g in showWhenPaused)
            g.SetActive(false);

        foreach(GameObject g in showWhenResumed)
            g.SetActive(true);
    }
}
