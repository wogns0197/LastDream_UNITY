using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeartSound : MonoBehaviour
{
    GameObject audio;
    void Start()
    {
        audio = GameObject.Find("Audio_Coin");
    }
    
	void OnTriggerEnter2D(Collider2D other){

    	audio.GetComponent<AudioSource>().Play();	
	    	
	    
    }
}
