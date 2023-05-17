using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(rb.gameObject, 0.4f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Enemy"|| hitInfo.tag == "EnemyElite")
        {
            hitInfo.GetComponent<EnemyBehaviour>().life--;            
            if(hitInfo.GetComponent<EnemyBehaviour>().life <= 0)
            {
                if(hitInfo.tag == "Enemy")
                {
                    ScoreManager.instance.AddPoint(1);
                }else
                {
                    ScoreManager.instance.AddPoint(5);
                }
                
            }
        }
        if(hitInfo.tag != "Edge")
        {
            Destroy(gameObject);
        }
    }
}
