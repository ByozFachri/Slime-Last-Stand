using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float randomx;
    float randomy;
    float time = 0f;
    float enemytimer = 7f;
    float enemyspwantime = 60f;

    private bool cd = true;
    private bool begin = false;

    public GameObject enemyPrefab;
    public GameObject enemyElitePrefab;

    private void Start()
    {
        StartCoroutine(FirstDelay());
    }

    // Update is called once per frame
    void Update()
    {
        randomx = Random.Range(-10f, 18f);
        randomy = Random.Range(-5f, 3f);
        if (cd == false)
        {
            begin = true;
            if (enemyspwantime >= 0)
            {
                if (time <= 0)
                {
                    Instantiate(enemyPrefab, new Vector2(randomx, randomy), Quaternion.identity);
                    time = enemytimer;
                }
                else
                {
                    time -= Time.deltaTime;
                }
                enemyspwantime -= Time.deltaTime;
            } else
            {
                cd = true;
                Instantiate(enemyElitePrefab, new Vector2(randomx, randomy), Quaternion.identity);
            }
        } else
        {
            if(begin)
            {
                cd = false;
                enemyspwantime = 30f;
                begin = false;
            }
            
        }
        
        
    }

    float RandomXDir()
    {
        var randy = Random.Range(1, 3);
        float randomXDir = 0;
        if (randy == 1)
        {
            randomXDir = 10;
        }
        else
        {
            randomXDir = -10;
        }
        return randomXDir;
    }

    IEnumerator FirstDelay()
    {
        yield return new WaitForSeconds(2f);
        cd = false;
    }
}
