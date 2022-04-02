using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public DragDrop dragDrop;

    private void Start()
    {
        InvokeRepeating("GenerateIncome", 1f, 1f);
    }

    private void GenerateIncome()
    {
        GlobalVariables.money += GlobalVariables.moneyPerSec;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck && !dragDrop.MouseIsDown)
        {
            Destroy(collision.gameObject);
            Debug.Log("Stay");
            GlobalVariables.moneyPerSec++;
            Debug.Log("Money Per Second: " + GlobalVariables.moneyPerSec);
        }
    }
}
