using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootingRange;

    private Transform player;

    public float firerate;
    float nextfire;
    float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.position, transform.position);
        if (Time.time > nextfire && shootingRange >= distance)
        {
            nextfire = Time.time + firerate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
        }
    }
}
