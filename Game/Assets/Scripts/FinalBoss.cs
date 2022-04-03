using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBoss : MonoBehaviour
{
    public GameObject BossText;
    public Slider slider;
    float startTimer = 20f;
    bool start = true;
    bool firing = true;
    float firingTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.finalTime = true;
        slider.maxValue = GlobalVariables.BossHealth;
        // GlobalVariables.upgrades.Add("1");
        // GlobalVariables.upgrades.Add("2");
        // GlobalVariables.upgrades.Add("3");
        // GlobalVariables.upgrades.Add("4");
        // GlobalVariables.upgrades.Add("5");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GlobalVariables.Timer(ref start, ref startTimer);
        GlobalVariables.Timer(ref firing, ref firingTimer);
        if (startTimer < 15) {
            BossText.SetActive(false);
        }
        if (start) {
            switch (GlobalVariables.upgrades.Count) {
                case 1:
                    Debug.Log("case 1");
                    GlobalVariables.BossHealth -= 10;
                    break;
                case 2:
                    Debug.Log("case 2");
                    GlobalVariables.BossHealth -= 25;
                    break;
                case 3:
                    Debug.Log("case 3");
                    GlobalVariables.BossHealth -= 50;
                    break;
                case 4:
                    Debug.Log("case 4");
                    GlobalVariables.BossHealth -= 50;
                    break;
                case 5:
                    Debug.Log("case 5");
                    GlobalVariables.BossHealth -= 75;
                    if (startTimer < 3f){
                        GlobalVariables.BossHealth -= 1000;
                    }
                    break;
                default:
                
                    break;
            }
            setHealth(GlobalVariables.BossHealth);
        } 
        else {
            Debug.Log("Game Over");
        }

        if (GlobalVariables.BossHealth < 0) {
            Debug.Log("WIN");
        }
    }

    public void setHealth(int health) {
        slider.value = health;
    }
}
