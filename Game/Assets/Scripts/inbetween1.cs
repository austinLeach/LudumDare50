using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class inbetween1 : MonoBehaviour
{
    public AudioSource audio;
    void Start() {
       audio.time = GlobalVariables.timeInAudio1;
    }
    public void PlayGame() {
        GlobalVariables.timeInAudio1 = audio.time;
        SceneManager.LoadScene("MainScene");
    }
}
