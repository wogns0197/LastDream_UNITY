using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kim : MonoBehaviour
{
 	public float time,z_rotation;   
    void Start()
    {
    	time=0;
        z_rotation = 0;        
    }

    
    void Update()
    {
     	time += Time.deltaTime;
    	if(time>0.007f){    		
    		z_rotation += 0.5f;
    		this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, z_rotation));
    		time=0;    			    	
    	}      
    }
}
