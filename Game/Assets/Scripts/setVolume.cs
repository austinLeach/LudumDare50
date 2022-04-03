using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class setVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);
    }
}
