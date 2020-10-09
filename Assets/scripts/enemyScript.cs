using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {
    public float health;
    public AudioSource player;
    public AudioClip sound;
    public AudioClip deathSound;
    
    
 
    public void takeDamage(float damageAmount)
    {
        if(health > 0)
        {
            player.clip = sound;
            player.loop = false;
            player.Play();
        }
        

        health -= damageAmount;
        if(health <= 0)
        {
            if (player.isPlaying)
            {
                player.clip = deathSound;
                player.loop = false;
                player.Play();
            }
            if (!player.isPlaying)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
