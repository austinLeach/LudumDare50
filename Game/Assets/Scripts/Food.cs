using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
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
                GlobalVariables.foodPerSec++;
                Debug.Log("Food Per Second: " + GlobalVariables.foodPerSec);
            }
        }

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
    }

    private void GenerateFood()
    {
        GlobalVariables.food += GlobalVariables.foodPerSec;
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
