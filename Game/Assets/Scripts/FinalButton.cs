using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinalButton : MonoBehaviour
{
    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    private void Start() {
        Text text = this.GetComponent<Text>();
        if (GlobalVariables.wonGame) {
            text.text = "Congratulations, you have sold enough Lemonade to Defeat God." + " You Sacrificed " + GlobalVariables.numberOfSacrificed.ToString() + " Ducks.";
            text.fontSize = 40;
        }
        else {
            text.text = "Main Menu. You Sacrificed " + GlobalVariables.numberOfSacrificed.ToString() + " Ducks.";
        }
    }
}
