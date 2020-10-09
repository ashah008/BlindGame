using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //coding help from https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA Brakceys
    public CharacterController playerBody;

    public Transform checkFloor;
    public float checkRadius;
    public LayerMask ground;
    bool airTime = false;

    public AudioClip ouch;

    public float travelSpeed;
    float runMod = 1.0f;

    public AudioClip walk;
    public AudioClip run;

    Vector3 fallVel;
    public float grav;

    public double health = 100.00f;
    
    GameObject[] wallObject;
    GameObject[] enemyObject;

    // Start is called before the first frame update
    void Start()
    {
        wallObject = GameObject.FindGameObjectsWithTag("walls");
        enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 100)
        {
            health += 0.01;
        }
        

        airTime = Physics.CheckSphere(checkFloor.position, checkRadius, ground);
        //wallHit = Physics.CheckSphere(checkFloor.position, checkWallRadius, wall);

        //if (wallHit)
        //{
        //    takeDamage(2);
        //    wallHit = false;
        //}
    

        if (airTime && fallVel.y < 0)
        {
            fallVel.y = -2f;
        }

        Vector3 pos = transform.position;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        playerBody.Move(move * travelSpeed * Time.deltaTime * runMod * -1);

        fallVel.y += grav * Time.deltaTime;

        playerBody.Move(fallVel * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.Space) && airTime == false)
        //{
        //    Debug.Log("SpacePressed");
        //    playerBody.Move(new Vector3(0, 4f * -2f * grav, 0));
        //}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runMod = 1.85f;
        }
        else
        {
            runMod = 1f;
        }

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && airTime == false)
        {
            GetComponent<AudioSource>().clip = run;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
        else if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && airTime == false || Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift) && airTime == false || Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift) && airTime == false || Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift) && airTime == false)
        {
            GetComponent<AudioSource>().clip = walk;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<AudioSource>().Stop();
        }

        if (Input.GetKey(KeyCode.H))
        {
            health = 10;
        }

        
    }
    public void takeDamage(double damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            
        }

        GetComponent<AudioSource>().clip = ouch;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        for(int i = 0; i < wallObject.Length; ++i)
        {
            if (collision.gameObject == wallObject[i])
            {
                takeDamage(0.5);
            }
        }
        for (int i = 0; i < enemyObject.Length; ++i)
        {
            if (collision.gameObject == enemyObject[i])
            {
                takeDamage(10);
            }
        }
    }
}
