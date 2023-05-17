using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerUlt : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;
    public float cdLaser = 5f;
    public Text textCDLaser;
    public Button buttonLaser;

    private float step = 0.1f;
    private float timer;
    private float skillratelaser;
    PlayerInputAction _input;

    void Start()
    {
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        buttonLaser.enabled = true;
        textCDLaser.enabled = false;
    }

    void OnEnable()
    {
        _input = new PlayerInputAction();
        _input.Player.Enable();

        _input.Player.Skill1.performed += Ultimate;
        _input.Player.Skill1.canceled += Ultimate;
    }

    void OnDisable()
    {
        _input.Player.Skill1.performed -= Ultimate;
        _input.Player.Skill1.canceled -= Ultimate;

        _input.Player.Disable();
    }

    void Ultimate(InputAction.CallbackContext context)
    {
        // Skill Logic
        if (Time.time > skillratelaser)
        {
            skillratelaser = Time.time + cdLaser;
            Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            CdStart(cdLaser);
        }
    }

    void CdStart(float cd)
    {
        timer = cd;
        StartCoroutine(CdRoutine(timer));
    }

    IEnumerator CdRoutine(float cd)
    {
        while (timer >= 0)
        {
            yield return new WaitForSeconds(step);
            buttonLaser.enabled = false;
            timer -= step;
            textCDLaser.text = timer.ToString("n1");
            textCDLaser.enabled = true;
        }
        timer = cd;
        buttonLaser.enabled = true;
        textCDLaser.enabled = false;
    }
}
