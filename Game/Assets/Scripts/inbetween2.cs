using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class inbetween2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToFinalBoss() {
        SceneManager.LoadScene("FinalBoss");
    }
    private void Start() {
        Text text = this.GetComponent<Text>();
        if (GlobalVariables.LostToWater) {
            text.text = "You have Failed the objective of Maintaining Water, now you must face Duck God, hopefully you have prepared for this moment well.";
        }
        else if (GlobalVariables.LostToFood) {
            text.text = "You have Failed the objective of Maintaining Food, now you must face Duck God, hopefully you have prepared for this moment well.";
        }
        else if (GlobalVariables.LostToGod) {
            text.text = "You have Failed the objective of Appeasing the God, now you must face Duck God, hopefully you have prepared for this moment well.";
        }
        else {
            text.text = "You have Failed the objective of Staying Below 1000 Ducks, now you must face Duck God, hopefully you have prepared for this moment well.";
        }
    }
}
