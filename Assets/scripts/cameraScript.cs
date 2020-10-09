using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
    public Transform PlayerTrans;
    
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public float rotSpeed = 100.0f;

    float xRot = 0f;
    

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;

        xRot = Mathf.Min(-90, Mathf.Max(90, xRot));
	}
	
	// Update is called once per frame
	void Update () {
        
        float camTurnAngleX = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;

        

        PlayerTrans.Rotate(Vector3.up * camTurnAngleX);
    

    }
}
