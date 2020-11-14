using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMode : MonoBehaviour
{
    public GameObject mode1,mode2,mode3;
    public static float huddlespeed , supermodetime;    

    void Start(){}
    void Update(){}
    public void selectMode(){
    	if(this.gameObject.name == "mode1"){
    		huddlespeed = 0.04f;
    		supermodetime = 4f;
    		InitialGame.playerlist[InitialGame.playernum+1].mode = "EASY";
    	}
    	else if(this.gameObject.name == "mode2"){
    		huddlespeed = 0.06f;
    		supermodetime = 3f;
    		InitialGame.playerlist[InitialGame.playernum+1].mode = "NORMAL";    		
    	}
    	else if(this.gameObject.name == "mode3"){
    		huddlespeed = 0.08f;
    		supermodetime = 2f;
    		InitialGame.playerlist[InitialGame.playernum+1].mode = "HARD";
    	}
    }
}
