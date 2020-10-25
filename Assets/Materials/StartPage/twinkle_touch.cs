using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twinkle_touch : MonoBehaviour
{
    // public GameObject star;
    public float timeset,min_opacity;
    float  time, clktime;
    int effect_opacity;
    
    void Start()
    {	    	
    	effect_opacity = 1;	   
    	clktime=0.5f;
    }

    void Update()
    {	
    	time += Time.deltaTime;
    	if(time > clktime){
    		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, effect_opacity);	
    		time = 0;
    		effect_opacity *= -1;           
    	}
        
	
    	
    
    }
}
