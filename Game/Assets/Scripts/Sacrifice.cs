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
                GlobalVariables.godHappiness += 2;
                if(GlobalVariables.godHappiness > GlobalVariables.sliderMax)
                {
                    GlobalVariables.godHappiness = GlobalVariables.sliderMax;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        GlobalVariables.godHappiness = GlobalVariables.population / 4f;
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
