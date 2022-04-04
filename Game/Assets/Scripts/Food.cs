using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public DragDrop dragDrop;
    public float baseDecrease = 0.05f;
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
        /*
        float diff = Time.deltaTime + baseDecrease;
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
            //GlobalVariables.food -= diff * (GlobalVariables.population * 0.04f);
            GlobalVariables.food -= Time.deltaTime * (GlobalVariables.population * 0.04f);
        }*/

        DecreaseFood();
    }

    private void DecreaseFood()
    {
        /*
         * dec 
         * min = 0 max = 14
         */
        int dec = GlobalVariables.population / 70;
        GlobalVariables.food -= dec + .05f;
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
