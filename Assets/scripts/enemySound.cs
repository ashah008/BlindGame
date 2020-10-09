using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySound : MonoBehaviour {
    public GameObject character;
    public GameObject eyes;

    bool LeftRightZ = true;
    float EyeScanZ;
    public float ViewDistance;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //credit https://answers.unity.com/users/1030630/jeremysmartcs.html
        if (LeftRightZ)
        {
            if (EyeScanZ < 30)
            {
                EyeScanZ += 100 * Time.deltaTime;
            }
            else
            {
                LeftRightZ = false;
            }
        }
        else
        {
            if (EyeScanZ > -30)
            {
                EyeScanZ -= 100 * Time.deltaTime;
            }
            else
            {
                LeftRightZ = true;
            }
        }
        eyes.transform.localEulerAngles = new Vector3(0, EyeScanZ);


        RaycastHit hit;
        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * ViewDistance);

        if (Physics.Raycast(eyes.transform.position, eyes.transform.forward * ViewDistance, out hit, ViewDistance))
        {
            if (hit.transform.gameObject == character)
            {
                Debug.Log(gameObject.name + " CAN see Player");
            }

        }

    }
}
