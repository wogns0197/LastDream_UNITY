using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twinkle : MonoBehaviour
{
    // public GameObject star;
    public float timeset,min_opacity;
    float effect_opacity, time, clktime;
    int opc;
    
    void Start()
    {	
    	effect_opacity = 0.91f;	   
    	opc = 1;
    	clktime = 0.007f;
    	if(this.gameObject.name == "touch"){clktime=0.5f;}
    }

    void Update()
    {	
    	time += Time.deltaTime;
    	if(time > clktime){
    		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, effect_opacity);	
    		time = 0;
    	}
        if(opc==1){        	
    	    effect_opacity += timeset;           
        }
        else{
            effect_opacity -= timeset;   
        }
        if(effect_opacity >1 || effect_opacity<min_opacity){opc*=-1;}
	
    	
    
    }
}
