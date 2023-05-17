using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSFX;
    public GameObject controllers;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject healthBar;

    private void Start()
    {
        Time.timeScale = 1f;
        PauseMenu.gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.gameIsPaused == true)
        {
            controllers.SetActive(false);
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            buttonThree.SetActive(false);
            healthBar.SetActive(false);
            audioSFX.Pause();
        } else
        {
            controllers.SetActive(true);
            buttonOne.SetActive(true);
            buttonTwo.SetActive(true);
            buttonThree.SetActive(true);
            healthBar.SetActive(true);
            audioSFX.UnPause();
        }
    }
}
