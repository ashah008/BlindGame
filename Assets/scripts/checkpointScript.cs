using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour {
    GameObject player;
    AudioSource audioPlayer;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("player");
        audioPlayer = GetComponent<AudioSource>();

        audioPlayer.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            audioPlayer.Stop();
        }
    }
}
