using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{
    public DragDrop dragDrop;
    private bool flag = false;
    private List<Duck> duckList = new List<Duck>();
    private void Update()
    {
        if(duckList.Count != 0 && !dragDrop.MouseIsDown)
        {
            while(duckList.Count != 0)
            {
                Destroy(duckList[0].gameObject);
            }
        }
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck && !dragDrop.MouseIsDown)
        {
            Destroy(collision.gameObject);
            Debug.Log("Stay");
            GlobalVariables.godHappiness++;
            GlobalVariables.population--;
            Debug.Log("God Happiness: " + GlobalVariables.godHappiness);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            duckList.Add(duck);
            /*Destroy(collision.gameObject);
            Debug.Log("Stay");
            GlobalVariables.godHappiness++;
            GlobalVariables.population--;
            Debug.Log("God Happiness: " + GlobalVariables.godHappiness);*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Duck duck = collision.GetComponent<Duck>();
        if (duck)
        {
            duckList.Remove(duck);
            /*Destroy(collision.gameObject);
            Debug.Log("Stay");
            GlobalVariables.godHappiness++;
            GlobalVariables.population--;
            Debug.Log("God Happiness: " + GlobalVariables.godHappiness);*/
        }
    }
}
