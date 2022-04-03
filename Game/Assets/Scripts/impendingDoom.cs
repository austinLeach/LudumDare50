using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class impendingDoom : MonoBehaviour
{
    float Countdown = 20f;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Countdown < 15) {
            text.SetActive(true);
        }
        Countdown -= Time.deltaTime;
        Debug.Log(Countdown);
        SetText(Countdown);
    }

    void SetText(float Countdown) {
        Text timerText = text.GetComponent<Text>();
        if (Countdown > 0) {
            timerText.text = "Impending DOOM: " + Countdown.ToString();
        } else {
            timerText.text = "Time Since Quack-a-geddon: " + Countdown.ToString();
            timerText.fontSize = 80;
        }
        
    }
}
