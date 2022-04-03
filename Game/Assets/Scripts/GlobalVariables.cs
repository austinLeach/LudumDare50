using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static int sliderMax = 250;
    public static int money = 20;
    public static float food = 100f;
    public static float water = 100f;
    public static int population = 0;
    public static float godHappiness = 250f;
    public static int initialSliderValue = 100;
    public static int moneyPerSec = 0;
    public static float currentSpawnRate = 1f;
    public static int waterPerSec = 0;
    public static int foodPerSec = 0;
    public static int BossHealth = 100000;
    public static bool finalTime = false;
    public static List<string> upgrades = new List<string>();
    public static bool Timer(ref bool isChanging, ref float timer) {
      if (isChanging)
      {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
          isChanging = false;
        }
      }
      return isChanging;
    }

    
}
