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
            GlobalVariables.moneyPerSec++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            GlobalVariables.moneyPerSec--;
        }
    }
}
