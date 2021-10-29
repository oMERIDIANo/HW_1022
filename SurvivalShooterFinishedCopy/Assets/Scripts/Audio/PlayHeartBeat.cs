using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHeartBeat : MonoBehaviour
{
    public PlayerHealth playerHealth;
    AudioSource audioplayer;

    bool isAudioPlaying;

    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        while(playerHealth.currentHealth < 50 && isAudioPlaying == false)
        {
            Debug.Log("play sound");
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        isAudioPlaying = true;
        audioplayer.Play();
        yield return new WaitForSeconds(5);
        isAudioPlaying = false;
    }
}
