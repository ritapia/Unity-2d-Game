using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip NewMusic;

    private void Awake()
    {
        GameObject go = GameObject.Find("Game Music");
        go.GetComponent<AudioSource>().clip = NewMusic;
        go.GetComponent<AudioSource>().Play();
    }
}
