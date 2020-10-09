using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour {
    public float damage;
    public float range;
    public Camera kamera;
    public AudioClip gunshot;
    public AudioClip onTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            aim();
        }
    }

    void fire() {
        RaycastHit bang;
        if(Physics.Raycast(kamera.transform.position, kamera.transform.forward, out bang, range))
        {
            Debug.Log("Murda " + bang.transform.name);
            enemyScript target = bang.transform.GetComponent<enemyScript>();

            if(target != null)
            {
                target.takeDamage(damage);
            }
        }
        GetComponent<AudioSource>().clip = gunshot;
        GetComponent<AudioSource>().Play();
    }

    void aim()
    {
        RaycastHit point;
        if(Physics.Raycast(kamera.transform.position, kamera.transform.forward, out point, range))
        {
            Debug.Log("Pointing" + point.transform.name);
                     
            if(point.transform.tag == "Enemy")
            {
                GetComponent<AudioSource>().clip = onTarget;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
