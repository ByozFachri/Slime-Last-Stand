using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSFX;
    public AudioClip fireSFX;

    public float firerate;
    float nextfire;
    PlayerInputAction _input;

    void Start()
    {
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        audioSFX = GameObject.Find("FirePoint").GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        _input = new PlayerInputAction();
        _input.Player.Enable();

        _input.Player.Fire.performed += Shoot;
        _input.Player.Fire.canceled += Shoot;
    }

    void OnDisable()
    {
        _input.Player.Fire.performed -= Shoot;
        _input.Player.Fire.canceled -= Shoot;

        _input.Player.Disable();
    }

    void Shoot(InputAction.CallbackContext context)
    {
        // Shoot Logic
        if(Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            audioSFX.clip = fireSFX;
            audioSFX.Play();
        }
    }
}
