using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearKey : MonoBehaviour
{
    public float time,z_rotation;
    public GameObject key,effect;

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
    		effect.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, z_rotation));
    		time=0;
    		// opacity++;
	    	// Debug.Log(opacity);
	    	// effect.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, opacity);
	    	// 뒤에 이펙트 반짝이게 하는거 좀더 공부 필요함
    	}
    		

    	// if(opacity==1){
    	// 	opa_bool=0;
    	// }
    	// else if(opacity==255){
    	// 	opa_bool=1;
    	// }

    	// if(opa_bool==1){
	    // 	opacity--;
	    // 	Debug.Log(opacity);
	    // 	effect.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, opacity);
	    	
	    // }
	    // else if(opa_bool==0){
	    // 	opacity++;
	    // 	effect.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, opacity);
	    	
	    // }
    }
}
