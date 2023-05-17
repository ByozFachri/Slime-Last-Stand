using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Skor : " + score.ToString();
    }

    public void AddPoint(int pointValue)
    {
        score = score + pointValue;
        scoreText.text = "Skor : " + score.ToString();
    }
}
