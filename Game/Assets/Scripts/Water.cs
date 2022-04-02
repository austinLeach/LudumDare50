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
            InvokeRepeating("GenerateWater", 1f, 1f);
            Debug.Log("Start invoke");
        }
        else if (GlobalVariables.waterPerSec <= 0 && IsInvoking("GenerateWater"))
        {
            CancelInvoke("GenerateWater");
            Debug.Log("Cancel invoke");
        }
        GlobalVariables.water -= Time.deltaTime * (GlobalVariables.population * 0.06f);
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
            GlobalVariables.waterPerSec++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            GlobalVariables.waterPerSec--;
        }
    }
}