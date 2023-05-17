using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioSource clickSFX;
    public GameObject credit;

    // Start is called before the first frame update
    void Start()
    {
        clickSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSound()
    {
        clickSFX.Play();
    }

    public void StartGame(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CreditGame()
    {
        credit.SetActive(true);
    }
}
