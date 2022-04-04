using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public DragDrop dragDrop;

    private void Update()
    {
        if (GlobalVariables.waterPerSec > 0 && !IsInvoking("GenerateWater"))
        {
            InvokeRepeating("GenerateWater", 0.1f, 0.1f);
            Debug.Log("Start invoke");
        }
        else if (GlobalVariables.waterPerSec <= 0 && IsInvoking("GenerateWater"))
        {
            CancelInvoke("GenerateWater");
            Debug.Log("Cancel invoke");
        }
    }

    private void FixedUpdate()
    {
        if (GlobalVariables.population > 700)
        {
            GlobalVariables.water -= Time.deltaTime * (GlobalVariables.population * 0.21f);
        }
        else if (GlobalVariables.population > 500)
        {
            GlobalVariables.water -= Time.deltaTime * (GlobalVariables.population * 0.18f);
        }
        else if (GlobalVariables.population > 250)
        {
            GlobalVariables.water -= Time.deltaTime * (GlobalVariables.population * 0.15f);
        }
        else
        {
            GlobalVariables.water -= Time.deltaTime * (GlobalVariables.population * 0.06f);
        }
    }

    private void GenerateWater()
    {
        GlobalVariables.water += GlobalVariables.waterPerSec;
        if(GlobalVariables.water > GlobalVariables.sliderMax)
        {
            GlobalVariables.water = GlobalVariables.sliderMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            GlobalVariables.waterPerSec += 0.1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            GlobalVariables.waterPerSec -= 0.1f;
        }
    }
}
