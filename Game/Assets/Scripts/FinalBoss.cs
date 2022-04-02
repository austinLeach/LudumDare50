using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBoss : MonoBehaviour
{
    public GameObject BossText;
    public Slider slider;
    int BossHealth = 100000;
    float startTimer = 20f;
    bool start = true;
    bool firing = true;
    float firingTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = BossHealth;
        GlobalVariables.upgrades.Add("1");
        GlobalVariables.upgrades.Add("2");
        GlobalVariables.upgrades.Add("3");
        GlobalVariables.upgrades.Add("4");
        GlobalVariables.upgrades.Add("5");
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
                    BossHealth -= 10;
                    break;
                case 2:
                    Debug.Log("case 2");
                    BossHealth -= 25;
                    break;
                case 3:
                    Debug.Log("case 3");
                    BossHealth -= 50;
                    break;
                case 4:
                    Debug.Log("case 4");
                    BossHealth -= 50;
                    if (!firing) {
                        BossHealth -= 2500;
                        firing = true;
                        firingTimer = 2f;
                    }
                    break;
                case 5:
                    Debug.Log("case 5");
                    BossHealth -= 75;
                    if (!firing) {
                        BossHealth -= 2500;
                        firing = true;
                        firingTimer = 2f;
                    }
                    if (startTimer < 3f){
                        BossHealth -= 1000;
                    }
                    break;
                default:
                BossHealth -= 5;
                    break;
            }
            setHealth(BossHealth);
        } 
        else {
            Debug.Log("Game Over");
        }

        if (BossHealth < 0) {
            Debug.Log("WIN");
        }
    }

    void setHealth(int health) {
        slider.value = health;
    }
}
