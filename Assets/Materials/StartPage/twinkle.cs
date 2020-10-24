using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twinkle : MonoBehaviour
{
    // public GameObject star;
    public float timeset,min_opacity;
    float effect_opacity, time;
    int opc,flag;
    
    void Start()
    {	
    	flag = 0;
    	effect_opacity = 0.91f;	   
    	opc = 1;
    	
    }

    void Update()
    {
    	time += Time.deltaTime;
    	if(time > 0.007f){
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
