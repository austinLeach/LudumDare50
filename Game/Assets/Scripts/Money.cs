using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public DragDrop dragDrop;

    private void Update()
    {
        if(GlobalVariables.moneyPerSec > 0 && !IsInvoking("GenerateIncome"))
        {
            InvokeRepeating("GenerateIncome", 1f, 1f);
            Debug.Log("Start invoke");
        }
        else if(GlobalVariables.moneyPerSec <= 0 && IsInvoking("GenerateIncome"))
        {
            CancelInvoke("GenerateIncome");
            Debug.Log("Cancel invoke");
        }
    }

    private void GenerateIncome()
    {
        GlobalVariables.money += GlobalVariables.moneyPerSec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            if (GlobalVariables.population > 800)
                GlobalVariables.moneyPerSec += 40;
            else if (GlobalVariables.population > 500)
                GlobalVariables.moneyPerSec += 20;
            else if (GlobalVariables.population > 200) 
                GlobalVariables.moneyPerSec += 10;
            else
                GlobalVariables.moneyPerSec += 5;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            if (GlobalVariables.population > 800)
                GlobalVariables.moneyPerSec -= 20;
            else if (GlobalVariables.population > 500)
                GlobalVariables.moneyPerSec -= 10;
            else if (GlobalVariables.population > 200)
                GlobalVariables.moneyPerSec -= 5;
            else 
                GlobalVariables.moneyPerSec -= 3;
        }
    }
}
