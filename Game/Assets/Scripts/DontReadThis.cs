using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontReadThis : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion1;
    public GameObject explosion2;
    public GameObject explosion3;
    public GameObject explosion4;
    public GameObject explosion5;
    public GameObject explosion6;
    public GameObject explosion7;
    public GameObject explosion8;
    public GameObject explosion9;
    public GameObject explosion10;
    public GameObject explosion11;
    public GameObject explosion12;
    public GameObject explosion13;
    public GameObject explosion14;
    public GameObject explosion15;
    public GameObject explosion16;
    public GameObject explosion17;
    float timer1;
    float timer2;
    float timer3;
    float timer4;
    float timer5;
    float timer6;
    float timer7;
    float timer8;
    float timer9;
    float timer10;
    float timer11;
    float timer12;
    float timer13;
    float timer14;
    float timer15;
    float timer16;
    float timer17;
    bool isTime1 = true;
    bool isTime2 = true;
    bool isTime3 = true;
    bool isTime4 = true;
    bool isTime5 = true;
    bool isTime6 = true;
    bool isTime7 = true;
    bool isTime8 = true;
    bool isTime9 = true;
    bool isTime10 = true;
    bool isTime11 = true;
    bool isTime12 = true;
    bool isTime13 = true;
    bool isTime14 = true;
    bool isTime15 = true;
    bool isTime16 = true;
    bool isTime17 = true;


    void Start()
    {
        timer1 = Random.Range(0f,1f);
        timer3 = Random.Range(0f,1f);
        timer4 = Random.Range(0f,1f);
        timer5 = Random.Range(0f,1f);
        timer6 = Random.Range(0f,1f);
        timer7 = Random.Range(0f,1f);
        timer8 = Random.Range(0f,1f);
        timer9 = Random.Range(0f,1f);
        timer10 = Random.Range(0f,1f);
        timer11 = Random.Range(0f,1f);
        timer12 = Random.Range(0f,1f);
        timer13 = Random.Range(0f,1f);
        timer14 = Random.Range(0f,1f);
        timer15 = Random.Range(0f,1f);
        timer16 = Random.Range(0f,1f);
        timer17 = Random.Range(0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        GlobalVariables.Timer(ref isTime1, ref timer1);
        GlobalVariables.Timer(ref isTime2, ref timer2);
        GlobalVariables.Timer(ref isTime3, ref timer3);
        GlobalVariables.Timer(ref isTime4, ref timer4);
        GlobalVariables.Timer(ref isTime5, ref timer5);
        GlobalVariables.Timer(ref isTime6, ref timer6);
        GlobalVariables.Timer(ref isTime7, ref timer7);
        GlobalVariables.Timer(ref isTime8, ref timer8);
        GlobalVariables.Timer(ref isTime9, ref timer9);
        GlobalVariables.Timer(ref isTime10, ref timer10);
        GlobalVariables.Timer(ref isTime11, ref timer11);
        GlobalVariables.Timer(ref isTime12, ref timer12);
        GlobalVariables.Timer(ref isTime13, ref timer13);
        GlobalVariables.Timer(ref isTime14, ref timer14);
        GlobalVariables.Timer(ref isTime15, ref timer15);
        GlobalVariables.Timer(ref isTime16, ref timer16);
        GlobalVariables.Timer(ref isTime17, ref timer17);
        if(isTime1 == false) {
            explosion1.SetActive(true);
        }
        if(isTime2 == false) {
            explosion2.SetActive(true);
        }
        if(isTime3 == false) {
            explosion3.SetActive(true);
        }
        if(isTime4 == false) {
            explosion4.SetActive(true);
        }
        if(isTime5 == false) {
            explosion5.SetActive(true);
        }
        if(isTime6 == false) {
            explosion6.SetActive(true);
        }
        if(isTime7 == false) {
            explosion7.SetActive(true);
        }
        if(isTime8 == false) {
            explosion8.SetActive(true);
        }
        if(isTime9 == false) {
            explosion9.SetActive(true);
        }
        if(isTime10 == false) {
            explosion10.SetActive(true);
        }
        if(isTime11 == false) {
            explosion11.SetActive(true);
        }
        if(isTime12 == false) {
            explosion12.SetActive(true);
        }
        if(isTime13 == false) {
            explosion13.SetActive(true);
        }
        if(isTime14 == false) {
            explosion14.SetActive(true);
        }
        if(isTime15 == false) {
            explosion15.SetActive(true);
        }
        if(isTime16 == false) {
            explosion16.SetActive(true);
        }
        if(isTime17 == false) {
            explosion17.SetActive(true);
        }
    }
}
