using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryManager : MonoBehaviour
{
    public GameObject canvasRetry;
    public GameObject canvasPause;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(canvasRetry.activeInHierarchy)
        {
            PauseMenu.gameIsPaused = true;
            canvasPause.SetActive(false);
            canvasRetry.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
