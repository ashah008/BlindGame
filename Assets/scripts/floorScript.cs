using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorScript : MonoBehaviour {

    public AudioClip player;
    public AudioClip bullet;
    public GameObject[] obj;
                          
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)  //Plays Sound Whenever collision detected
    {
        if (collision.gameObject == obj[0])
        {
            GetComponent<AudioSource>().clip = player;
            GetComponent<AudioSource>().Play();
        }
        else if(collision.gameObject == obj[1])
        {
            GetComponent<AudioSource>().clip = bullet;
            GetComponent<AudioSource>().Play();
        }
    }
}
