using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{
    public DragDrop dragDrop;
    public List<Duck> duckList = new List<Duck>();
    public float decreaseRate = GlobalVariables.GodTime;
    public bool decreaseHappiness = false;
    private void Update()
    {
        if(duckList.Count != 0 && !dragDrop.MouseIsDown)
        {
            while(duckList.Count != 0)
            {
                if (duckList[0]) {
                    duckList[0].DestroyDuck(true);
                    duckList.RemoveAt(0);
                } else {
                    duckList.RemoveAt(0);
                }
                GlobalVariables.numberOfSacrificed++;
                // Destroy(duckList[0].gameObject);
                // GlobalVariables.population--;
                if (GlobalVariables.population > 700)
                {
                    GlobalVariables.godHappiness += 4;
                }
                else if (GlobalVariables.population > 500)
                {
                    GlobalVariables.godHappiness += 5;
                }
                else if (GlobalVariables.population > 250)
                {
                    GlobalVariables.godHappiness += 8;
                }
                else if (GlobalVariables.population > 100)
                {
                    GlobalVariables.godHappiness += 12;
                }
                else
                {
                    GlobalVariables.godHappiness += 15;
                }

                if (GlobalVariables.godHappiness > GlobalVariables.sliderMax)
                {
                    GlobalVariables.godHappiness = GlobalVariables.sliderMax;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        /*
        if(GlobalVariables.population > 700)
        {
            GlobalVariables.godHappiness -= Time.deltaTime * (Time.time / 10);
        }
        else if(GlobalVariables.population > 500)
        {
            GlobalVariables.godHappiness -= Time.deltaTime * (Time.time / 15);
        }
        else if(GlobalVariables.population > 250)
        {
            GlobalVariables.godHappiness -= Time.deltaTime * (Time.time / 25);
        }
        else
        {
            GlobalVariables.godHappiness -= Time.deltaTime * (Time.time / 30);
        }
        */
        DecreaseGod();
        GlobalVariables.Timer(ref decreaseHappiness, ref decreaseRate);
        //Debug.Log("GH: " + GlobalVariables.godHappiness);
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

    private void DecreaseGod()
    {
        if (decreaseHappiness)
            return;

        if (GlobalVariables.godHappiness > 1000)
            GlobalVariables.godHappiness = 1000;
        else if (GlobalVariables.godHappiness > 1 && GlobalVariables.godHappiness <= 1000)
        {
            if (GlobalVariables.population < 150) {
                GlobalVariables.godHappiness -= GlobalVariables.GodROC + (GlobalVariables.population * 0.012f);
            }
            else if (GlobalVariables.population < 250) {
                GlobalVariables.godHappiness -= GlobalVariables.GodROC + (GlobalVariables.population * 0.008f);
            } else {
                GlobalVariables.godHappiness -= GlobalVariables.GodROC + (GlobalVariables.population * 0.005f);
            }
            //decreaseRate -= 0.1f;
        }

        else
            GlobalVariables.godHappiness = 1;
        decreaseHappiness = true;
        decreaseRate = GlobalVariables.GodTime;
        //Debug.Log(GlobalVariables.godHappiness);
        //Debug.Log(godSlider.value);
    }
}
