using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceBackgroundMusic;
    public AudioSource SFX;
    public AudioClip[] backgroudMusic;
    // Start is called before the first frame update
    void Start()
    {
        AudioClip thisStageMusic = backgroudMusic[0];
        audioSourceBackgroundMusic.clip = thisStageMusic;
        audioSourceBackgroundMusic.loop = true;
        audioSourceBackgroundMusic.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
