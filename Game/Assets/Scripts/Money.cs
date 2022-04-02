using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public DragDrop dragDrop;
    private List<Duck> duckList = new List<Duck>();

    private void Update()
    {
        if (duckList.Count != 0 && !dragDrop.MouseIsDown)
        {
            while (duckList.Count != 0)
            {
                Destroy(duckList[0].gameObject);
                GlobalVariables.moneyPerSec++;
                Debug.Log("Money Per Second: " + GlobalVariables.moneyPerSec);
            }
        }

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
            duckList.Add(duck);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            duckList.Remove(duck);
        }
    }
}
