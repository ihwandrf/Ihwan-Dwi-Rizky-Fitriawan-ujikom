using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip sfxThrow;
    public AudioClip sfxDestroy;
    public AudioClip sfxGameOver;

    public AudioSource sfxSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {

        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void Throw()
    {
        sfxSource.clip = sfxThrow;
        sfxSource.Play();
    }

    public void GameOver()
    {
        sfxSource.clip = sfxGameOver;
        sfxSource.Play();
    }

    public void DestroySFX()
    {
        sfxSource.clip = sfxDestroy;
        sfxSource.Play();
    }
}

public class AudioSFX
{
    public string name;
    public AudioClip clip;
}
