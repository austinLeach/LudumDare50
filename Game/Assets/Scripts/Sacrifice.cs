using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{
    public DragDrop dragDrop;
    private List<Duck> duckList = new List<Duck>();

    private void Update()
    {
        if(duckList.Count != 0 && !dragDrop.MouseIsDown)
        {
            while(duckList.Count != 0)
            {
                Destroy(duckList[0].gameObject);
                GlobalVariables.population--;
                GlobalVariables.godHappiness += 5;
                if(GlobalVariables.godHappiness > GlobalVariables.sliderMax)
                {
                    GlobalVariables.godHappiness = GlobalVariables.sliderMax;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(GlobalVariables.population > 700)
        {
            GlobalVariables.godHappiness -= Time.deltaTime * (Time.time / 3);
        }
        else if(GlobalVariables.population > 500)
        {
            GlobalVariables.godHappiness -= Time.deltaTime * (Time.time / 5);
        }
        else if(GlobalVariables.population > 250)
        {
            GlobalVariables.godHappiness -= Time.deltaTime * (Time.time / 7);
        }
        else
        {
            GlobalVariables.godHappiness -= Time.deltaTime * (Time.time / 10);
        }
        Debug.Log("GH: " + GlobalVariables.godHappiness);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if(duck)
        {
            duckList.Add(duck);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if(duck)
        {
            duckList.Remove(duck);
        }
    }
}
