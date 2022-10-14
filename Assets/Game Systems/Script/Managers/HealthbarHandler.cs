using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarHandler : MonoBehaviour
{
    public Image healthBar;
    public float minHealth, maxHealth, currentHealth;
    public Gradient healthColour;
    public Camera mainCam;
    public Transform canvas;


    private void Start()
    {
        mainCam = Camera.main;
        minHealth = 0;
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    private void Update()
    { 
        SetHealth();
        canvas.LookAt(canvas.position + mainCam.transform.forward);
    }

    void SetHealth()
    {
        //how much the bar is filled based on how much health we have
        healthBar.fillAmount = Mathf.Clamp01(currentHealth/maxHealth);
        //change colour on amount of health left
        healthBar.color = healthColour.Evaluate(healthBar.fillAmount);
    }
}
