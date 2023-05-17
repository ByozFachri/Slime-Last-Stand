using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxHealth = 10;
    public static int currentHealth;
    public HealthBar healthbar;
    public AudioSource audioSFX;
    public AudioClip getHitSFX;
    public GameObject canvasRetry;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = gameObject.GetComponent<Rigidbody2D>();
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "EnemyAttack" || hitInfo.tag == "EnemyBullet")
        {
            currentHealth--;
            if(hitInfo.tag == "EnemyBullet")
            {
                audioSFX.clip = getHitSFX;
                audioSFX.Play();
            }
            if (currentHealth <= 0)
            {
                Time.timeScale = 0f;
                PauseMenu.gameIsPaused = true;
                canvasRetry.SetActive(true);
            }
        }
        
    }
}
