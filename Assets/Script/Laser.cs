using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(rb.gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Enemy" || hitInfo.tag == "EnemyElite")
        {
            hitInfo.GetComponent<EnemyBehaviour>().life-=3;
            if (hitInfo.GetComponent<EnemyBehaviour>().life <= 0)
            {
                if (hitInfo.tag == "Enemy")
                {
                    ScoreManager.instance.AddPoint(1);
                }
                else
                {
                    ScoreManager.instance.AddPoint(5);
                }

            }
        }
    }
}
