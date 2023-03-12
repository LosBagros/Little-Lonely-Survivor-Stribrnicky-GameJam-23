using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private AudioMixer audioMixer;

    
    void Start()
    {
        GameObject child = new GameObject("AudioSource");
        child.transform.parent = transform;
        AudioSource audioSource = child.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        audioSource.Play();
    }
}
