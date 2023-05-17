using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int category;
    public float enemySpeed = 3f;
    public int life = 3;
    public float lineOfSite;
    public float shootingRange;
    public Rigidbody2D rb;
    public HealthBar healthbar;
    public AudioSource audioSFX;
    public AudioClip getHitSFX;

    private Transform player;
    private float distance;
    private bool flip;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        healthbar.SetMaxHealth(life);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(life);
        if (PlayerHealth.currentHealth > 0)
        {
            switch(category)
            {
                case 0:
                    EbirdBehaviour();
                    break;
                case 1:
                    DroidBehaviour();
                    break;
            }
        }
        Dead();
    }

    private void faceToPlayer()
    {
        Vector3 scale = transform.localScale;

        if(player.position.x < transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        } else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
        transform.localScale = scale;
    }

    void EbirdBehaviour()
    { 
        distance = Vector2.Distance(player.position, transform.position);

        if (distance < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, enemySpeed * Time.deltaTime);
            faceToPlayer();
        } 
    }

    void DroidBehaviour()
    {
        distance = Vector2.Distance(player.position, transform.position);

        if (distance < lineOfSite && distance >= shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, enemySpeed * Time.deltaTime);
            faceToPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "PlayerAttack")
        {
            audioSFX.clip = getHitSFX;
            audioSFX.Play();
        }
    }

    void Dead()
    {
        if(life <= 0)
        {
            Destroy(rb.gameObject, 0.1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
