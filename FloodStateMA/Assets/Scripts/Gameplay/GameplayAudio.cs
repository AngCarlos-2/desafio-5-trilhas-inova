using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAudio : MonoBehaviour
{
    public AudioSource soundEffectWater;
    
    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectWater.PlayOneShot(clip);
    }
}
