using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource song;
    // Start is called before the first frame update
    void Start()
    {
         song = GetComponent<AudioSource>();
         song.pitch = 0.65f;
    }

    // Update is called once per frame
    void Update()
    {
        if(song.pitch < 1.3f) {
            song.pitch += 0.00001f;
        }
    }
}
