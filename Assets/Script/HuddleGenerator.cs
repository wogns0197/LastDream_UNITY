using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuddleGenerator : MonoBehaviour
{
    
    float time;
    public GameObject huddle_prefab;
    public float huddle_speed=0.02f; 


    void Start()
    {
        time=0;
    }

    
    void Update()
    {
        time += Time.deltaTime;
        if(time>5f){
            Instantiate(huddle_prefab, this.transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
