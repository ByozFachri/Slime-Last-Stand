using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    public Transform firePoint;
    public GameObject whirlwindPrefab;
    public float cdWhirlwind = 3f;
    public Text textCDWhirlwind;
    public Button buttonWhirlwind;

    private float step = 0.1f;
    private float timer;
    private float skillratewhirlwind;
    PlayerInputAction _input;

    void Start()
    {
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        buttonWhirlwind.enabled = true;
        textCDWhirlwind.enabled = false;
    }

    void OnEnable()
    {
        _input = new PlayerInputAction();
        _input.Player.Enable();

        _input.Player.Skill2.performed += Skill;
        _input.Player.Skill2.canceled += Skill;
    }

    void OnDisable()
    {
        _input.Player.Skill2.performed -= Skill;
        _input.Player.Skill2.canceled -= Skill;

        _input.Player.Disable();
    }

    void Skill(InputAction.CallbackContext context)
    {
        // Skill Logic
        if (Time.time > skillratewhirlwind)
        {
            skillratewhirlwind = Time.time + cdWhirlwind;
            Instantiate(whirlwindPrefab, firePoint.position, firePoint.rotation);
            CdStart(cdWhirlwind);
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
            buttonWhirlwind.enabled = false;
            timer -= step;
            textCDWhirlwind.text = timer.ToString("n1");
            textCDWhirlwind.enabled = true;
        }
        timer = cd;
        buttonWhirlwind.enabled = true;
        textCDWhirlwind.enabled = false;
    }
}
