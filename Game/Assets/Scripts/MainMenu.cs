using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   // public AudioSource audio;
    void Start() {
   //     audio.time = GlobalVariables.timeInAudio;
    }
    public void PlayGame() {
        // GlobalVariables.timeInAudio = audio.time;
        SceneManager.LoadScene("Inbetween1");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
