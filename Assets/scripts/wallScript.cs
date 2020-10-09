using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour {

    public AudioClip hit;
                          
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = hit;
    }

    void OnCollisionEnter(Collision collision)  //Plays Sound Whenever collision detected
    {
        GetComponent<AudioSource>().Play();
    }
}
