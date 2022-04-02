using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
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
                GlobalVariables.waterPerSec++;
                Debug.Log("Water Per Second: " + GlobalVariables.waterPerSec);
            }
        }

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
    }

    private void GenerateWater()
    {
        GlobalVariables.water += GlobalVariables.waterPerSec;
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
