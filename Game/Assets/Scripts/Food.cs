using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public DragDrop dragDrop;

    private void Update()
    {
        if (GlobalVariables.foodPerSec > 0 && !IsInvoking("GenerateFood"))
        {
            InvokeRepeating("GenerateFood", 1f, 1f);
            Debug.Log("Start invoke");
        }
        else if (GlobalVariables.foodPerSec <= 0 && IsInvoking("GenerateFood"))
        {
            CancelInvoke("GenerateFood");
            Debug.Log("Cancel invoke");
        }
        GlobalVariables.food -= Time.deltaTime * (GlobalVariables.population * 0.10f);
    }

    private void GenerateFood()
    {
        GlobalVariables.food += GlobalVariables.foodPerSec;
        if (GlobalVariables.food > GlobalVariables.sliderMax)
        {
            GlobalVariables.food = GlobalVariables.sliderMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            GlobalVariables.foodPerSec++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            GlobalVariables.foodPerSec--;
        }
    }
}
