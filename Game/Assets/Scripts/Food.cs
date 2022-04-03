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
            //GenerateFood: function name
            //second parameter: amount of time til it starts
            //third parameter: amount of time in between repeats
            InvokeRepeating("GenerateFood", 0.1f, 0.1f);
            Debug.Log("Start invoke");
        }
        else if (GlobalVariables.foodPerSec <= 0 && IsInvoking("GenerateFood"))
        {
            CancelInvoke("GenerateFood");
            Debug.Log("Cancel invoke");
        }
    }

    private void FixedUpdate()
    {
        if(GlobalVariables.population > 700)
        {
            GlobalVariables.food -= Time.deltaTime * (GlobalVariables.population * 0.15f);
        }
        else if(GlobalVariables.population > 500)
        {
            GlobalVariables.food -= Time.deltaTime * (GlobalVariables.population * 0.12f);
        }
        else if(GlobalVariables.population > 250)
        {
            GlobalVariables.food -= Time.deltaTime * (GlobalVariables.population * 0.10f);
        }
        else
        {
            GlobalVariables.food -= Time.deltaTime * (GlobalVariables.population * 0.04f);
        }
    }

    private void GenerateFood()
    {
        GlobalVariables.food += GlobalVariables.foodPerSec;
        if (GlobalVariables.food > GlobalVariables.sliderMax)
        {
            GlobalVariables.food = GlobalVariables.sliderMax;
        }
        Debug.Log("fps: " + GlobalVariables.foodPerSec);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            GlobalVariables.foodPerSec += 0.1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            GlobalVariables.foodPerSec -= 0.1f;
        }
    }
}
