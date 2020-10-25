using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameObject audio;
    void Start(){
    	audio = GameObject.Find("Audio_Coin");
    }
    void Update(){} //

    void OnTriggerEnter2D(Collider2D other){
    	if(other.name == "player"){
    		audio.GetComponent<AudioSource>().Play();
	    	GameDirector.coin_get_num++;
	    	Destroy(gameObject);
	    }
    }
    

}
