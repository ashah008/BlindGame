using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class health : MonoBehaviour {
    public Text text;
    public playerScript player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int healthVal = (int)player.health;
        text.text = healthVal.ToString();

    }
}
