using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSound : MonoBehaviour {
    public AudioClip breathing;
    private bool isPlaying = false;
    public playerScript player;
    public AudioSource sound;

    public AudioClip death;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.health < 15 && !isPlaying)
        {
            sound.clip = breathing;
            sound.loop = true;
            sound.Play();

            isPlaying = true;
        }
        if (player.health > 15)
        {
            sound.loop = false;
        }
        if (sound.clip == breathing && isPlaying && !sound.isPlaying)
        {
            isPlaying = false;
        }

        if(player.health <= 0)
        {
            sound.clip = death;
            sound.loop = false;
            sound.Play();
        }

        sound.volume = (float)0.6 - ((float)player.health / 100);
    }
}
