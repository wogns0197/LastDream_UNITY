using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void Start(){}
    void Update(){} //

    void OnTriggerEnter2D(Collider2D other){
    	if(other.name == "player"){
	    	GameDirector.coin_get_num++;
	    	Destroy(gameObject);
	    }
    }
    

}
