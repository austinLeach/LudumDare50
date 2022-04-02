using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static int sliderMax = 250;
    public static int money = 20;
    public static int food = 100;
    public static int water = 100;
    public static int population = 1;
    public static int godHappiness = 250;
    public static int initialSliderValue = 100;
    public static int moneyPerSec = 0;
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
