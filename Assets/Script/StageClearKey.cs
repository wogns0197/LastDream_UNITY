using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearKey : MonoBehaviour
{
    public float time,z_rotation,effect_opacity;
    int opc;
    public GameObject key,effect;

    void Start()
    {
        time=0;
        z_rotation = 0;        
        effect_opacity = 0.51f;
        opc = 1;
    }

    
    void Update()
    {	
    	time += Time.deltaTime;
    	if(time>0.007f){
    		
    		z_rotation += 0.5f;
    		effect.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, z_rotation));
    		time=0;    		
	    	effect.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, effect_opacity);
	    	
    	}    		
        if(opc==1){
    	    effect_opacity += 0.01f;           
        }
        else{
            effect_opacity -= 0.01f;   
        }
        if(effect_opacity >1 || effect_opacity<0.4f){opc*=-1;}

	    	
	    
    }
        
}
